﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegSpawner : MonoBehaviour
{
    public GameObject peg;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <  6; i++){
            for(int j = 0; j < 5; j++){
                if(j % 2 == 0 && j<6){
                    Instantiate(peg, new Vector2(i -2.5f,(j-2) * 2), Quaternion.identity);
                }else{
                    Instantiate(peg, new Vector2(i - 3,(j-2) * 2), Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
