using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Launch1 : MonoBehaviour
{
    private int player;
    [SerializeField] CountPlayer pl;
    private int MaxPlayer;
    private bool TimerOn;

    void Start()
    {
        TimerOn = false;
        player = 0;
        MaxPlayer = pl.players;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            player++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            player--;
        }
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
         {
            Debug.Log("ça marche");
        }
        else if (player >= MaxPlayer/2)
            {
                TimerOn = true;
            }
    }
}
