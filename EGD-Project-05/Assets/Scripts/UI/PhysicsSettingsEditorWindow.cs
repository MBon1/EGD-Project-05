using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSettingsEditorWindow : EditorWindow
{
    [SerializeField] NumericInputField gravXInputField;
    [SerializeField] NumericInputField gravYInputField;
    [SerializeField] NumericInputField timeInputField;

    private void Start()
    {
        SetTargetObject(this.gameObject);
        SetDefaultValues();
    }

    public void SetDefaultValues()
    {
        Vector2 gravity = Physics2D.gravity;
        gravXInputField.SetValue(gravity.x, false);
        gravYInputField.SetValue(gravity.y, false);

        timeInputField.SetValue(Time.timeScale, false);
    }

    public Vector2 GetGravityValue()
    {
        return new Vector2(gravXInputField.value, gravYInputField.value);
    }

    public float GetTimeScaleValue()
    {
        return timeInputField.value;
    }

    public override void SetTargetObject(GameObject obj)
    {
        this.target = obj;
        gravXInputField.target = obj;
        gravYInputField.target = obj;
        timeInputField.target = obj;
    }

    public override void SetTargetProperty()
    {
        Physics2D.gravity = GetGravityValue();
        Time.timeScale = GetTimeScaleValue();

        Debug.Log(" Gravity : " + Physics2D.gravity + " | Time Scale: " + Time.timeScale);
    }
}
