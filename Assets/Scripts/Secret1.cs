using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Secret1 : MonoBehaviour
{


    private int count = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void NewSp()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    private void OnMouseDown()
    {
        count -= 1;
        if (count == 0)
        {
            count = 3;
            NewSp();
            //Ivoke("OldSp", 5f);
        }
    }
}
