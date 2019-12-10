using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;


public class LineDisplay : MonoBehaviourPunCallbacks
{
    private Color startColor;
    private bool clicked = false;
    private GameObject tmp;
    private bool turn;
    // Start is called before the first frame update
    void Start()
    {
        turn = true;
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
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ColorWhite", RpcTarget.All, null);
    }

    [PunRPC]
    void ColorWhite(){
        GetComponent<SpriteRenderer>().color = startColor;
        GetComponent<BoxCollider2D>().enabled = false;
        BoardManager.Instance.AddLine((int)gameObject.transform.position.x + 2, (int)gameObject.transform.position.y + 2);
        clicked = true;
    }
}
