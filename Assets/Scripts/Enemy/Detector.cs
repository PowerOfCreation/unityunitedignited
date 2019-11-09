// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool isMelee;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            //Chase Player
            if(isMelee){
                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            //Lose Player
            Debug.Log("Lost Player");
        }
    }
}
