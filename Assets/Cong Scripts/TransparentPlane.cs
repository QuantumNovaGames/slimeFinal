using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransparentPlane : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision other) {
        ScoreScript.score+=1;
        SceneManager.LoadScene("SampleScene");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
