using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject token;
    public int tokenCount = 0;
    public int playerScore = 0;
    public static GameController Instance;
    public Text text;
    public GameObject button;
    void Awake(){
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && tokenCount < 5){
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Instantiate(token, target, Quaternion.identity);
        }
    }

    public void DisplayScore(){
        text.text = playerScore.ToString();
        button.SetActive(true);
    }
}
