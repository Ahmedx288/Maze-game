using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{
    public AudioMixer MainMixer;
    Resolution[] availableResolutions;
    public Dropdown resolutionDropDown;


    //All Start Code here is to get the available screen resolutions
    void Start(){
        availableResolutions = Screen.resolutions;
        
        //resolutionDropDown = GameObject.Find("Resolution Dropdown").GetComponent<Dropdown>();
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        int currentResIndex = 0;
        for(int i = 0; i < availableResolutions.Length; i++){
            options.Add(availableResolutions[i].width + " x " + availableResolutions[i].height);

            if(availableResolutions[i].width == Screen.currentResolution.width &&
               availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    //Acutal Change of the Screen Resolution
    public void setRes(int resIndex){
        Resolution resolution = availableResolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    } 



    //Controll Volume
    public void setVol(float volumLevel){
        MainMixer.SetFloat("MixerVol", Mathf.Log10(volumLevel) * 20);
    }

    //Controll Game Quality
    public void setQulity(int Index){
        QualitySettings.SetQualityLevel(Index);
    }

    //Controll Screen Mode
    public void setFull(bool isFull){
        Screen.fullScreen = isFull;
    }
}
