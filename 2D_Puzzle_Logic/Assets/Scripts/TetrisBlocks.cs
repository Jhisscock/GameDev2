using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlocks : MonoBehaviour
{
    private int moveTime = 1;
    public Vector3 rotationPoint;
    private float timer = 0;
    private Transform [,] grid = new Transform[11,21];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 20; j++){
                grid[i,j] = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > moveTime){
            transform.position = new Vector3(transform.position.x, transform.position.y-1, 0f);
            if(!Boundaries()){
                transform.position = new Vector3(transform.position.x,transform.position.y+1, 0f);
                AddToGrid();
                CheckLine();
                this.enabled = false;
                FindObjectOfType<Spawner>().Spawn();
            }
            timer = 0;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position = new Vector3(transform.position.x-1f,transform.position.y, 0f);
            if(!Boundaries()){
                transform.position = new Vector3(transform.position.x+1f,transform.position.y, 0f);
            }   
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.position = new Vector3(transform.position.x+1f,transform.position.y, 0f);
            if(!Boundaries()){
                transform.position = new Vector3(transform.position.x-1f,transform.position.y, 0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            transform.position = new Vector3(transform.position.x,transform.position.y-1, 0f);
            if(!Boundaries()){
                transform.position = new Vector3(transform.position.x,transform.position.y+1, 0f);
            }
        }if(Input.GetKeyDown(KeyCode.Z)){
            transform.position = new Vector3(transform.position.x,transform.position.y-1, 0f);
            if(!Boundaries()){
                transform.position = new Vector3(transform.position.x,transform.position.y+1, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate !
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            if (!Boundaries())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }

    bool Boundaries(){
        foreach(Transform children in transform){

            if(children.position.x < 0 || children.position.x >= 10 || children.position.y < 0){
                return false;
            }
            if(grid[(int)children.position.x, (int)children.position.y] != null){
                return false;
            }
        }
        return true;
    }

    void AddToGrid(){
        foreach(Transform children in transform){
            grid[(int)children.position.x, (int)children.position.y] = children;
        }
    }

    void CheckLine(){
        int tmp = -1;
        foreach(Transform children in transform){
            if((int)children.position.y > tmp){
                tmp=(int)children.position.y;
            }
        }
        for(int i = 0; i < tmp; i++){
            if(HasLine(i)){
                DeleteLine(i);
                MoveDown(i);
            }
        }
    }

    bool HasLine(int i){
        for(int j = 0; j < 10; j++){
            if(grid[j,i] == false){
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i){
        for(int j = 0; j < 10; j++){
            Destroy(grid[j,i].gameObject);
            grid[j, i] = null;
        }
    }

    void MoveDown(int i){
        for(int l = i; l < 20; l++){
            for(int j = 0; j < 10; j++){
                if(grid[j, l] != null){
                    grid[j, l-1] = grid[j,l];
                    grid[j,l] = null;
                    grid[j,l-1].transform.position = new Vector3(0f,grid[j,l-1].transform.position.y-1f, 0f);
                }
            }
        }
    }
}
