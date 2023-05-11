using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour
{

    public Vector3 speed;

     public void OnTriggerStay(Collider col) {
     CharacterController ctrl = col.gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
     if (ctrl) {
        Vector3 velocity = new Vector3(0, 1000, 0);
         ctrl.SimpleMove(velocity * Time.deltaTime);
     }
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
