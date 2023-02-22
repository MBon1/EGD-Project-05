using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMaterialEditorWindow : EditorWindow
{
    [SerializeField] ValueSlider inputField;
    [SerializeField] ValueSlider slider;
    

    public void SetDefaultValues(float friction, float bounciness)
    {
        inputField.SetValue(friction, false);
        slider.SetValue(bounciness, false);
    }

    protected override void SetAllWidgetsActiveness(bool active)
    {
        inputField.transform.parent.parent.gameObject.SetActive(active);
        slider.transform.parent.parent.gameObject.SetActive(active);
    }

    public float GetFrictionValue()
    {
        return inputField.value;
    }

    public float GetBouncinessValue()
    {
        return slider.value;
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
            slider.target = null;
            SetDefaultValues(inputField.minValue(), slider.minValue());
            SetAllWidgetsInteractability(false);
        }
        else
        {
            target = obj;
            inputField.target = obj;
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
