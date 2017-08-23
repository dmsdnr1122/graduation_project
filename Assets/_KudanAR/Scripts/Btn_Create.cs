using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_Create : MonoBehaviour {

    public Obj_Set Obj_ALU_;
    public Obj_Set Obj_Lance_;

    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 300, 300, 400), "A에게 Hint를 얻을려면 Click"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
