using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class EndTakScene : MonoBehaviour
{
    public GameObject textBox;
    public GameObject ToKudan;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;
    public int isendflag = 0;
    //public PlayerController player;
    public Sound_Script sound;

    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController> ();
        sound.LoopSound();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        theText.text = textLines[currentLine];
    }

    public void ToRightPage()
    {
        if (currentLine == 2)
        {
            sound.UnlockSound();
        }
        if (currentLine < endAtLine)
        {
            sound.BtnSound();
            currentLine += 1;
        }
        if (currentLine == endAtLine) ToKudan.SetActive(true);
    }
    public void ToLeftPage()
    {
        if (currentLine > 0)
        {
            sound.BtnSound();
            currentLine -= 1;
        }
        if (currentLine != endAtLine) ToKudan.SetActive(false);
    }
    public void GoKudan()
    {
        sound.BtnSound();
        Destroy(GameObject.Find("GameController"));
        Destroy(GameObject.Find("Markless_Driver"));
        Destroy(GameObject.Find("Kudan Camera"));
        SceneManager.LoadScene("End");
    }
}
