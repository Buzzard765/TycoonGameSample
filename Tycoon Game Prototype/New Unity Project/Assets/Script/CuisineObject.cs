using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "new Recipe", menuName = "Recipe")]
public class CuisineObject : ScriptableObject {

    public int Profit;
    public string FoodName;
    public GameObject Artwork;
    public int Amount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
