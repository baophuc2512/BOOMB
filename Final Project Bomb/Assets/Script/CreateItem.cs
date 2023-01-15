using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    private void Awake()
    {
        int random = Random.Range(0, 10);
        if (random < itemPrefabs.Length)
        {
            Instantiate(itemPrefabs[random], transform.position, Quaternion.identity);
        }
    }
}
