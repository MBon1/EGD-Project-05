using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditorWidget : MonoBehaviour
{
    public float value { get; protected set; }
    public GameObject target;
    [SerializeField] EditorWindow editorWindow;


    protected void SetProperty()
    {
        editorWindow.SetTargetProperty();

        /*if (target != null)
        {
            PhysicsMaterial2D material = editorWindow.GetPhysicsMaterial();
            target.GetComponent<Collider2D>().sharedMaterial = material;
            Debug.Log(target.name + " Material || Friction - " + material.friction + " | Bounciness: " + material.bounciness);
        }*/
    }

    public abstract void SetValue();

    public abstract void SetValue(float val, bool setProperty);
}
