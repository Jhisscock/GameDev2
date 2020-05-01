using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        GameController.Instance.playerScore += int.Parse(other.tag);
        if(GameController.Instance.tokenCount == 5){
            GameController.Instance.DisplayScore();
        }
        GameController.Instance.tokenCount++;
    }
}
