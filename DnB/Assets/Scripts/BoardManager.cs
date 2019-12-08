using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private bool [,] board; 
    public GameObject dot;
    public GameObject line;
    // Start is called befor.e the first frame update
    void Start()
    {
        board = new bool[3, 2];
        int vertCount = 0;
        int horizCount = 0;
        for(int i = 0; i < (board.GetLength(0) + 1) * board.GetLength(1); i++){
            Instantiate(line, new Vector2((float)horizCount * 2 - 1f, (float)vertCount * 2 - 1f), Quaternion.Euler(0f, 0f, 90f));
            if(horizCount >= board.GetLength(0)){
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
        for(int i = 0; i < board.GetLength(0) * board.GetLength(0); i++){
            Instantiate(line, new Vector2((float)horizCount * 2, (float)vertCount*2 - 2), Quaternion.identity);
            if(horizCount >= board.GetLength(0) - 1){
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
        for(int i = 0; i < (board.GetLength(0) + 1) * board.GetLength(0); i++){
            Instantiate(dot, new Vector2((float)horizCount * 2 - 1f, (float)vertCount * 2 - 2f), Quaternion.identity);
            if(horizCount >= board.GetLength(0)){
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        //Camera.main.transform.position = new Vector3((board.GetLength(0) + 1) / 2, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void AddLine(){

    }
}
