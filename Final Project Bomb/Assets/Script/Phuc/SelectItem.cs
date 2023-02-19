using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour
{
    public List<Inventory> inventory;
    public KeyCode selectDown = KeyCode.Q;
    public KeyCode selectUp = KeyCode.E;
    private int currentSelectItem = 0;

    private void Start()
    {
        pushInfo();
    }

    private void Update() 
    {
        if (Input.GetKeyDown(selectDown))
        {
            loadInfo();
            currentSelectItem -= 1;
            if (currentSelectItem < 0) currentSelectItem = inventory.Count - 1;
            pushInfo();
        }
        if (Input.GetKeyDown(selectUp))
        {
            loadInfo();
            currentSelectItem += 1;
            if (currentSelectItem > inventory.Count - 1) currentSelectItem = 0;
            pushInfo();
        }
    }

    public void pushInfo()
    {
        PlaceBomb placeBomb = GetComponent<PlaceBomb>();
        placeBomb.bombPrefabs = inventory[currentSelectItem].prefab;
        placeBomb.typeBomb = inventory[currentSelectItem].typeBomb;
        placeBomb.numberBomb = inventory[currentSelectItem].numberBomb;
    }

    public void loadInfo()
    {
        PlaceBomb placeBomb = GetComponent<PlaceBomb>();
        inventory[currentSelectItem].prefab = placeBomb.bombPrefabs;
        inventory[currentSelectItem].typeBomb = placeBomb.typeBomb;
        inventory[currentSelectItem].numberBomb = placeBomb.numberBomb;
    }
}
