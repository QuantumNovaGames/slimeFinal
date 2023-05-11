using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGeneral : MonoBehaviour
{
  // Start is called before the first frame update
  void OnTriggerEnter(Collider other)
  {//immediately on first contact
    Debug.Log("Touched Goal");
  }

  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.tag == "Goal")
    {
      Debug.Log("Staying on Goal");
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Goal")
    {
      Debug.Log("Leaving Goal");
    }
  }

}
