using System;
using UnityEngine;

public class NoteController : MonoBehaviour
{
   private NoteMovement _movement;
   private float _moveSpeed;
   private Rigidbody2D _rb;

   private void Awake()
   {
      transform.position = transform.parent.position;
      _moveSpeed = 5f;
      _movement = new NoteMovement(_moveSpeed);
      _rb = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      _movement.Move(transform, _rb);
   }
}
