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

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _trapPositions = new List<Vector3>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            //GenerateTrapByIndex();
            ChangeTrapDirection(0);
        }
    }

    internal void InitTrapAtStartGame()
    {
        InitRandomTrapPosition();

        //foreach(var trapPos in _trapPositions) 
        //{
        //    InitTrap(trapPos);
        //}
        for (int i = 0; i < _startGameTrapAmount; i++)
        {
            GenerateTrapByIndex();
        }
    }

    private void GenerateTrapByIndex()
    {
        //_trapIndex = RandomTrap();
        var trapPos = _trapPositions.GetRandomElementInList();
        _trapPositions.Remove(trapPos);

        InitTrap(trapPos);
    }

    private void ChangeTrapDirection(int index)
    {
        var trap = _traps[index];
        trap.SetTrapDirection();
    }

    private void InitTrap(Vector3 position)
    {
        var trap = Instantiate(_trapItem, this.transform);
        var trapItem = trap.GetComponent<TrapItemController>();
        trapItem.InitTrapItem(position, _gameController.Circle.transform);

        _traps.Add(_trapIndex, trapItem);
        _trapIndex++;
    }

    //private int RandomTrap()
    //{
    //    var maxValue = _gameController.TrapRoots.Count;

    //    if(_traps.Count == 0)
    //    {
    //        return Random.Range(0, maxValue);
    //    }

    //    var result = 0;
    //    while(_traps.ContainsKey(result))
    //    {
    //        result = Random.Range(0, maxValue);
    //    }

    //    return result;
    //}    

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
