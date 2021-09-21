using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionButtons : MonoBehaviour {

   // public Image[] SelectionImage;
    public List<GameObject> CuisineList = new List<GameObject>();
    public DataModel dm;
    
    private int imageIndex = 0;


    /* public void slideLeft()
     {
         Debug.Log("Previous");
         if (imageIndex > 0)
         {
             imageIndex++;
             SelectionImage[imageIndex].sprite = CuisineList[imageIndex].sprite;
         }
     }

     public void slideRight()
     {
         Debug.Log("Next");
         if (imageIndex < CuisineList.Count - 1)
         {
             imageIndex--;
             //SelectionImage.sprite = Sprite;
             SelectionImage[imageIndex].sprite = CuisineList[imageIndex].sprite;
         }
     }*/

    /*private void Awake()
    {
        Cuisine = new List<Image>();
        for(int i=0; i < Image.;)
    }*/

    void Start()
    {
        dm = GameObject.Find("AllFoodBuyButton").GetComponent<DataModel>();
        foreach (GameObject gmobj in CuisineList) { //Setiap Gameobject yg dimasukkan ke dlm List,
            gmobj.SetActive(false); // matikan
        }
        CuisineList[imageIndex].SetActive(true); //Nyalakan yang sedang aktif di index yg diinput

    }

    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
		
	}


    public void NextButton() {
        CuisineList[imageIndex].SetActive(false);
        imageIndex++; //Ganti index gambar yg dimasukkan
        dm.SelectMenu++; //akses int dr DataModel utk memindahkan seleksi
        if (imageIndex >= CuisineList.Count) { //Jika sudah mentok di Index terakhir,
            imageIndex = 0;
            dm.SelectMenu=0; //Mulai Dari Index Array Awal
        }
        CuisineList[imageIndex].SetActive(true);
    }

    public void PrevButton()
    {
        CuisineList[imageIndex].SetActive(false);
        imageIndex--;
        dm.SelectMenu--; //akses int dr DataModel utk memindahkan seleksi
        if (imageIndex < 0) //Jika sudah mentok di Index awal,
        {
            imageIndex = CuisineList.Count-1;
            dm.SelectMenu = CuisineList.Count - 1; //Ke Index terakhir
        }
        CuisineList[imageIndex].SetActive(true);
    }

}
