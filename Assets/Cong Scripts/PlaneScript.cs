using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneScript : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
  {
    ScoreScript.score += 3;
    if (SceneManager.GetActiveScene().buildIndex == 2)
    {
      PlayerPrefs.SetInt("HighScore1", ScoreScript.score);
    }
    else if (SceneManager.GetActiveScene().buildIndex == 3)
    {
      PlayerPrefs.SetInt("HighScore2", ScoreScript.score);
    }
    else if (SceneManager.GetActiveScene().buildIndex == 4)
    {
      PlayerPrefs.SetInt("HighScore3", ScoreScript.score);
    }
    else if (SceneManager.GetActiveScene().buildIndex == 5)
    {
      PlayerPrefs.SetInt("HighScore4", ScoreScript.score);
    }
    else if (SceneManager.GetActiveScene().buildIndex == 6)
    {
      PlayerPrefs.SetInt("HighScore5", ScoreScript.score);
    }
    PlayerPrefs.SetInt("levelAt", SceneManager.GetActiveScene().buildIndex + 1);
    SceneManager.LoadScene("WinScreen");
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
