using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shuffler : MonoBehaviour
{
    public GameObject [] deck = new GameObject[52];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            Shuffle();
        }

    }

    void Shuffle(){
        System.Random rand = new System.Random();
        for(int i = 0; i < 52; i++){
            int r = i + rand.Next(52-i);
            GameObject tmp = deck[r];
            deck[r] = deck[i];
            deck[i] = tmp;
            Instantiate(deck[r],transform.position,Quaternion.identity);
        }
    }
}
