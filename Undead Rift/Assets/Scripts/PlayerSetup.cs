using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{   
    
    [SerializeField] Behaviour[] ToDisableOnline;
    [SerializeField] Behaviour[] ToDisableLocal;


    void Start()
    {
        // Si ce n'est pas le joueur local, on désactive ses composants.
        if (!isLocalPlayer) 
        {
            foreach (var c in ToDisableOnline)
                c.enabled = false;
        }
        else 
        {
            foreach (var c in ToDisableLocal)
                c.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
