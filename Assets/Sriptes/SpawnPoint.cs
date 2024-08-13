using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private float _minCoordinateOfPosition = -5f;
    private float _maxCoordinateOfPosition = 5f;
    private float _maxTopCoordinateOfPosition = 1f;

    public Vector3 GetPoinCoordinates()
    {
        return transform.position = new Vector3(GetRandomPosition(), _maxTopCoordinateOfPosition, GetRandomPosition());
    }

    private float GetRandomPosition()
    {
        return Random.Range(_minCoordinateOfPosition, _maxCoordinateOfPosition);
    }
}