using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickmap : MonoBehaviour
{
    public ScriptableData Mapdata;
    public Text Map_Text;
    Button mapchange;
    private void Awake()
    {
        Map_Text.text = "Map: " + Mapdata.levelMap;
    }
    public void ChangeMapUp()
    {   
        
        Mapdata.levelMap=Mapdata.levelMap +1;
        Map_Text.text = "Map: " + Mapdata.levelMap;
    }
    public void ChangeMapDown()
    {

        Mapdata.levelMap = Mapdata.levelMap -1;
        Map_Text.text = "Map: " + Mapdata.levelMap;
    }
}
