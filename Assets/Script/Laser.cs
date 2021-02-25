using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            /*TO DO
             * if player catches, game over.
             */
            Debug.Log("Gameover!");
        }
    }
}
