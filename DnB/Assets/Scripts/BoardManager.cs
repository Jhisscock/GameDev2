using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoardManager : NetworkBehaviour
{
<<<<<<< HEAD
    [SyncVar]
    private static bool [,] board; 
=======
    private bool [,] board; 
>>>>>>> parent of 2411bfe... save
    public GameObject dot;
    [SyncVar]
    public GameObject line;
<<<<<<< HEAD
    [SyncVar]
    public GameObject p1Sqaure;
    [SyncVar]
    public GameObject p2Square;
    public static BoardManager Instance;
    [SyncVar]
    public GameObject line2;
    
    void Awake(){
        Instance = this;
    }
    [Server]
    void Start()
    {
        if(isServer){
            Debug.Log("Server Running");
        }
        board = new bool[10, 9];
        int vertCount = 0;
        int horizCount = 0;
        for(int i = 0; i < board.GetLength(0); i++){
            for(int j = 0; j < board.GetLength(1); j++){
                board[i,j] = false;
            }
        }
        for(int i = 0; i < (board.GetLength(0) - 6) * (board.GetLength(1) - 7); i++){
            var tmp = Instantiate(line, new Vector2((float)horizCount * 2, (float)vertCount * 2 + 1), Quaternion.Euler(0f, 0f, 90f));
            NetworkServer.SpawnWithClientAuthority(tmp, connectionToClient);
            if(horizCount >= board.GetLength(0) - 7){
=======
    // Start is called befor.e the first frame update
    void Start()
    {
        board = new bool[3, 2];
        int vertCount = 0;
        int horizCount = 0;
        for(int i = 0; i < (board.GetLength(0) + 1) * board.GetLength(1); i++){
            Instantiate(line, new Vector2((float)horizCount * 2 - 1f, (float)vertCount * 2 - 1f), Quaternion.Euler(0f, 0f, 90f));
            if(horizCount >= board.GetLength(0)){
>>>>>>> parent of 2411bfe... save
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
<<<<<<< HEAD
        for(int i = 0; i < (board.GetLength(0) - 7) * (board.GetLength(0) - 7); i++){
            var tmp = Instantiate(line, new Vector2((float)horizCount * 2 + 1, (float)vertCount*2), Quaternion.identity);
            NetworkServer.SpawnWithClientAuthority(tmp, connectionToClient);
            if(horizCount >= board.GetLength(0) - 8){
=======
        for(int i = 0; i < board.GetLength(0) * board.GetLength(0); i++){
            Instantiate(line, new Vector2((float)horizCount * 2, (float)vertCount*2 - 2), Quaternion.identity);
            if(horizCount >= board.GetLength(0) - 1){
>>>>>>> parent of 2411bfe... save
                horizCount = 0;
                vertCount++;
            }else{
                horizCount++;
            }
        }
        vertCount = 0;
        horizCount = 0;
<<<<<<< HEAD
        for(int i = 0; i < (board.GetLength(0) - 6) * (board.GetLength(0) - 7); i++){
            var tmp = Instantiate(dot, new Vector2((float)horizCount * 2 , (float)vertCount * 2 ), Quaternion.identity);
            NetworkServer.SpawnWithClientAuthority(tmp, connectionToClient);
            if(horizCount >= board.GetLength(0) - 7){
=======
        for(int i = 0; i < (board.GetLength(0) + 1) * board.GetLength(0); i++){
            Instantiate(dot, new Vector2((float)horizCount * 2 - 1f, (float)vertCount * 2 - 2f), Quaternion.identity);
            if(horizCount >= board.GetLength(0)){
>>>>>>> parent of 2411bfe... save
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

<<<<<<< HEAD
    [Command]
    public void CmdAddLine(int x, int y){
            Debug.Log("Server");
            if(y % 2 == 0){
                var tmp = Instantiate(line2, new Vector2(x-2, y-2), Quaternion.identity);
                NetworkServer.Spawn(tmp);
            }else{
                var tmp = Instantiate(line2, new Vector2(x-2, y-2), Quaternion.Euler(0f, 0f, 90f));
                NetworkServer.Spawn(tmp);
            }
            board[x,y] = true;
            CmdCheckBox(x, y);
    }

    [Command]
    void CmdCheckBox(int x, int y){
        if(y % 2 == 0){
            if(board[x - 1,y + 1] && board[x + 1, y + 1] && board[x,y + 2]){
                var tmp = Instantiate(p1Sqaure, new Vector2((float)x - 2, (float)y - 1), Quaternion.identity);
                NetworkServer.Spawn(tmp);
            }else if(board[x + 1,y - 1] && board[x - 1, y - 1] && board[x,y - 2]){
                var tmp = Instantiate(p1Sqaure, new Vector2((float)x - 2, (float)y - 3), Quaternion.identity);
                NetworkServer.Spawn(tmp);
            }
        }else{
            if(board[x + 1 ,y - 1] && board[x + 1, y + 1] && board[x + 2,y]){
                var tmp = Instantiate(p1Sqaure, new Vector2((float)x - 1, (float)y - 2), Quaternion.identity);
                NetworkServer.Spawn(tmp);
            }else if(board[x - 1,y + 1] && board[x - 1, y - 1] && board[x - 2,y]){
                var tmp = Instantiate(p1Sqaure, new Vector2((float)x - 3, (float)y - 2), Quaternion.identity);
                NetworkServer.Spawn(tmp);
            }
        }
=======
     void AddLine(){

>>>>>>> parent of 2411bfe... save
    }
}
