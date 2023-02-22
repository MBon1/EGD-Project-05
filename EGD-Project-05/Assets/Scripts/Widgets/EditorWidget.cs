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
    }

    public abstract void SetValue();

    public abstract void SetValue(float val, bool setProperty);
}
