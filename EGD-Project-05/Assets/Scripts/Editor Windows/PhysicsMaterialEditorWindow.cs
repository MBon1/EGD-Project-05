using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMaterialEditorWindow : EditorWindow
{
    [SerializeField] ValueSlider inputField;
    [SerializeField] ValueSlider slider;
    float sliderHeight = 55;

    [SerializeField] bool disableBounciness = false;

    protected void Awake()
    {
        if (disableBounciness)
        {
            Destroy(slider.transform.parent.parent.gameObject);
            float newHeight = this.gameObject.GetComponent<RectTransform>().rect.height - sliderHeight;
            SetHeight(newHeight);
        }
        base.Awake();
    }

    public void SetDefaultValues(float friction, float bounciness)
    {
        inputField.SetValue(friction, false);
        if (!disableBounciness)
            slider.SetValue(bounciness, false);
    }

    protected override void SetAllWidgetsActiveness(bool active)
    {
        inputField.transform.parent.parent.gameObject.SetActive(active);
        if (!disableBounciness)
            slider.transform.parent.parent.gameObject.SetActive(active);
    }

    public float GetFrictionValue()
    {
        return inputField.value;
    }

    public float GetBouncinessValue()
    {
        if (!disableBounciness)
            return slider.value;

        return 0;
    }

    public PhysicsMaterial2D GetPhysicsMaterial()
    {
        PhysicsMaterial2D material = new PhysicsMaterial2D();
        material.friction = GetFrictionValue();
        material.bounciness = GetBouncinessValue();

        return material;
    }

    public override void SetTargetObject(GameObject obj)
    {
        if (obj == null || obj.GetComponent<Collider2D>() == null)
        {
            target = null;
            inputField.target = null;
            if (!disableBounciness)
                slider.target = null;
            if (!disableBounciness)
                SetDefaultValues(inputField.minValue(), slider.minValue());
            else
                SetDefaultValues(inputField.minValue(), 0);
            SetAllWidgetsInteractability(false);
        }
        else
        {
            target = obj;
            inputField.target = obj;
            if (!disableBounciness)
                slider.target = obj;

            SetAllWidgetsInteractability(true);

            Collider2D collider = target.GetComponent<Collider2D>();

            if (collider.sharedMaterial == null)
            {
                PhysicsMaterial2D physMat = new PhysicsMaterial2D();
                collider.sharedMaterial = physMat;
            }

            SetDefaultValues(collider.sharedMaterial.friction, collider.sharedMaterial.bounciness);
        }
    }

    public override void SetTargetProperty()
    {
        if (target != null)
        {
            PhysicsMaterial2D material = GetPhysicsMaterial();
            target.GetComponent<Collider2D>().sharedMaterial = material;
            Debug.Log(target.name + " Material || Friction - " + material.friction + " | Bounciness: " + material.bounciness);
        }
    }
}
