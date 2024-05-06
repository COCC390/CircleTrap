using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private int _maxTrap = 20;
    [SerializeField] private int _startGameTrapAmount = 3;
    [SerializeField] private float _trapHeight = 1.3f;

    [SerializeField] private GameObject _trapItem;

    private GameController _gameController;
    private Dictionary<int, LineRenderer> _traps = new Dictionary<int, LineRenderer>();

    //test 
    int index = 0;
    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            index = RandomTrapIndex();
            InitTrap(1, _gameController.TrapRoots[index]);
        }
    }

    internal void InitTrap(int amount, Vector3 position)
    {
        for(int i = 0; i < amount; i++)
        {
            var trap = Instantiate(_trapItem, this.transform);
            LineRenderer lineRenderer = trap.GetComponent<LineRenderer>();
            var points = new Vector3[2] 
            {
                position, new Vector3 (position.x * _trapHeight, position.y * _trapHeight, position.z)
            };
            lineRenderer.SetPositions(points);

            _traps.Add(index, lineRenderer);
        }
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
