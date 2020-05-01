using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;

public class NameChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int pNum = Player.Instance.ActorNumber;
        Debug.Log(pNum);
    }

    // Update is called once per frame
    void Update()
    {
        int pNum = Player.Instance.ActorNumber;
        Debug.Log(pNum);
    }
}
