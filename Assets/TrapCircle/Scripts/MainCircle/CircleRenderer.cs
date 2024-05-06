using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CircleRenderer : MonoBehaviour
{
    GameController _controller;

    [Header("Main Line")]
    [SerializeField] private LineRenderer _circleLineRenderer;

    [Header("Circle Stats")]
    [SerializeField] private int _steps;
    [SerializeField] private float _radius;
    public float Radius => _radius;
    List<Vector3> currentPositions = new List<Vector3>();
    void Start()
    {
        _controller = FindObjectOfType<GameController>();

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
            _controller.SetTrapRoots(currentPosition);
            //currentPositions.Add(currentPosition);

            _circleLineRenderer.SetPosition(currentStep, currentPosition);
        }

        _controller.InitTrapAtStartGame();
    }

    private void OnDrawGizmos()
    {
        foreach(var position in currentPositions)
        {
            Gizmos.DrawSphere(position, 0.01f);
            Vector3 endpos = new Vector3(position.x / 1.3f, position.y / 1.3f, position.z);
            Gizmos.DrawSphere(endpos, 0.01f);
            Gizmos.DrawLine(position, endpos);
        }
    }

}
