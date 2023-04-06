using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reschangev2 : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Text chu;
    Resolution[] resolutions;
    public List<string> options = new List<string>();
    public int currentResolutionIndex;
    void Start()
    {
        resolutions= Screen.resolutions;
        resolutionDropdown.ClearOptions();
        
        string current1="";
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " x " + resolutions[i].refreshRate+"Hz";
            
                options.Add(option);
                
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            
            
        }
        chu.text = options[currentResolutionIndex];
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value= currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
     void Update()
    {       

        chu.text = options[currentResolutionIndex];
        
    }
    public void forward()
    {
        if (currentResolutionIndex == options.Count-1)
        {
            currentResolutionIndex = 0;
        }
        else currentResolutionIndex++;
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);
    }    
    public void backward()
    {
        if (currentResolutionIndex == 0)
        {
            currentResolutionIndex = options.Count;
        }
        currentResolutionIndex--;
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);
    }
   // public void setres(int resolutionIndex)
    //{
    //    Resolution resolution = resolutions[resolutionIndex];
    //    Screen.SetResolution(resolution.width, resolution.height,true,resolution.refreshRate);
   // }
   
}
