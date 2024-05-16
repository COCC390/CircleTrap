using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : MonoBehaviour
{
    [SerializeField] private float _itemRotateSpeed;

    private Vector3 _eulers;
    void Start()
    {
        _eulers = new Vector3(0f, 0f, _itemRotateSpeed);
    }

    private void FixedUpdate()
    {
        transform.Rotate(_eulers, Space.Self);
    }
}
