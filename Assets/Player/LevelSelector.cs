using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class LevelSelector : MonoBehaviour
{
    public int level;
    public Button[] lvlButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if(i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }
    public void OpenScene()
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

}
