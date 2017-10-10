using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClick : MonoBehaviour {
    public Sound_Script sound;
    void Awake() { }
    void Start()
    {
        sound.LoopSound();
    }
    public void StartBtn()
    {
        sound.BtnSound();
        Invoke("startGame", .5f);
    }
    public void EndBtn()
    {
        sound.BtnSound();
        Invoke("EndGame", .5f);
    }
    void startGame()
    {
        PlayerPrefs.SetInt("blue", 0);
        PlayerPrefs.SetInt("gray", 0);
        PlayerPrefs.SetInt("green", 0);
        PlayerPrefs.SetInt("boss", 0);
        PlayerPrefs.SetInt("count", 0);
        //initialize key informations
        SceneManager.LoadScene("First_Step");
    }
    void EndGame()
    {
        Application.Quit();
    }
    
}
