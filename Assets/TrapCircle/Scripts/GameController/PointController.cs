using System.Collections;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private float _delayTimeSpawnPoint;
    [SerializeField] private float _minRandomDistance;
    [SerializeField] private float _maxRandomDistance;
    [SerializeField] private GameObject _pointItem;

    private Transform _pointItemTrans;
    
    private float _outerRadius;
    private float _innerRadius;
    private Vector2 _rootOuterPoint;
    private Vector2 _rootInnerPoint;
    private GameController _controller;

    void Awake()
    {
        _controller = FindObjectOfType<GameController>();
        _controller.ON_BALL_REACH_PLAY_POINT += InitRootPosition;
    }

    private void InitRootPosition(Vector2 rootOuterPoint, Vector2 rootInnerPoint, float outerRadius, float innerRadius)
    {
        _controller.ON_BALL_REACH_PLAY_POINT -= InitRootPosition;
        
        _outerRadius = outerRadius;
        _innerRadius = innerRadius;

        _rootOuterPoint = rootOuterPoint;
        _rootInnerPoint = rootInnerPoint;

        SpawnRandomPoint();
    }

    private void SpawnRandomPoint()
    {
        var randomValue = Random.Range(0, 2);

        var rootPoint = RandomRootPoint(randomValue);
        var radius = RandomRadius(randomValue);

        var randomDistance = Random.Range(_minRandomDistance, _maxRandomDistance);
        var angle = Mathf.Atan2(rootPoint.x, rootPoint.y);

        var randomPoint = angle + randomDistance;

        float xPos = Mathf.Cos(randomPoint) * radius;
        float yPos = Mathf.Sin(randomPoint) * radius;

        if (_pointItemTrans == null)
        {
            var item = Instantiate(_pointItem, new Vector3(xPos, yPos, 0f), Quaternion.identity, this.transform);
            item.GetComponent<PointItem>().ON_PLAYER_REACH_POINT_ITEM = OnPlayerReachPointItem;

            _pointItemTrans = item.transform;
        }
        else
            _pointItemTrans.position = new Vector3(xPos, yPos);
       
    }

    private Vector2 RandomRootPoint(int value)
    {
        return value == 0 ? _rootOuterPoint : _rootInnerPoint;
    }

    private float RandomRadius(int value)
    {
        return value == 0 ? _outerRadius : _innerRadius;
    }

    private void OnPlayerReachPointItem()
    {
        TrapController.InitMoreTrapHandle?.Invoke();
        TrapController.RandomTrapChangeDirection?.Invoke();

        StartCoroutine(DelaySpawnPointItem());
    }

    private IEnumerator DelaySpawnPointItem()
    {
        yield return new WaitForSeconds(_delayTimeSpawnPoint);

        SpawnRandomPoint();
    }
}
