using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public int unlockedLevels = 0;
    public GameObject[] levelButtons;

    private void Start()
    {
        int i;
        for(i = 0; i < unlockedLevels; ++i)
        {
            levelButtons[i].GetComponent<Button>().enabled = true;
            Image lockedMask = levelButtons[i].transform.GetChild(1).GetComponent<Image>();
            lockedMask.enabled = false;
        }
        for(; i < levelButtons.Length; ++i)
        {
            levelButtons[i].GetComponent<Button>().enabled = false;
            Image lockedMask = levelButtons[i].transform.GetChild(1).GetComponent<Image>();
            lockedMask.enabled = true;
        }
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
