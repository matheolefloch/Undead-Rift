using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;
public class Launch1 : MonoBehaviour
{
    private int player;
    [SerializeField] CountPlayer pl;
    private int MaxPlayer;
    private bool TimerOn;
    private float TimeLeft;
    public TextMeshProUGUI tex;
    void Start()
    {
        TimerOn = false;
        player = 0;
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
    void Update()
    {
        MaxPlayer = pl.FindPlayersByTag();
        if (TimerOn)
        {
            if (TimeLeft < 1) 
            {
                SceneManager.LoadScene("MAP1");
            }
            else if (!Valid1(player, MaxPlayer)) 
            {
                TimerOn = false;
                tex.enabled = false;
            }
            else if (Valid2(player, MaxPlayer) && TimeLeft > 30)
            {
                TimeLeft = 30;
            }
            else if (Valid3(player, MaxPlayer) && TimeLeft > 10)
            {
                TimeLeft = 10;
            }
            TimeLeft -= Time.deltaTime;
            Timer(Mathf.FloorToInt(TimeLeft));
        }
        else if (Valid1(player, MaxPlayer))
        {
            TimerOn = true;
            TimeLeft = 60;
            tex.enabled = true;
        }
        else if (Valid2(player, MaxPlayer))
        {
            TimerOn = true;
            TimeLeft = 30;
            tex.enabled = true;
        }
                else if (Valid1(player, MaxPlayer))
        {
            TimerOn = true;
            TimeLeft = 10;
            tex.enabled = true;
        }
    }

    private bool Valid1(int player, int MaxPlayer)
    {
        if (player == MaxPlayer)
            return true;
        return false;
    }

    private bool Valid2(int player, int MaxPlayer)
    {
        if (player >= (MaxPlayer/4)*3 + MaxPlayer%2)
            return true;
        return false;
    }
    private bool Valid3(int player, int MaxPlayer)
    {
        if (player >= MaxPlayer/2 + MaxPlayer%2)
            return true;
        return false;
    }

    void Timer(int tim) 
    {
        if (tim == 1 || tim == 0)
            tex.text = $"Lancement dans {tim} seconde.";
        else tex.text = $"Lancement dans {tim} secondes.";
    }
}
