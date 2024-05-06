using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private int _maxTrap = 20;
    [SerializeField] private int _startGameTrapAmount = 3;

    [SerializeField] private GameObject _trapItem;

    private GameController _gameController;
    private Dictionary<int, TrapItemController> _traps = new Dictionary<int, TrapItemController>();

    private int _trapIndex = 0;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
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
        for (int i = 0; i < _startGameTrapAmount; i++)
        {
            GenerateTrapByIndex();
        }
    }

    private void GenerateTrapByIndex()
    {
        _trapIndex = RandomTrapIndex();
        InitTrap(_gameController.TrapRoots[_trapIndex]);
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
        trapItem.InitTrapItem(position);

        _traps.Add(_trapIndex, trapItem);
    }

    private int RandomTrapIndex()
    {
        var maxValue = _gameController.TrapRoots.Count - 1;
        var result = 0;
        while(_traps.ContainsKey(result))
        {
            result = Random.Range(0, maxValue);
        }

        return result;
    }    
}
