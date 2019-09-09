using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIfTutorialON : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("tutorialON", 1) == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
        //
        print("tutorialON: " + PlayerPrefs.GetInt("tutorialON", 1));
    }
}
