using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlatformAfterTime : MonoBehaviour
{
    private void OnEnable()
    {
        DisablePlatform();
    }

    private void DisablePlatform()
    {
        StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(8);
        gameObject.SetActive(false);
    }
}
