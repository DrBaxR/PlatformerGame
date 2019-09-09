using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressiveText : MonoBehaviour
{
    public int textCooldown = 5;
    public TextMeshProUGUI text;
    public string targetText;
    public bool textDone = false;

    private int nextText = 0;
    private int nextLetter = 0;

    private void Start()
    {
        text.text = "";
    }

    void Update()
    {
        if (!textDone)
        {
            if (nextText == textCooldown && nextLetter < targetText.Length)
            {
                AddLetter();
                nextText = 0;
            }
            nextText++;

            if (nextLetter >= targetText.Length)
                textDone = true;
        }
        else
        {
            text.text = targetText;
        }
    }

    void AddLetter()
    {
        text.text = text.text + targetText[nextLetter];
        nextLetter++;
    }
}
