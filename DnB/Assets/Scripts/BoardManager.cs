using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private static bool [,] board; 
    private bool[,] copyBoard;
    public GameObject dot;
    public GameObject line;
    public GameObject p1Sqaure;
    public GameObject p2Square;
    public static BoardManager Instance;
    
    void Awake(){
        Instance = this;
    }
    void Start()
    {
        board = new bool[10, 9];
        int vertCount = 0;
        int horizCount = 0;
        for(int i = 0; i < board.GetLength(0); i++){
            for(int j = 0; j < board.GetLength(1); j++){
                board[i,j] = false;
            }
        }
        for(int i = 0; i < (board.GetLength(0) - 6) * (board.GetLength(1) - 7); i++){
            Instantiate(line, new Vector2((float)horizCount * 2, (float)vertCount * 2 + 1), Quaternion.Euler(0f, 0f, 90f));
            if(horizCount >= board.GetLength(0) - 7){
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
        for(int i = 0; i < (board.GetLength(0) - 7) * (board.GetLength(0) - 7); i++){
            Instantiate(line, new Vector2((float)horizCount * 2 + 1, (float)vertCount*2), Quaternion.identity);
            if(horizCount >= board.GetLength(0) - 8){
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
        for(int i = 0; i < (board.GetLength(0) - 6) * (board.GetLength(0) - 7); i++){
            Instantiate(dot, new Vector2((float)horizCount * 2 , (float)vertCount * 2 ), Quaternion.identity);
            if(horizCount >= board.GetLength(0) - 7){
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

    public void AddLine(int x, int y){
        board[x,y] = true;
        Debug.Log(x + ", " + y);
        CheckBox(x, y);
    }

    void CheckBox(int x, int y){
        if(y % 2 == 0){
            if(board[x - 1,y + 1] && board[x + 1, y + 1] && board[x,y + 2]){
                Instantiate(p1Sqaure, new Vector2((float)x - 2, (float)y - 1), Quaternion.identity);
            }else if(board[x + 1,y - 1] && board[x - 1, y - 1] && board[x,y - 2]){
                Instantiate(p1Sqaure, new Vector2((float)x - 2, (float)y - 3), Quaternion.identity);
            }
        }else{
            if(board[x + 1 ,y - 1] && board[x + 1, y + 1] && board[x + 2,y]){
                Instantiate(p1Sqaure, new Vector2((float)x - 1, (float)y - 2), Quaternion.identity);
            }else if(board[x - 1,y + 1] && board[x - 1, y - 1] && board[x - 2,y]){
                Instantiate(p1Sqaure, new Vector2((float)x - 3, (float)y - 2), Quaternion.identity);
            }
        }
    }
}
