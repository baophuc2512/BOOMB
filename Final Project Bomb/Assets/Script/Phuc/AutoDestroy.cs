using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public GameObject thingToDestroy;
    public float timeToDestroy;
    
    public void Start()
    {
        StartCoroutine(destroy(timeToDestroy));
    }

    public IEnumerator destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(thingToDestroy);
    }
}
