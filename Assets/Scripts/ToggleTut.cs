using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTut : MonoBehaviour
{
    public void ToggleTutorial()
    {
        if(PlayerPrefs.GetInt("tutorialON", 1) == 1)
        {
            PlayerPrefs.SetInt("tutorialON", 0);
        }
        else
        {
            PlayerPrefs.SetInt("tutorialON", 1);
        }
        //
        print("tutorialON: " + PlayerPrefs.GetInt("tutorialON", 1));
    }
}
