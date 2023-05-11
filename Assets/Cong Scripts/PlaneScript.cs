using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneScript : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
  {
    ScoreScript.score += 3;
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
