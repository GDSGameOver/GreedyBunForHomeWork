using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;
    private bool _isGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move(_rigidbody);
        Jump(_rigidbody);
    }

    private void Jump(Rigidbody2D rigidbody)
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, _jumpForce);
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isGround = true;
        }
    }
}
