using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Ball init")]
    [SerializeField] private float _initTime;

    private bool _canMoving = false;

    [Header("Ball stats")]
    [SerializeField] private float _outerRadian = 2.3f;
    [SerializeField] private float _innerRadian = 1.7f;
    [SerializeField] private float _currentAngle;
    [SerializeField] private float _ballSpeed;

    [SerializeField] private float _currentRadian;

    void Start()
    {
        Vector2 initTargetPos = new Vector2(this.transform.position.x, this.transform.position.y + _outerRadian);
        _currentRadian = _outerRadian;

        StartCoroutine(InitBall(initTargetPos, _initTime));
    }

    private void FixedUpdate()
    {
        if(_canMoving) 
            BallMove(_currentRadian);
    }

    public void ChangeCurrentRadian()
    {
        _currentRadian = _currentRadian == _outerRadian ? _innerRadian : _outerRadian;

        //if(_currentRadian == _outerRadian)
        //{
        //    _currentRadian = Mathf.Lerp(_currentRadian, _innerRadian, _ballSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    _currentRadian = Mathf.Lerp(_currentRadian, _outerRadian, _ballSpeed * Time.deltaTime);
        //}
    }    

    private void BallMove(float radius)
    {
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

        while (elapsedTime < time && Vector3.Distance(this.transform.position, targetPos) >= 0.1f)
        {
            this.transform.position = Vector2.Lerp(this.transform.position, targetPos, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _currentAngle = Mathf.Atan2(this.transform.position.y, this.transform.position.x);
        _outerRadian = this.transform.position.y;
        _canMoving = true;

    }
}
