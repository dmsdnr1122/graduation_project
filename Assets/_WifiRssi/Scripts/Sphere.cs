using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour{
    public GameObject obj;

    void Start()
    {
        GameObject g_obj = Instantiate(obj, new Vector3(150 ,150,150), Quaternion.identity); 
    }
}
