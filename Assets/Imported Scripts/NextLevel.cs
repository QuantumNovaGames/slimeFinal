using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
  public void Start()
  {
    Cursor.lockState = CursorLockMode.None;
  }

  public void NextLevelButton()
  {
    SceneManager.LoadScene("LevelSelection");
    BGmusic.instance.GetComponent<AudioSource>().Play();
  }

  public void MainMenuButton()
  {
    SceneManager.LoadScene("MainMenu");
    BGmusic.instance.GetComponent<AudioSource>().Play();
  }
}
