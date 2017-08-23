using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;
using MySql.Data.MySqlClient;

public class PluginTest : MonoBehaviour
{

    public Lancekun_Go_Main obj;
    //Obj Class
    public Obj_Set Obj_ALU_;
    public Obj_Set Obj_Lance_;

    //Wifi Check Number
    int Num1, Num2, Num3;
    //타이밍용
    float nexttime = 0.0f;
    
    //String 분류 변수들
    string[] temp;
    string str = "init";
    char ch = '/';

    //Sphere sph = new Sphere();

    //DB Types
    MysqlDB mysqlDB = new MysqlDB();
    DataTable dt;
    DataRow[] data;

    //Constant
    int i = 0;

    void Start()
    {
        Obj_ALU_.Obj_False();
        Obj_Lance_.Obj_False();
        dt = mysqlDB.selsql("SELECT * FROM test");
        data = dt.Select();
    }

    bool CheckWifiRssi(int Num1, int Num2, int Num3, int i)
    {

        if(Num1 < (int.Parse(data[i]["Rssi01"].ToString()) + 3) && Num1 > (int.Parse(data[i]["Rssi01"].ToString()) - 3))
        {
            if (Num2 < (int.Parse(data[i]["Rssi02"].ToString()) + 3) && Num2 > (int.Parse(data[i]["Rssi02"].ToString()) - 3))
            {
                if (Num3 < (int.Parse(data[i]["Rssi03"].ToString()) + 3) && Num3 > (int.Parse(data[i]["Rssi03"].ToString()) - 3))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void CreateObj(int i)
    {
        if(i == 0)
        {
            Obj_ALU_.Obj_True();
            gameObject.GetComponent<Btn_Create>().enabled = true;
            obj.Test();
        }
        if (i == 1)
        {
            Obj_ALU_.Obj_True();
            gameObject.GetComponent<Btn_Create>().enabled = true;
            obj.Test();
        }
        if (i == 2)
        {
            Obj_ALU_.Obj_True();
            gameObject.GetComponent<Btn_Create>().enabled = true;
            obj.Test();
        }
        if (i == 3)
        {
            Obj_ALU_.Obj_True();
            gameObject.GetComponent<Btn_Create>().enabled = true;
            obj.Test();
        }
    }

    void InsertDB()
    {
        using (AndroidJavaObject myObj = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (AndroidJavaObject wifiManager = myObj.Call<AndroidJavaObject>("getSystemService", myObj.GetStatic<string>("WIFI_SERVICE")))
            {
                using (AndroidJavaObject activity = new AndroidJavaObject("com.test.unitytest.test"))
                {
                    str = activity.Call<string>("setWifiManager", wifiManager);
                    temp = str.Split(ch);

                    Num1 = int.Parse(temp[1]);
                    Num2 = int.Parse(temp[2]);
                    Num3 = int.Parse(temp[3]);

                    while (i < 4)
                    {
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

    void Update()
    {
        if (Time.time > nexttime)
        {
            nexttime = Time.time + 2.0f;
            InsertDB();
        }
    }
}



