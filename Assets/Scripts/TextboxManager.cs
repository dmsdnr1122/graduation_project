using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TextboxManager : MonoBehaviour {
	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;
	public int isendflag = 0;
	//public PlayerController player;

	// Use this for initialization
	void Start () {
		//player = FindObjectOfType<PlayerController> ();

		if (textFile != null)
		{
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0)
		{
			endAtLine = textLines.Length - 1;
		}
	}

	void Update()
	{
		theText.text = textLines [currentLine];
	}

	public void ToRightPage() {
		if (currentLine < endAtLine) currentLine += 1;
		if (currentLine == endAtLine) gameObject.GetComponent<GUIManager>().enabled = true;
	}
	public void ToLeftPage() {
		if (currentLine > 0) currentLine -= 1;
		if (currentLine != endAtLine) gameObject.GetComponent<GUIManager>().enabled = false;
	}
}
