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

    public override void SetValue()
    {
        SetValue(slider.value, true);
    }

    public override void SetValue(float val, bool setProperty)
    {
        value = val;
        sliderText.text = value.ToString("0.00");

        if (target != null && setProperty)
        {
            SetProperty();
        }
    }
}
