using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Plane _plane;
    [SerializeField] private float _speedOfMoving;

    private SpawnPoint _point;
    private Mover _enemyMover;
    private List<Vector3> _coorditates;
    private float _defaultVector = 0;
    private float _mimBoardOfCoordinates = -2;
    private float _mimBoard = -1;
    private float _maxBoardOfCoordinates = 2;
    private float _maxBoard = 1;
    private int _maxNumberOfSpawnPoints = 2;
    private int _counterOfSpawnPoints = 0;
    private int _intervalOfInstantiation = 2;
    private float _valueOfUpdate = 0;


    public void Awake()
    {
        _point = GetComponent<SpawnPoint>();
        _coorditates = new List<Vector3>();
    }

    public void Start()
    {
        CreatePointsOfSpawn();

        StartCoroutine(SpawnEnemyInRandomPoint());
    }

    private IEnumerator SpawnEnemyInRandomPoint()
    {
        while (true)
        {
            SpawnEnemy();

            var wait = new WaitForSeconds(_intervalOfInstantiation);

            yield return wait;
        }
    }

    private IEnumerator MoveInLine(Mover moover)
    {
        Vector3 vector = GetDirection();

        while (true)
        {
            moover.Move(vector, _speedOfMoving);

            var wait = new WaitForSeconds(_valueOfUpdate);

            yield return wait;
        }
    }

    private Vector3 GetDirection()
    {
        return new Vector3(GetRandomVector(), _defaultVector, GetRandomVector());
    }

    private float GetRandomVector()
    {
        float vector = Random.Range(_mimBoardOfCoordinates, _maxBoardOfCoordinates);

        while (vector < _maxBoard && vector > _mimBoard)
        {
            vector = Random.Range(_mimBoardOfCoordinates, _maxBoardOfCoordinates);
        }

        return vector;
    }

    private void SpawnEnemy()
    {
        int randomPoint = Random.Range(0, _coorditates.Count);

        for (int i = 0; i < _coorditates.Count; i++)
        {
            if (i == randomPoint)
            {
                _enemyMover = GetEnemy(_plane.transform.position + _coorditates[i]).GetComponent<Mover>();

                StartCoroutine(MoveInLine(_enemyMover));
            }
        }
    }

    private void CreatePointsOfSpawn()
    {
        while (_counterOfSpawnPoints < _maxNumberOfSpawnPoints)
        {
            _coorditates.Add(_point.GetPoinCoordinates());
            _counterOfSpawnPoints++;
        }
    }

    private Enemy GetEnemy(Vector3 pointCoordinates)
    {
        return Instantiate(_prefabEnemy, pointCoordinates, Quaternion.identity);
    }
}