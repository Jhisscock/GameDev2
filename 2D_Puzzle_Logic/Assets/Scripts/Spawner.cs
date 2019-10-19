using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] Tetriminos = new GameObject[7];
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 20; j++){
                Instantiate(background, new Vector3(i, j, 0f), Quaternion.identity);
            }
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(){
        Instantiate(Tetriminos[Random.Range(0,6)], new Vector3(5f, 20f, 0f), Quaternion.identity);
    }
}
