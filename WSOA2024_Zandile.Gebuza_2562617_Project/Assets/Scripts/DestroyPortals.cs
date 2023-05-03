using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPortals : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(timer());
    }


  //the portals will disappear after 20 seconds
    IEnumerator timer()
    {
        yield return new WaitForSeconds(25);
        Object.Destroy(this.gameObject);
    }
}
