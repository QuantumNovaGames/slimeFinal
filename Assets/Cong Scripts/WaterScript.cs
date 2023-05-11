using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other) {
        ScoreScript.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ScoreScript.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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