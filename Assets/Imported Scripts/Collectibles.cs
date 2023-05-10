using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Play_collect collection = other.GetComponent<Play_collect>();
        if(collection != null){
            collection.crystalsCollected();
            gameObject.SetActive(false);
        }
    }
}
