using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private GameObject _pointItem;

    private Vector2 _rootOuterPoint;
    private Vector2 _rootInnerPoint;
    private GameController _controller;

    void Awake()
    {
        _controller = FindObjectOfType<GameController>();
        _controller.ON_BALL_REACH_PLAY_POINT += InitRootPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitRootPosition(Vector2 rootOuterPoint, Vector2 rootInnerPoint)
    {
        _controller.ON_BALL_REACH_PLAY_POINT -= InitRootPosition;
        _rootOuterPoint = rootOuterPoint;
        _rootInnerPoint = rootInnerPoint;

        SpawnRandomPoint();
    }

    private void SpawnRandomPoint()
    {
        // Write function for handle spawn random point item here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnRandomPoint();
    }
}
