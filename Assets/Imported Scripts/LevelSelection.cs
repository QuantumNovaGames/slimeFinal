using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelection : MonoBehaviour
{
  public Button[] lvlButtons;
  public TMP_Text[] scores = new TMP_Text[10];
  public static int selectedLevel;

  public void Start()
  {
    Cursor.lockState = CursorLockMode.None;
    int levelAt = PlayerPrefs.GetInt("levelAt", 2);
    for (int i = 0; i < lvlButtons.Length; i++)
    {
      if (i + 2 > levelAt)
      {
        lvlButtons[i].interactable = false;
      }
    }

    setScore();
  }

  public void Update()
  {
  }

  public void setScore()
  {
    int scoreText = PlayerPrefs.GetInt("HighScore");
    if (selectedLevel == 0)
    {
      scores[0].SetText("Score: " + scoreText.ToString());
      DontDestroyOnLoad(scores[0]);
    }
    if (selectedLevel == 1)
    {
      scores[1].SetText("Score: " + scoreText.ToString());
      DontDestroyOnLoad(scores[1]);
    }
    if (selectedLevel == 2)
    {
      scores[2].SetText("Score: " + scoreText.ToString());
      DontDestroyOnLoad(scores[2]);
    }
    if (selectedLevel == 3)
    {
      scores[3].SetText("Score: " + scoreText.ToString());
      DontDestroyOnLoad(scores[3]);
    }
    if (selectedLevel == 4)
    {
      scores[4].SetText("Score: " + scoreText.ToString());
      DontDestroyOnLoad(scores[4]);
    }
  }

  public void BackToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("Player went back to the main menu");
  }

  public void GoToLevel1()
  {
    selectedLevel = 0;
    SceneManager.LoadScene("Level1");
    Debug.Log("Player selected level 1");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
   }

  public void GoToLevel2()
  {
    selectedLevel = 1;
    SceneManager.LoadScene("Level2");
    Debug.Log("Player selected level 2");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel3()
  {
    selectedLevel = 2;
    SceneManager.LoadScene("Level3");
    Debug.Log("Player selected level 3");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel4()
  {
    selectedLevel = 3;
    SceneManager.LoadScene("Level4");
    Debug.Log("Player selected level 4");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
   }

  public void GoToLevel5()
  {
    selectedLevel = 4;
    SceneManager.LoadScene("Level5");
    Debug.Log("Player selected level 5");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }
}
