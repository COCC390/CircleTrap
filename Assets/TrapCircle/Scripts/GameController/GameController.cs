using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _gameConfig;

    [Header("Manager")]
    [SerializeField] private CircleRenderer _circleRenderer;
    [SerializeField] private TrapController _trapManager;
    [SerializeField] private BallMovement _ballMovement;

    public BallMovement Ball => _ballMovement;

    public CircleRenderer Circle => _circleRenderer;
    [Header("Score")]
    [SerializeField] private int _score;
    [SerializeField] private int _initTrapMileStone = 8;

    private List<Vector3> _trapRoots;
    public List<Vector3> TrapRoots => _trapRoots;

    public Action<Vector2, Vector2, float, float> ON_BALL_REACH_PLAY_POINT;

    void Awake()
    {
        _trapRoots = new List<Vector3>();
    }

    private void Start()
    {
        _score = 0;
    }

    public void SetTrapRoots(Vector3 position)
    {
        _trapRoots.Add(position);
    }

    public void InitTrapAtStartGame()
    {
        _trapManager.InitTrapAtStartGame();
    }

    public void UpgradeGameDifficulty()
    {
        if(TrapController.InitMoreTrapHandle != null)
        {
            if(_score % 10 == _initTrapMileStone)
                TrapController.InitMoreTrapHandle?.Invoke();
        }
        else
            ChangeBallSpeed();

        TrapController.RandomTrapChangeDirection?.Invoke();
    }

    private void ChangeBallSpeed()
    {
        _ballMovement.ON_UP_BALL_SPEED?.Invoke(0.1f);
    }

    public void UpdateScore()
    {
        _score++;

        // update ui score change
    }
}
