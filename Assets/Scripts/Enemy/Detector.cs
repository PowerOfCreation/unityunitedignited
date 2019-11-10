// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool isMelee;
    public bool isBoss;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(isMelee){
                if(isBoss){
                    GetComponentInParent<Boss>().FoundPlayer();
                }else{
                    GetComponentInParent<MeleeEnemy>().player = other.transform;
                }
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
