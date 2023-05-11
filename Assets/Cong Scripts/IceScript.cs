using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{

    public Vector3 speed;

     public void OnTriggerStay(Collider col) {
     CharacterController ctrl = col.gameObject.GetComponent(typeof(CharacterController)) as CharacterController;
     if (ctrl) {
         ctrl.SimpleMove(speed);
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
