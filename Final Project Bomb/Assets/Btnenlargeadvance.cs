using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btnenlargeadvance : MonoBehaviour
{
    public List<Button> buttons;
    public List<Image> image;
    public List<Sprite> sprite1;
    public List<Sprite> sprite2;
    public int wid1, hig1, wid2, hig2;
    public void width1(int w1)
    {
        wid1 = w1;
    }
    public void hight1(int h1)
    {
        hig1 = h1;
    }
    public void width2(int w2)
    {
        wid2 = w2;
    }
    public void higth2(int h2)
    {
        hig2 = h2;
    }
    public void Enlarge(int tmp)
    {
        buttons[tmp].GetComponent<RectTransform>().sizeDelta = new Vector2(wid2,hig2);
        image[tmp].sprite = sprite2[tmp];

    }
    public void Mini(int tmp)
    {
        buttons[tmp].GetComponent<RectTransform>().sizeDelta = new Vector2(wid1, hig1) ;
        image[tmp].sprite = sprite1[tmp];
    }
}
