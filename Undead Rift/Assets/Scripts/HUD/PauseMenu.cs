using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    
    public GameObject MenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GamePause)
            {
                MenuUI.SetActive(false);
                GamePause = false;
                Locke();
            }
            else 
            {
                MenuUI.SetActive(true);
                GamePause = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void Locke() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
