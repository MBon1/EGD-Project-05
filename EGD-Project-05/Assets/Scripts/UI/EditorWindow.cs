using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EditorWindow : MonoBehaviour
{
    protected GameObject target;

    public abstract void SetTargetProperty();
}
