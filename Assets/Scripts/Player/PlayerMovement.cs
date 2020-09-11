using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private float _jumpForce;
    private bool _isGround;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = new Vector3(-7.57f, -3.36f, 0);
    }
    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, _jumpForce);
            _isGround = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
        {
            _isGround = true;
        }
    }
}
