using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Start()
  {
    Cursor.lockState = CursorLockMode.None;
  }

  public void levelSelect()
  {
    SceneManager.LoadScene("LevelSelection");
    Debug.Log("Player went to level selection menu");
  }

  public void Quit()
  {
    Application.Quit();
    Debug.Log("Player has quit the game");
  }

  public void resetProgress()
  {
    PlayerPrefs.DeleteAll();
  }
}
