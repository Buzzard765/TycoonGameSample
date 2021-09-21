using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    
    public int rice = 0;
    public int Meat = 0;
    public int Egg = 0;
    public int Peanut = 0;
    public int Coconut = 0;
    public int Tofu = 0;
    int amount = 0;
    public static GameManager GM;
    [SerializeField]int money;
    [SerializeField] int price;
    public Text MoneyText;

	// Use this for initialization
	void Start () {
        GM = this;
        UIUpdate();
        MoneyText = GameObject.Find("Money").GetComponent<Text> ();

    }
	
	// Update is called once per frame
	void Update () {
  
    }

    public void addRice() {
        rice += 1;
        amount = rice * 10000;
    }

    public void addEgg() {
        Egg += 1;
        amount = Egg * 10000;
    }
    public void addMeat() {
        Meat += 1;
        amount = Meat * 10000;
    }
    public void addPeanut() {
        Peanut += 1;
        amount = Peanut * 10000;
    }
    public void addCcnt() {
        Coconut += 1;
        amount = Coconut * 10000;
    }
    public void addTfTmp() {
        Tofu += 1;
        amount = Tofu * 10000;
    }

    public void AddPrice() {
        price += amount;
        UIUpdate();
    }

    public void ReduceMoney() {
        money -= amount;
        UIUpdate();
    }

    

    void UIUpdate() {
        MoneyText.text = "Rp. " + money.ToString();
    }
}
