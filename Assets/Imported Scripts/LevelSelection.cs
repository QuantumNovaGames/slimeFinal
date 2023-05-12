using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelection : MonoBehaviour
{
  public Button[] lvlButtons;
  public TMP_Text[] scores;
  public static int selectedLevel = 10;

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
    int score1Text = PlayerPrefs.GetInt("HighScore1");
    int score2Text = PlayerPrefs.GetInt("HighScore2");
    int score3Text = PlayerPrefs.GetInt("HighScore3");
    int score4Text = PlayerPrefs.GetInt("HighScore4");
    int score5Text = PlayerPrefs.GetInt("HighScore5");
    if (selectedLevel == 0)
    {
      scores[0].SetText("Score: " + score1Text.ToString());
    }
    else if (selectedLevel == 1)
    {
      scores[0].SetText("Score: " + score1Text.ToString());
      scores[1].SetText("Score: " + score2Text.ToString());
    }
    else if (selectedLevel == 2)
    {
      scores[0].SetText("Score: " + score1Text.ToString());
      scores[1].SetText("Score: " + score2Text.ToString());
      scores[2].SetText("Score: " + score3Text.ToString());
    }
    else if (selectedLevel == 3)
    {
      scores[0].SetText("Score: " + score1Text.ToString());
      scores[1].SetText("Score: " + score2Text.ToString());
      scores[2].SetText("Score: " + score3Text.ToString());
      scores[3].SetText("Score: " + score4Text.ToString());
    }
    else if (selectedLevel == 4)
    {
      scores[0].SetText("Score: " + score1Text.ToString());
      scores[1].SetText("Score: " + score2Text.ToString());
      scores[2].SetText("Score: " + score3Text.ToString());
      scores[3].SetText("Score: " + score4Text.ToString());
      scores[4].SetText("Score: " + score5Text.ToString());
    }
    else
    {
      return;
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
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    Debug.Log("Player selected level 1");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel2()
  {
    selectedLevel = 1;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    Debug.Log("Player selected level 2");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel3()
  {
    selectedLevel = 2;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    Debug.Log("Player selected level 3");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel4()
  {
    selectedLevel = 3;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    Debug.Log("Player selected level 4");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }

  public void GoToLevel5()
  {
    selectedLevel = 4;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    Debug.Log("Player selected level 5");
    BGmusic.instance.GetComponent<AudioSource>().Pause();
  }
}
