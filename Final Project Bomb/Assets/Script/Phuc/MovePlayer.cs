using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private ScriptableData mainData;
    private GameObject playerOne;
    private GameObject playerTwo;

    private void Awake()
    {
        playerOne = GameObject.Find("PlayerOne");
        playerTwo = GameObject.Find("PlayerTwo");
    }

    private void Start()
    {
        if (mainData.havePlayerTwo == false) 
        {
            playerTwo.SetActive(false);
            playerTwo = null;
        }
        if (mainData.isPvp == true)
        {
            playerOne.transform.position = new Vector3(-138, 44, 0);
            if (playerTwo != null) playerTwo.transform.position = new Vector3(-129, 44, 0);
        } else if (mainData.levelMap == 11 || mainData.levelMap == 12)
        {
            playerOne.transform.position = new Vector3(-93, 50, 0);
            if (playerTwo != null) playerTwo.transform.position = new Vector3(-93, 53, 0);
        } else if (mainData.levelMap == 13 || mainData.levelMap == 14)
        {
            playerOne.transform.position = new Vector3(106, 46, 0);
            if (playerTwo != null) playerTwo.transform.position = new Vector3(108, 46, 0);
        }
    }
}
