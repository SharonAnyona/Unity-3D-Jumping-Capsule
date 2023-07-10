using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyaplatform : MonoBehaviour
{

 private void OnCollisionEnter(Collision collision)
 {
    if(collision.gameObject.name == "player1")
    {
        collision.gameObject.transform.SetParent(transform);
    }
    if(collision.gameObject.name == "player1")
    {
        collision.gameObject.transform.SetParent(null);
    }
 }  
}
