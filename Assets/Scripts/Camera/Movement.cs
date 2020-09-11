using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    public Rigidbody2D Rigidbody2D { get; protected set; }
    public Vector3 StartPosition { get; protected set; }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = new Vector3(0, 0, -10);
    }

    public void MoveToStartPosition()
    {
        transform.position = StartPosition;
        Rigidbody2D.velocity = Vector2.zero;
    }

    protected void Move()
    {
        Rigidbody2D.velocity = new Vector2(_moveSpeed, Rigidbody2D.velocity.y);
    }

    public Vector3 GetStartPosition()
    {
        return StartPosition;
    }

    private void Update()
    {
        Move();
    }
}
