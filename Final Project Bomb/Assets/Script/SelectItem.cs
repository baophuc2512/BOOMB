using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public GameObject[] bombPrefabs;
    public int[] typeBombs;
    public float[] timesBombExplose;
    public KeyCode selectDown = KeyCode.Q;
    public KeyCode selectUp = KeyCode.E;
    private int currentBomb;

    private void Awake()
    {
        pushInfo();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(selectDown))
        {
            currentBomb -= 1;
            if (currentBomb < 0) currentBomb = bombPrefabs.Length - 1;
            pushInfo();
        }
        if (Input.GetKeyDown(selectUp))
        {
            currentBomb += 1;
            if (currentBomb > bombPrefabs.Length - 1) currentBomb = 0;
            pushInfo();
        }
    }

    public void pushInfo()
    {
        PlaceBomb stats = GetComponent<PlaceBomb>();
        stats.bombPrefabs = bombPrefabs[currentBomb];
        stats.typeBomb = typeBombs[currentBomb];
        stats.timeExplose = timesBombExplose[currentBomb];
    }
}
