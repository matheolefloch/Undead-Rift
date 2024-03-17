using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{   
    
    [SerializeField] Behaviour[] ToDisable;
    [SerializeField] GameObject ToEnable;


    void Start()
    {
        // Si ce n'est pas le joueur local, on désactive ses composants.
        if (!isLocalPlayer) 
        {
            for (int i = 0; i < ToDisable.Length; i++) 
            {
                ToDisable[i].enabled = false;
            }
        }
        else 
        {
            ToEnable.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
