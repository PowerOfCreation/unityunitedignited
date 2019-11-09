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
                GetComponentInParent<MeleeEnemy>().player = other.transform;
            }else{
                GetComponentInParent<RangeEnemy>().player = other.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            //Lose Player
            if(isMelee){
                GetComponentInParent<MeleeEnemy>().player = null;
            }else{
                GetComponentInParent<RangeEnemy>().player = null;
            }
        }
    }
}
