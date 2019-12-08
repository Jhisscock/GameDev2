using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDisplay : MonoBehaviour
{
    private Color startColor;
    private bool clicked = false;
    // Start is called before the first frame update
    void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseExit(){
        if(!clicked){
            GetComponent<SpriteRenderer>().color = Color.clear;
        }else{
            GetComponent<SpriteRenderer>().color = startColor;
        }
    }

    void OnMouseOver(){
        GetComponent<SpriteRenderer>().color = startColor;
    }

    void OnMouseDown(){
        GetComponent<BoxCollider2D>().enabled = false;
        clicked = true;
    }
}
