using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

	void OnGUI() {
		if (GUI.Button (new Rect (150, 150, 150, 70), "대화에서 벗어나기"))
        {
            SceneManager.LoadScene(0);
		}
	}
}
