using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class accelation_speed : MonoBehaviour
{
    public Text text;

    void FixedUpdate()
    {
        using (AndroidJavaObject myObj = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (AndroidJavaObject LocationManager = myObj.Call<AndroidJavaObject>("getSystemService", myObj.GetStatic<string>("LOCATION_SERVICE")))
            {
                using (AndroidJavaObject activity = new AndroidJavaObject("com.test.unitytest.test"))
                {
                    text.text = "speed : " + activity.Call<double>("location");

                }
            }
        }
    }

}

