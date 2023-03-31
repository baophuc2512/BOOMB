using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPvpMode : MonoBehaviour
{
    [SerializeField] private ScriptableData mainData;

    private void Start()
    {
        mainData.isPvp = true;
        mainData.levelMap = -1;
        mainData.havePlayerTwo = true;
    }
}
