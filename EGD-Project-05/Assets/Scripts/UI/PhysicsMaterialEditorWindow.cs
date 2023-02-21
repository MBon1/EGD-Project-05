using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMaterialEditorWindow : MonoBehaviour
{
    [SerializeField] NumericInputField inputField;
    [SerializeField] ValueSlider slider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void SetGameObject(GameObject obj)
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

        inputField.target = obj;
        slider.target = obj;
    }
}
