using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMaterialEditorWindow : EditorWindow
{
    [SerializeField] NumericInputField inputField;
    [SerializeField] ValueSlider slider;
    

    public void SetDefaultValues(float friction, float bounciness)
    {
        inputField.SetValue(friction, false);
        slider.SetValue(bounciness, false);
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
        if (obj != null)
        {
            Collider2D collider = obj.GetComponent<Collider2D>();
            if (collider == null)
            {
                return;
            }

            if (collider.sharedMaterial == null)
            {
                collider.sharedMaterial = new PhysicsMaterial2D();
            }
            else
            {
                SetDefaultValues(collider.sharedMaterial.friction, collider.sharedMaterial.bounciness);
            }
        }

        target = obj;
        inputField.target = obj;
        slider.target = obj;
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
