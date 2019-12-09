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
        Destroy(this.gameObject);
        BoardManager.Instance.CmdAddLine((int)gameObject.transform.position.x + 2, (int)gameObject.transform.position.y + 2);
    }
}
