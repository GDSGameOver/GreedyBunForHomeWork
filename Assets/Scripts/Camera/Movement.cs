using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void Move(Rigidbody2D rigidbody)
    {
        rigidbody.velocity = new Vector2(_speed, rigidbody.velocity.y);
    }

    private void Update()
    {
        Move(_rigidbody);
    }
}
