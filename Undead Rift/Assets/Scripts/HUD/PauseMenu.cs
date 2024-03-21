using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PauseMenu : NetworkBehaviour
{
    public static bool GamePause = false;
    private NetworkManager networkManager;
    public GameObject MenuUI;
    public Behaviour ShootScript;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GamePause)
            {
                MenuUI.SetActive(false);
                ShootScript.enabled = true;
                Locke();
            }
            else 
            {
                ShootScript.enabled = false;
                MenuUI.SetActive(true);
                Delocke();
            }
        }
    }
    public void Locke() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GamePause = false;
    }

    public void Delocke() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GamePause = true;
    }

    public void Leave() 
    {
        if (!isClientOnly) 
        {
            networkManager.StopHost();
        }
        else 
        {   
            networkManager.StopClient();
        }
    }
}
