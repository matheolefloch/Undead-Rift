using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{   
    
    [SerializeField] GameObject ToDisableOnline;
    [SerializeField] GameObject ToDisableLocal;


    void Start()
    {
        // Si ce n'est pas le joueur local, on désactive ses composants.
        if (!isLocalPlayer) 
        {
            ToDisableOnline.SetActive(false);
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
