using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRenderer : MonoBehaviour
{
    [Header("Main Line")]
    [SerializeField] private LineRenderer _circleLineRenderer;

    [Header("Circle Stats")]
    [SerializeField] private int _steps;
    [SerializeField] private float _radius;

    void Start()
    {
        CircleRender(_steps, _radius);
    }

    private void CircleRender(int steps, float radius)
    {
        _circleLineRenderer.positionCount = steps;

        for(int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float) currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            _circleLineRenderer.SetPosition(currentStep, currentPosition);
        }
    }

}
