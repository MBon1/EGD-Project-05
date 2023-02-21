using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericInputField : EditorWidget
{
    [SerializeField] Vector2 cap = new Vector2(float.MinValue, float.MaxValue);
    InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = this.GetComponent<InputField>();
    }

    public override void SetValue()
    {
        string inputText = inputField.text;

        if (!float.TryParse(inputText, out float newValue))
        {
            newValue = value;
        }

        SetValue(newValue, true);
    }

    public override void SetValue(float val, bool setProperty)
    {
        value = Mathf.Clamp(val, cap.x, cap.y);
        inputField.text = value.ToString("0.00");

        if (target != null && setProperty)
        {
            SetProperty();
        }
    }
}
