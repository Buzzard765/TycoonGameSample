using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour {

    GameManager GM;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void buyRice()
    {
        Debug.Log("you bought a material");
        GM.ReduceMoney();
    }

    public void buyCcnt() {
        GM.ReduceMoney();
        GM.addCcnt(); 
    }
    public void buyPnt() {
        GM.ReduceMoney();
        GM.addPeanut();
    }
    public void buyMeat() {
        GM.ReduceMoney();
        GM.addMeat();
    }
    public void buyEgg() {
        GM.ReduceMoney();
        GM.addEgg();

    }
    public void buyTofu() {
        GM.ReduceMoney();
        GM.addTfTmp();

    }
}
