using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Ball init")]
    [SerializeField] private float _initSpeed;

    [Header("Ball stats")]
    [SerializeField] private float _ballSpeed;

    void Start()
    {
        Vector2 initTargetPos = new Vector2(this.transform.position.x, this.transform.position.y + 2);

        StartCoroutine(InitBall(initTargetPos));
    }

    void FixedUpdate()
    {
        
    }

    private IEnumerator InitBall(Vector2 targetPos)
    {
        Vector2.Lerp(this.transform.position, targetPos, _initSpeed * Time.deltaTime);

        //while (Vector2.Distance(this.transform.position, targetPos) > 0.1f)
        //{
        //}
        yield return null;
    }
}
