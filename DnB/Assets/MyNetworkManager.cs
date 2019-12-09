using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : MonoBehaviour 
{
    public GameObject treePrefab;
    NetworkClient myClient;

    // Create a client and connect to the server port
    public void ClientConnect() {
        ClientScene.RegisterPrefab(treePrefab);
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnClientConnect);
        myClient.Connect("127.0.0.1", 4444);
    }

    void OnClientConnect(NetworkMessage msg) {
        Debug.Log("Connected to server: " + msg.conn);
    }

    public void ServerListen() {
    NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnect);
    NetworkServer.RegisterHandler(MsgType.Ready, OnClientReady);
    if (NetworkServer.Listen(4444))
        Debug.Log("Server started listening on port 4444");
}

// When client is ready spawn a few trees
void OnClientReady(NetworkMessage msg) {
    Debug.Log("Client is ready to start: " + msg.conn);
    NetworkServer.SetClientReady(msg.conn);
    SpawnTrees();
}

void SpawnTrees() {
    int x = 0;
    for (int i = 0; i < 5; ++i) {
        var treeGo = Instantiate(treePrefab, new Vector3(x++, 0, 0), Quaternion.identity);
        NetworkServer.Spawn(treeGo);
    }
}

void OnServerConnect(NetworkMessage msg) {
    Debug.Log("New client connected: " + msg.conn);
}

}
