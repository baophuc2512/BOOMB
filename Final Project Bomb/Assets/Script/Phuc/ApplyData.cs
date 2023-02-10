using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyData : MonoBehaviour
{
    public ScriptableData dataToLoad;
    public MoveCharacter moveCharacter;
    
    private void Awake()
    {
        moveCharacter.inputDown = dataToLoad.inputMoveDown;
        moveCharacter.inputUp = dataToLoad.inputMoveUp;
        moveCharacter.inputLeft = dataToLoad.inputMoveLeft;
        moveCharacter.inputRight = dataToLoad.inputMoveRight;
    }
}
