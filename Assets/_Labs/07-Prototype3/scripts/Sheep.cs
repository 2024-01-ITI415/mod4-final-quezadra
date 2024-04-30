using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    private void OnTrigggerEnter(Collider other)
    {
    
      if (other.CompareTag("Player"))
      {
        print("it works");
        //Destroy(gameObject);
      }
    }
}
