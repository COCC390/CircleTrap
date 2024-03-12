using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private BallMovement _ballMovement;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Switch radian");
            _ballMovement.ChangeCurrentRadian();
        }
    }
}
