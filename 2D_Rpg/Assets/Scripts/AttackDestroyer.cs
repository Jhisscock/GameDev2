using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Wall"){
            Destroy(gameObject);
        }
    }
}
