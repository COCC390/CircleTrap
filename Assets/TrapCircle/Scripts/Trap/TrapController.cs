using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private int _maxTrap = 20;
    [SerializeField] private int _trapDistance = 5;
    [SerializeField] private int _startGameTrapAmount = 3;

    [SerializeField] private GameObject _trapItem;

    private GameController _gameController;
    private List<Vector3> _trapPositions;
    private Dictionary<int, TrapItemController> _traps = new Dictionary<int, TrapItemController>();

    private int _trapIndex = 0;

    public delegate void TrapControl();
    public static TrapControl RandomTrapChangeDirection;
    public static TrapControl InitMoreTrapHandle;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _trapPositions = new List<Vector3>();

        InitMoreTrapHandle += GenerateTrapByIndex;
        RandomTrapChangeDirection += ChangeTrapDirection;
    }

    private void OnDestroy()
    {
        InitMoreTrapHandle -= GenerateTrapByIndex;
        RandomTrapChangeDirection -= ChangeTrapDirection;
    }

    internal void InitTrapAtStartGame()
    {
        InitRandomTrapPosition();

        for (int i = 0; i < _startGameTrapAmount; i++)
        {
            GenerateTrapByIndex();
        }
    }

    private void GenerateTrapByIndex()
    {
        if (_trapPositions.Count == 0)
        {
            InitMoreTrapHandle -= GenerateTrapByIndex;
            return;
        } 

        var trapPos = _trapPositions.GetRandomElementInList();
        _trapPositions.Remove(trapPos);

        InitTrap(trapPos);
    }

    private void ChangeTrapDirection()
    {
        var trap = _traps.GetRandomElementInList();
        trap.Value.SetTrapDirection();
    }

    private void InitTrap(Vector3 position)
    {
        var trap = Instantiate(_trapItem, this.transform);
        var trapItem = trap.GetComponent<TrapItemController>();
        trapItem.InitTrapItem(position, _gameController.Circle.transform);

        _traps.Add(_trapIndex, trapItem);
        _trapIndex++;
    }

    private void InitRandomTrapPosition()
    {
        Vector3 position = _gameController.TrapRoots.GetRandomElementInList();
        _trapPositions.Add(position);

        var positionIndex = _gameController.TrapRoots.IndexOf(position);
        for(int i = 0; i < _maxTrap; i++)
        {
            positionIndex += _trapDistance;
            if (positionIndex >= _gameController.TrapRoots.Count)
                positionIndex -= _gameController.TrapRoots.Count;

            _trapPositions.Add(_gameController.TrapRoots[positionIndex]);
        }
    }

}
