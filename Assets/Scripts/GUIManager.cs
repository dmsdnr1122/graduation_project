using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {
    public Sound_Script sound;
	
    public void Game_end()
    {
        sound.BtnSound();
        SceneManager.LoadScene("End");
    }
}
