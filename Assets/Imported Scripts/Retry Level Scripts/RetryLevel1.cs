using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel1 : MonoBehaviour
{
  public void RetryButton()
  {
    SceneManager.LoadScene("SampleScene");
  }

  public void MainMenuButton()
  {
    SceneManager.LoadScene("MainMenu");
  }
}
