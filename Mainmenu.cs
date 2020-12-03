using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour {
    public Text HighscoreText;
	// Use this for initialization
	void Start () {
        HighscoreText.text = "High score : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ToGame()
    {
        SceneManager.LoadScene("Sccene");
    }
}
