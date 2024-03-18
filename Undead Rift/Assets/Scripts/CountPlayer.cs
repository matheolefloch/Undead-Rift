using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CountPlayer : MonoBehaviour
{   
    public GameObject[] playersArray;

    public int FindPlayersByTag()
    {
        playersArray = GameObject.FindGameObjectsWithTag("Player");
        return playersArray.Length;
    }
    // Update is called once per frame

}
