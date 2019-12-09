using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LineDisplay : NetworkBehaviour
{
    [SyncVar]
    private Color startColor;
    [SyncVar]
    private bool clicked = false;
    [SyncVar]
    private GameObject tmp;
    // Start is called before the first frame update
    [Command]
    void Start()
    {
        tmp = this.gameObject;
        startColor = tmp.GetComponent<SpriteRenderer>().color;
        tmp.GetComponent<SpriteRenderer>().color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Command]
    void OnMouseExit(){
        if(!clicked){
            tmp.GetComponent<SpriteRenderer>().color = Color.clear;
        }else{
            tmp.GetComponent<SpriteRenderer>().color = startColor;
        }
    }

    [Command]
    void OnMouseOver(){
        tmp.GetComponent<SpriteRenderer>().color = startColor;
    }

    [Command]
    void OnMouseDown(){
        tmp.GetComponent<BoxCollider2D>().enabled = false;
        clicked = true;
        BoardManager.Instance.AddLine((int)gameObject.transform.position.x + 2, (int)gameObject.transform.position.y + 2);
    }
}
