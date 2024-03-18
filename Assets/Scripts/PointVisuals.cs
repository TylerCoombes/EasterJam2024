using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointVisuals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDespawn());
    }

    public IEnumerator WaitToDespawn()
    {
        Debug.Log("StartingCoroutine");

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
