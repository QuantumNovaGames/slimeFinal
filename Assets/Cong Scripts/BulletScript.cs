using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float life = 4f;
    // Start is called before the first frame update
    void Awake(){
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Bullet HIT!!");
        if(other.gameObject.layer == 9){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
