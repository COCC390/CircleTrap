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

    [Header("Score")]
    [SerializeField] private int _score;

    private List<Vector3> _trapRoots;
    public List<Vector3> TrapRoots => _trapRoots;

    void Awake()
    {
        _trapRoots = new List<Vector3>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetTrapRoots(Vector3 position)
    {
        _trapRoots.Add(position);
    }

    public void InitTrapAtStartGame()
    {
        _trapManager.InitTrapAtStartGame();
    }
}
