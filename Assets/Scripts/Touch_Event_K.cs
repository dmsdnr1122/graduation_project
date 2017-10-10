using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Touch_Event_K : MonoBehaviour {

    public ToastMessage toast;
    public Image bluekey;
    public Image graykey;
    public Image greenkey;
    public Button markerless_B;
    public Button marker_B;
    public Image markerless_I;
    public Image marker_I;
    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetInt("blue") == 0)
            bluekey.enabled = false;
        else
            bluekey.enabled = true;

        if (PlayerPrefs.GetInt("gray") == 0)
            graykey.enabled = false;
        else
            graykey.enabled = true;

        if (PlayerPrefs.GetInt("green") == 0)
            greenkey.enabled = false;
        else
            greenkey.enabled = true;
        //for key activate
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //MARKER_OBJECT
                //marker target name =>  a머시기 : key1, visual studio : key2, hello world : key3
                //MARKER에서 클릭했을때 KEY FLAG 1로 된다. NOT MARKERLESS..
                
                if (hit.transform.name == "key1")
                {
                    toast.MyShowToastMethod("key1 is detected");
                    PlayerPrefs.SetInt("blue", 1);
                }
                if(hit.transform.name == "key2")
                {
                    toast.MyShowToastMethod("key2 is detected");
                    PlayerPrefs.SetInt("gray", 1);
                }
                if (hit.transform.name == "key3")
                {
                    toast.MyShowToastMethod("key3 is detected");
                    PlayerPrefs.SetInt("green", 1);
                }
                if (hit.transform.name == "DoorKnob" && PlayerPrefs.GetInt("blue") == 1 && PlayerPrefs.GetInt("green") == 1 && PlayerPrefs.GetInt("gray") == 1)
                {
                    marker_B.enabled = false;
                    marker_I.enabled = false;
                    markerless_B.enabled = false;
                    markerless_I.enabled = false;
                    SceneManager.LoadScene("Final_Step");
                }

                ///////////////////////////////////////////////
                //MARKERLESS_OBJECT
                if (hit.transform.name == "ALU_Animated")
                {
                    marker_B.enabled = false;
                    marker_I.enabled = false;
                    markerless_B.enabled = false;
                    markerless_I.enabled = false;
                    SceneManager.LoadScene("HintScene_A");
                }
                if (hit.transform.name == "IAND_Animated")
                {
                    marker_B.enabled = false;
                    marker_I.enabled = false;
                    markerless_B.enabled = false;
                    markerless_I.enabled = false;
                    SceneManager.LoadScene("HintScene_B");
                }
                if (hit.transform.name == "R2D2_Animated")
                {
                    marker_B.enabled = false;
                    marker_I.enabled = false;
                    markerless_B.enabled = false;
                    markerless_I.enabled = false;
                    SceneManager.LoadScene("HintScene_C");
                }
                if (hit.transform.name == "SpiderTak")
                {
                    if(PlayerPrefs.GetInt("blue") == 1 && PlayerPrefs.GetInt("green") == 1 && PlayerPrefs.GetInt("gray") == 1)
                    {
                        marker_B.enabled = false;
                        marker_I.enabled = false;
                        markerless_B.enabled = false;
                        markerless_I.enabled = false;
                        SceneManager.LoadScene("EndTak");
                    }
                    else
                    {
                        marker_B.enabled = false;
                        marker_I.enabled = false;
                        markerless_B.enabled = false;
                        markerless_I.enabled = false;
                        SceneManager.LoadScene("Tak");
                    }
                }
                
            }
        }

	}
}