using System;
using UnityEngine;

public class NoteMovement
{
    private float _moveSpeed;

    public NoteMovement(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }

    public void Move(Transform transform, Rigidbody2D rb)
    {
        rb.MovePosition(transform.position + (_moveSpeed * Time.fixedDeltaTime * Vector3.left));
    }
}
