using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;
using Kudan.AR;

public class PluginTest : MonoBehaviour
{
    //Don't destroy object
    public GameObject Gobj1;
    public GameObject Gobj2;
    public GameObject Gobj3;

    public Button markerless_B;
    public Button marker_B;
    public Image markerless_I;
    public Image marker_I;

    public Kudan_Main obj;

    //Obj Class
    public Obj_Set Obj_ALU_;
    public Obj_Set Obj_IAND_;
    public Obj_Set Obj_R2D2_;
    public Obj_Set Obj_SpiderTak_;
    
    //타이밍용
    float nexttime = 0.0f;
    
    //String 분류 변수들
    string[] temp;
    string str = "init";
    char ch = '/';

    //DB Types
    MysqlDB mysqlDB = new MysqlDB();
    DataTable dt;
    DataRow[] data;

    //Constant
    int i = 0;
    bool boolean = false;

    
    void OnLevelWasLoaded()
    {
        Obj_ALU_.Obj_False();
        Obj_IAND_.Obj_False();
        Obj_R2D2_.Obj_False();
        Obj_SpiderTak_.Obj_False();
    }
    

    void Awake()
    {
        GameObject.Find("Camera_Btn_Markerless").SetActive(true);
        GameObject.Find("Camera_Btn_Marker").SetActive(true);
        Obj_ALU_.Obj_False();
        Obj_IAND_.Obj_False();
        Obj_R2D2_.Obj_False();
        Obj_SpiderTak_.Obj_False();

        DontDestroyOnLoad(Gobj1);
        DontDestroyOnLoad(Gobj2);
        DontDestroyOnLoad(Gobj3);

    }
    
    //Btn method
    public void Btn_method()
    {
        if (boolean)
        {
            obj.MarkerlessClicked();
            markerless_B.enabled = false;
            markerless_I.enabled = false;
            marker_B.enabled = true;
            marker_I.enabled = true;
            boolean = false;
        }
        else
        {
            obj.MarkerClicked();
            marker_B.enabled = false;
            marker_I.enabled = false;
            markerless_B.enabled = true;
            markerless_I.enabled = true;
            boolean = true;
        }
    }

    void Start()
    {
        
    }

    public bool CheckWifiRssi(int Num1, int Num2, int Num3, int i)
    {
        if (Num1 < (int.Parse(data[i]["Rssi01"].ToString()) + 7) && Num1 > (int.Parse(data[i]["Rssi01"].ToString()) - 7))
        {
            if (Num2 < (int.Parse(data[i]["Rssi02"].ToString()) + 7) && Num2 > (int.Parse(data[i]["Rssi02"].ToString()) - 7))
            {
                if (Num3 < (int.Parse(data[i]["Rssi03"].ToString()) + 7) && Num3 > (int.Parse(data[i]["Rssi03"].ToString()) - 7))
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    /*
     * 삼변측량
    public bool Checkaxis(double x, double y, int i)
    {
        if (x < (int.Parse(data[i]["x"].ToString()) + 1) && x > (int.Parse(data[i]["x"].ToString()) - 1))
        {
            if (y < (int.Parse(data[i]["y"].ToString()) + 1) && y > (int.Parse(data[i]["y"].ToString()) - 1))
            {
                return true;
            }
        }
        return false;
    }
    */

    public void CreateObj(int i)
    {
        
        if(i == 0)
        {
            if(PlayerPrefs.GetInt("count") == 0)
            {
                Obj_ALU_.Obj_True();
                obj.Target_Node();
                obj.Markerless_Start();
                int temp = PlayerPrefs.GetInt("count");
                temp++;
                PlayerPrefs.SetInt("count", temp);
            }
            
        }
        if (i == 1)
        {
            if (PlayerPrefs.GetInt("count") == 1)
            {
                Obj_IAND_.Obj_True();
                obj.Target_Node();
                obj.Markerless_Start();
                int temp = PlayerPrefs.GetInt("count");
                temp++;
                PlayerPrefs.SetInt("count", temp);
            }
        }
        if (i == 2)
        {
            if (PlayerPrefs.GetInt("count") == 2)
            {
                Obj_R2D2_.Obj_True();
                obj.Target_Node();
                obj.Markerless_Start();
                int temp = PlayerPrefs.GetInt("count");
                temp++;
                PlayerPrefs.SetInt("count", temp);
            }
        }
        if (i == 3)
        {
            if (PlayerPrefs.GetInt("count") == 3)
            {
                Obj_SpiderTak_.Obj_True();
                obj.Target_Node();
                obj.Markerless_Start();
                int temp = PlayerPrefs.GetInt("count");
                temp++;
                PlayerPrefs.SetInt("count", temp);
            }
        }
    }


    public void Wifi_Rssi()
    {
        Obj_ALU_.Obj_False();
        Obj_IAND_.Obj_False();
        Obj_R2D2_.Obj_False();
        Obj_SpiderTak_.Obj_False();

        dt = mysqlDB.selsql("SELECT * FROM test");
        data = dt.Select();

        
        using (AndroidJavaObject myObj = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (AndroidJavaObject wifiManager = myObj.Call<AndroidJavaObject>("getSystemService", myObj.GetStatic<string>("WIFI_SERVICE")))
            {
                using (AndroidJavaObject activity = new AndroidJavaObject("com.test.unitytest.test"))
                {
                
                    str = activity.Call<string>("setWifiManager", wifiManager);
                    temp = str.Split(ch);
                    
                    
                    int Num1 = int.Parse(temp[1]);
                    int Num2 = int.Parse(temp[2]);
                    int Num3 = int.Parse(temp[3]);
                    
                    //d = 10 ^ ((TxPower - RSSI) / (10 * n)); n=3
                    //삼변측량 거리공식
                    /*
                    double distance1 = Math.Pow(10.0, (-40 - Num1) / 30.0); // 8b wifi 
                    double distance2 = Math.Pow(10.0, (-10 - Num2) / 30.0); // jinwoo
                    double distance3 = Math.Pow(10.0, (-10 - Num3) / 30.0); // sayho
                    */

                    while (i < 4)
                    {
                        /*
                        if(Checkaxis(Get_polynomial_xm(distance1, distance2, distance3, 0.0, 0.0, 20.0, 0.0, 30.0, 0.0),
                            Get_polynomial_ym(distance1, distance2, distance3, 0.0, 0.0, 20.0, 0.0, 30.0, 0.0), i))
                        {
                            CreateObj(i);
                            break;
                        }
                        */
                        
                        
                        if (CheckWifiRssi(Num1, Num2, Num3, i))
                        {
                            CreateObj(i);
                            break;
                        }
                        
                        i++;
                        
                    }

                    //reinitialize
                    i = 0;

                    //insert into DB
                    //mysqlDB.sqlcmdall("INSERT INTO test VALUES('" + temp[1] + "','" + temp[2] + "','" + temp[3] + "', '" + "null" + "')");
                }
            }
        }
    }

    void FixedUpdate()
    {
        Wifi_Rssi();
    }

    //for rssi calculating

    /* 삼변 측량 
    double Get_polynomial_xm(double d1, double d2, double d3, double x1, double x2, double x3, double y1, double y2, double y3)
    {
        double a12 = -2 * x1 + 2 * x2;
        double a13 = -2 * x1 + 2 * x3;
        double b12 = -2 * y1 + 2 * y2;
        double b13 = -2 * y1 + 2 * y3;
        double c12 = Math.Pow(d1,2.0) - Math.Pow(d2,2.0) - Math.Pow(x1,2.0) + Math.Pow(x2,2.0) - Math.Pow(y1,2.0) + Math.Pow(y2,2.0);
        double c13 = Math.Pow(d1,2.0) - Math.Pow(d3,2.0) - Math.Pow(x1,2.0) + Math.Pow(x3,2.0) - Math.Pow(y1,2.0) + Math.Pow(y3,2.0);
        if (b12 == 0)
        {
            return c12 / a12;
        }
        if (b13 == 0)
        {
            return c13 / a13;
        }
        return ((c12 * b13) / b12 - c13) / ((a12 * b13) / b12 - a13);
    }
    double Get_polynomial_ym(double d1, double d2, double d3, double x1, double x2, double x3, double y1, double y2, double y3)
    {
        double a12 = -2 * x1 + 2 * x2;
        double a13 = -2 * x1 + 2 * x3;
        double b12 = -2 * y1 + 2 * y2;
        double b13 = -2 * y1 + 2 * y3;
        double c12 = Math.Pow(d1, 2.0) - Math.Pow(d2, 2.0) - Math.Pow(x1, 2.0) + Math.Pow(x2, 2.0) - Math.Pow(y1, 2.0) + Math.Pow(y2, 2.0);
        double c13 = Math.Pow(d1, 2.0) - Math.Pow(d3, 2.0) - Math.Pow(x1, 2.0) + Math.Pow(x3, 2.0) - Math.Pow(y1, 2.0) + Math.Pow(y3, 2.0);
        if (a12 == 0)
        {
            return c12 / b12;
        }
        if (a13 == 0)
        {
            return c13 / b13;
        }
        return ((c12 * a13) / a12 - c13) / ((b12 * a13) / a12 - b13);
    }

    */

}



