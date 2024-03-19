using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{   
    
    [SerializeField] GameObject[] ToDisableOnline;
    [SerializeField] Behaviour[] ToDisableOnlineBH;
    [SerializeField] GameObject ToDisableLocal;


    void Start()
    {
        // Si ce n'est pas le joueur local, on désactive ses composants.
        if (!isLocalPlayer) 
        {
            foreach (var c in ToDisableOnline )
                c.SetActive(false);
            foreach (var c in ToDisableOnlineBH)
                c.enabled = false;
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
