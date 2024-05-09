using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Ball init")]
    [SerializeField] private CircleRenderer _circleRenderer;
    [SerializeField] private float _initTime;

    private bool _canMoving = false;

    [Header("Ball stats")]
    [SerializeField] private float _distanceFromCircleToMoveRadian = 0.4f;
    [SerializeField] private float _outerRadian = 2.3f;
    [SerializeField] private float _innerRadian = 1.7f;
    [SerializeField] private float _innerBuffSpeedValue = 1.5f;
    [SerializeField] private float _ballSpeed;
    private float _currentAngle;
    private float _currentRadian;

    [Header("Ball Change Direction")]
    [SerializeField] private float _ballSwitchRadianSpeed;
    private float _interpolationValue = 0f;
    private float _targetRadian;
    private bool _isChangeRadian = false;

    public delegate void BallChangeRadian();
    public static BallChangeRadian ChangeCurrenRadianHandle;

    #region Unity Function / View
    void Start()
    {
        SetBallMoveRadian(_circleRenderer.Radius);

        Vector2 initTargetPos = new Vector2(this.transform.position.x, this.transform.position.y + _outerRadian);
        _currentRadian = _outerRadian;

        StartCoroutine(InitBall(initTargetPos, _initTime));

        ChangeCurrenRadianHandle += ChangeCurrentRadian;
    }

    private void OnDestroy()
    {
        ChangeCurrenRadianHandle -= ChangeCurrentRadian;
    }

    private void FixedUpdate()
    {
        if(_canMoving) 
            BallMove(_currentRadian);

        if(_isChangeRadian)
        {
            _currentRadian = Mathf.Lerp(_currentRadian, _targetRadian, _interpolationValue);
            _interpolationValue = _ballSwitchRadianSpeed * Time.deltaTime;

            if (_interpolationValue >= 1)
            {
                _isChangeRadian = false;
                _interpolationValue = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Break!!!");
    }

    #endregion

    #region Controller
    private void SetBallMoveRadian(float mainCircleRadius)
    {
        _innerRadian = mainCircleRadius - _distanceFromCircleToMoveRadian;
        _outerRadian = mainCircleRadius + _distanceFromCircleToMoveRadian;
    }

    public void ChangeCurrentRadian()
    {
        _isChangeRadian = true;
        
        _targetRadian = _targetRadian == _innerRadian ? _outerRadian : _innerRadian;
    }

    private void BallMove(float radius)
    {
        if (_targetRadian == _innerRadian)
            _currentAngle += _ballSpeed * 1.5f * Time.deltaTime;
        else
            _currentAngle += _ballSpeed * Time.deltaTime;

        // Calculate the new position based on the angle and radius
        float xPos = Mathf.Cos(_currentAngle) * radius;
        float yPos = Mathf.Sin(_currentAngle) * radius;
        // Set the GameObject's position
        transform.position = new Vector3(xPos, yPos, 0f);
    }

    private IEnumerator InitBall(Vector2 targetPos, float time)
    {
        float elapsedTime = 0;

        while (elapsedTime < time && Vector3.Distance(this.transform.position, targetPos) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _currentAngle = Mathf.Atan2(this.transform.position.y, this.transform.position.x);
        _canMoving = true;
    }
    #endregion
}
