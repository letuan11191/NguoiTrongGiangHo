using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickReset()
    {
        SceneManager.LoadScene("Login");
    }
    public void ClickMenu()
    {
        Time.timeScale = 0;
        GameObject.Find("Main Camera").GetComponent<Game>().Canvas_GameOver.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<Game>().BtnContinue.SetActive(true);
    }
    public void CLickContinue()
    {
        Time.timeScale = 1;
        GameObject.Find("Main Camera").GetComponent<Game>().Canvas_GameOver.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<Game>().BtnContinue.SetActive(false);
    }
}
