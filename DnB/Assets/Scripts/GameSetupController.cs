using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;
public class GameSetupController : MonoBehaviourPunCallbacks
{
    public GameObject player;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer(){
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer1"), Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
