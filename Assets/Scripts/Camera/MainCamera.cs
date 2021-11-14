using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Vector3 _startPosition;

    public Vector3 StartPosition => _startPosition;
}
