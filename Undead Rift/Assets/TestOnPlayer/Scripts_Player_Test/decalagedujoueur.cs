using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decalagedujoueur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "decalage";
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 30.0f, 0);
    }
}
