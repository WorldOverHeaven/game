using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

    public void SpawnBox()//spawn new box
    {
        GameObject box_Obj = Instantiate(box_Prefab);//makes clone
        //box_Obj.transform.position = new Vector3(transform.position.x, transform.position.y, 0);


        Vector3 temp = transform.position;
        temp.z = 0f;

        temp.x = Random.Range(-24, 24) / 10;

        box_Obj.transform.position = temp;  
    }
}
