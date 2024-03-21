using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;
public class Launch1 : MonoBehaviour
{
    private GameObject[] Players; // Liste des joueurs. 
    private int PlayerInCircle; // Nombre de joueur dans le cercle.
    private int MaxPlayer; // Nombre de joueur dans la partie.
    private bool TimerOn; // Timer activé ou non
    private float TimeLeft; // Temps qui s'affiche
    public TextMeshProUGUI tex; // Object text.
    private bool loading = true;
    void Start()
    {
        tex.enabled = false;
        TimerOn = false;
        PlayerInCircle = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            PlayerInCircle++;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            PlayerInCircle--;
        }
    }
    void Update()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        MaxPlayer = Players.Length;
        if (TimerOn)
        {
            if (TimeLeft < 1 && loading)  // On change de scene si le temps arrive à 0.
            {
                loading = false;
                StartCoroutine(LoadScene());
            }
            else if (!Valid1(PlayerInCircle, MaxPlayer)) 
            {
                TimerOn = false;
                tex.enabled = false;
            }
            else if (Valid2(PlayerInCircle, MaxPlayer) && TimeLeft > 30)
            {
                TimeLeft = 30;
            }
            else if (Valid3(PlayerInCircle, MaxPlayer) && TimeLeft > 10)
            {
                TimeLeft = 10;
            }
            TimeLeft -= Time.deltaTime;
            Timer(Mathf.FloorToInt(TimeLeft));
        }
        else if (Valid1(PlayerInCircle, MaxPlayer)) // On définit le temps et le décompte en fonction du nombre de joueur dans le cercle.
        {
            TimerOn = true;
            tex.enabled = true;
            if (Valid2(PlayerInCircle, MaxPlayer))
                if (Valid3(PlayerInCircle, MaxPlayer))
                    TimeLeft = 10;
                else TimeLeft = 30;
            else TimeLeft = 60;
        }
    }

    // Valid1 renvoit s'il y'a autant de joueur dans le cercle que dans la partie.
    private bool Valid3(int player, int MaxPlayer) 
    {
        if (player == MaxPlayer)
            return true;
        return false;
    }
    // Valid2 renvoit s'il y'a le 3/4 des joueurs de la partie dans le cercle.
    private bool Valid2(int player, int MaxPlayer)
    {
        if (player >= (MaxPlayer/4)*3 + MaxPlayer%2)
            return true;
        return false;
    }
    // Valid3 renvoit s'il y'a la moitié des joueurs de la partie dans le cercle.
    private bool Valid1(int player, int MaxPlayer)
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

    IEnumerator LoadScene()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MAP1", LoadSceneMode.Additive);
        // On envoit tous les joueurs dans la scene chargée.

        // On attend que la scène soit bien chargée.
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        float posz = 0;
        foreach (GameObject joueur in Players)
        {   
            joueur.transform.position = new Vector3(-51, 17.65f, -10 + posz);
            SceneManager.MoveGameObjectToScene(joueur, SceneManager.GetSceneByName("MAP1"));
            posz += 10;
        }   
        
        // On décharge la scène du lobby
        SceneManager.UnloadSceneAsync(CurrentScene);
    }
}
