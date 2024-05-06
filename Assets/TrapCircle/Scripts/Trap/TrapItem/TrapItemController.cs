using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapItemController : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _trapHeight = 1.3f;

    [SerializeField] private TrapDirection _currentDirection;

    public void InitTrapItem(Vector3 position)
    {
        _currentDirection = RandomDirection();

        var trapDir = Vector3.zero;
        if(_currentDirection == TrapDirection.In)
            trapDir = new Vector3(position.x / _trapHeight, position.y / _trapHeight, 0);
        else
            trapDir = new Vector3(position.x * _trapHeight, position.y * _trapHeight, 0);

        var points = new Vector3[2]
        {
            position, trapDir
        };
        _lineRenderer.SetPositions(points);
    }    

    public void SetTrapDirection()
    {
        var position = _lineRenderer.GetPosition(0);

        var trapDir = Vector3.zero;
        if (_currentDirection == TrapDirection.In)
        {
            trapDir = new Vector3(position.x * _trapHeight, position.y * _trapHeight, 0);
            _currentDirection = TrapDirection.Out;
        }
        else
        {
            trapDir = new Vector3(position.x / _trapHeight, position.y / _trapHeight, 0);
            _currentDirection = TrapDirection.In;
        }

        var points = new Vector3[2]
        {
            _lineRenderer.GetPosition(0), trapDir
        };
        _lineRenderer.SetPositions(points);
    }

    private TrapDirection RandomDirection()
    {
        return (TrapDirection)Random.Range(0, 2);
    }
}

public enum TrapDirection
{
    In = 0,
    Out = 1
}
