using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    
    private void FixedUpdate()
    {
            transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
    }
}
