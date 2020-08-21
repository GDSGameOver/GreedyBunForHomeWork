using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDeactivator : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
    }
}
