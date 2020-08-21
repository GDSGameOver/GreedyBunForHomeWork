using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Vector3 _startPosition = new Vector3(0,0,-10);
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
    }

    public void ResetCamera()
    {
        transform.position = _startPosition;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
