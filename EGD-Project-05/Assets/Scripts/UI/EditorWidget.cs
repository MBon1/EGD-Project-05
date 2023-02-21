using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorWidget : MonoBehaviour
{
    public float value;
    public GameObject target;
    [SerializeField] PhysicsMaterialEditorWindow editorWindow;


    protected void SetMaterial()
    {
        if (target != null)
        {
            PhysicsMaterial2D material = editorWindow.GetPhysicsMaterial();
            target.GetComponent<Collider2D>().sharedMaterial = material;
            Debug.Log(target.name + " Material || Friction - " + material.friction + " | Bounciness: " + material.bounciness);
        }
    }
}
