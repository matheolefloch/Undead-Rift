using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetString : MonoBehaviour
{
    public TMP_InputField field;
    public string connec()
    {
           return field.text;
    }
    void Start()
    {
        
    }//Test

    // Update is called once per frame
    void Update()
    {
        
    }
}
