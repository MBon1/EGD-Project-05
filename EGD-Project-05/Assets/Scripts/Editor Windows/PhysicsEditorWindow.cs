using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEditorWindow : MonoBehaviour
{
    public PhysicsSettingsEditorWindow physSettingsEditor;
    public PhysicsMaterialEditorWindow physMatEditor;


    // Start is called before the first frame update
    void Start()
    {
        EnablePhysMatWindow(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePhysMatWindow(bool enable)
    {
        physMatEditor.gameObject.SetActive(enable);
    }
}
