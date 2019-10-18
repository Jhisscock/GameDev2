using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animations;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            animations.SetTrigger("Attack");
        }else if(Input.GetKey(KeyCode.S)){
            animations.SetTrigger("Attack");
        }else if(Input.GetKey(KeyCode.A)){
            animations.SetTrigger("Attack");
        }else if(Input.GetKey(KeyCode.D)){
            animations.SetTrigger("Attack");
        }
        
    }
}
