using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CountPlayer : NetworkBehaviour
{
    public int players;
    // Start is called before the first frame update
    void Start()
    {
        players = 1;
    }

    void OnClientConnect()
    {
        players++;
    }
    void OnClientDisconnect()
    {
        players--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
