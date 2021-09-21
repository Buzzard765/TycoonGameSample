using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllUIButtonScript : MonoBehaviour {

    public bool pause;
    public GameObject PausePanel;
    public GameObject LevelSelectPanel;
    public GameObject Guide;
    public CustomerSpawning cs;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PauseButton()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        else if (!pause) {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
    }

    public void confirmQuit() {
        SceneManager.LoadScene("StartMenu");
    }

    public void goBack() {
        gameObject.SetActive(false);
    }

    public void Encyclopedia() {
        Guide.SetActive(false);
    }

    public void LevelSelect() {
        LevelSelectPanel.SetActive(true);
    }

    public void BackFromLevelSelect() {
        LevelSelectPanel.SetActive(false);
    }

    public void BackFromEnc() {
        Guide.SetActive(false);
    }

    public void Sunrise() {
        SceneManager.LoadScene("Level 1");
    }

    public void Day() {
        SceneManager.LoadScene("Level 2"); 
    }

    public void Sunset() {
        SceneManager.LoadScene("Level 3");
    }

    public void Night() {
        SceneManager.LoadScene("Level 4");
    }


}
