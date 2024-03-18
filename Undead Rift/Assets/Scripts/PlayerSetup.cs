using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{   
    
    [SerializeField] Behaviour[] ToDisableOnline;
    [SerializeField] GameObject ToDisableLocal;


    void Start()
    {
        // Si ce n'est pas le joueur local, on désactive ses composants.
        if (!isLocalPlayer) 
        {
            for (int i = 0; i < ToDisableOnline.Length; i++) 
            {
                ToDisableOnline[i].enabled = false;
            }
        }
        else 
        {
            ToDisableLocal.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
