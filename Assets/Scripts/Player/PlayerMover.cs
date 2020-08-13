using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _startPosition;

    private bool _isGround;

    private Rigidbody2D _rigidbody2D;

    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround) 
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out Platform platform))
            _isGround = true;
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody2D.velocity = Vector2.zero;
    }

    public void ConvulsionsAfterDeath()
    {
        _rigidbody2D.velocity = new Vector2(0, 20);
        _rigidbody2D.AddForce(Vector2.up * 10, ForceMode2D.Force);
    }
}

