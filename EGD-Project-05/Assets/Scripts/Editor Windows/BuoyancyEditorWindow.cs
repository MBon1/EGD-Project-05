using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyEditorWindow : EditorWindow
{
    [SerializeField] ValueSlider densityInputField;
    [SerializeField] ValueSlider surfaceLevelInputField;
    [SerializeField] ValueSlider flowMagnitudeInputField;


    public void SetDefaultValues(float density, float surfaceLevel, float flowMagnitude)
    {
        densityInputField.SetValue(density, false);
        surfaceLevelInputField.SetValue(surfaceLevel, false);
        flowMagnitudeInputField.SetValue(flowMagnitude, false);
    }

    public float GetDensityValue()
    {
        return densityInputField.value;
    }

    public float GetSurfaceLevel()
    {
        return surfaceLevelInputField.value;
    }

    public float GetFlowMagnitude()
    {
        return flowMagnitudeInputField.value;
    }

    public override void SetTargetObject(GameObject obj)
    {
        if (obj != null && obj.GetComponent<BuoyancyEffector2D>() != null)
        {
            target = obj;
            densityInputField.target = obj;
            surfaceLevelInputField.target = obj;
            flowMagnitudeInputField.target = obj;

            BuoyancyEffector2D buoyancy = target.GetComponent<BuoyancyEffector2D>();

            SetDefaultValues(buoyancy.density, buoyancy.surfaceLevel, buoyancy.flowMagnitude);
        }
        else
        {
            target = null;
            densityInputField.target = null;
            surfaceLevelInputField.target = null;
            flowMagnitudeInputField.target = null;

            SetDefaultValues(densityInputField.minValue(), surfaceLevelInputField.minValue(), flowMagnitudeInputField.minValue());
        }
    }

    public override void SetTargetProperty()
    {
        if (target != null)
        {
            BuoyancyEffector2D buoyancy = target.GetComponent<BuoyancyEffector2D>();
            buoyancy.density = GetDensityValue();
            buoyancy.surfaceLevel = GetSurfaceLevel();
            buoyancy.flowMagnitude = GetFlowMagnitude();

            Debug.Log(target.name + " Buoyancy || Density - " + buoyancy.density + " | Surface Level: " + buoyancy.surfaceLevel + " | Flow Mag. " + buoyancy.flowMagnitude);
        }
    }
}
