using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaScript : MonoBehaviour
{
    [SerializeField] private float existTime;
    [SerializeField] private GameObject self;

    private void Start()
    {
        StartCoroutine(startTime());
    }

    public IEnumerator startTime()
    {
        yield return new WaitForSeconds(existTime);
        Destroy(self, 0f);
    }
}
