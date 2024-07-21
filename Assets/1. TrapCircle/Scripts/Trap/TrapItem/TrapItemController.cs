using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapItemController : MonoBehaviour
{
    [SerializeField] private TrapDirection _currentDirection;

    private Vector3 _trapDirection;

    public void InitTrapItem(Vector3 position, Transform mainCircleTransform)
    {
        this.transform.position = position;

        _trapDirection = new Vector3(this.transform.position.x - mainCircleTransform.position.x, this.transform.position.y - mainCircleTransform.position.y, 0f);

        var angle = Mathf.Atan2(_trapDirection.y, _trapDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _currentDirection = RandomDirection();
        if (_currentDirection == TrapDirection.In)
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void SetTrapDirection()
    {
        if (_currentDirection == TrapDirection.In)
        {
            this.transform.localScale = new Vector3(-1f, 1f, 1f);
            _currentDirection = TrapDirection.Out;
        }
        else
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
            _currentDirection = TrapDirection.In;
        }
    }

    private TrapDirection RandomDirection()
    {
        return (TrapDirection)UnityEngine.Random.Range(0, 2);
    }

}

public enum TrapDirection
{
    In = 0,
    Out = 1
}
