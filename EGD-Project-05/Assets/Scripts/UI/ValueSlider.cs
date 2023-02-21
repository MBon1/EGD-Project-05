using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueSlider : EditorWidget
{
    Slider slider;
    [SerializeField] Text sliderText;

    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
    }

    public void SetValue()
    {
        SetValue(slider.value, true);
    }

    public void SetValue(float val, bool setMaterial)
    {
        value = val;
        sliderText.text = value.ToString("0.00");

        if (setMaterial)
        {
            SetMaterial();
        }
    }
}
