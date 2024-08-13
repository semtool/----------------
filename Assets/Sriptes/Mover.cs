using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(Vector3 vector, float speedOfMoving)
    {
        transform.Translate(vector.x * speedOfMoving, vector.y * speedOfMoving, vector.z * speedOfMoving);
    }
}