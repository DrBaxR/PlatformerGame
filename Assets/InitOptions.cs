using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitOptions : MonoBehaviour
{
    public Toggle tutToggle;

    void Start()
    {
        //init tutorial toggle
        if(PlayerPrefs.GetInt("tutorialON", 1) == 1)
        {
            tutToggle.isOn = true;
        }
        else
        {
            tutToggle.isOn = false;
        }
    }
}
