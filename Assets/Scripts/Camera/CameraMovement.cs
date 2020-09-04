using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : Movement
{
    private void Start()
    {
       StartPosition = new Vector3(0, 0, -10);
    }

    private void Update()
    {
       Move();
    }
}
