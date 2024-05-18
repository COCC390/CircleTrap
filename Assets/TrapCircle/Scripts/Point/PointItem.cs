using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : MonoBehaviour
{
    [SerializeField] private float _itemRotateSpeed;

    private Vector3 _eulers;

    internal Action ON_PLAYER_REACH_POINT_ITEM;

    void Start()
    {
        _eulers = new Vector3(0f, 0f, _itemRotateSpeed);
    }

    private void FixedUpdate()
    {
        transform.Rotate(_eulers, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            ON_PLAYER_REACH_POINT_ITEM?.Invoke();
    }
}
