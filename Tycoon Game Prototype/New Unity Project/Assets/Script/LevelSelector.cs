using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] unlockedlevels;
    public int levelReached;

    // Use this for initialization
    void Start () {
        //PlayerPrefs.SetInt("levelReached", 1);
    }

    // Update is called once per frame
    void Update () {
        levelReached = PlayerPrefs.GetInt("levelReached", 1);
        Debug.Log(PlayerPrefs.GetInt("levelReached"));
        for (int i = 0; i < unlockedlevels.Length; i++)
        {            
            if (i + 1 > levelReached)
            {
                unlockedlevels[i].interactable = false;                               
            }           
        }        
    }

    public void SelectionButtons(string levelName)
    {

    }
}
