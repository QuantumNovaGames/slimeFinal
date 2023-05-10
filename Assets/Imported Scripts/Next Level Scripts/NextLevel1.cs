using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel1 : MonoBehaviour
{
  public void NextLevelButton()
  {
    SceneManager.LoadScene("");
  }

  public void MainMenuButton()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
