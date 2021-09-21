using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour {

    public Text TimerText;
    public float LevelTimeLimit;
    private bool FullTime = false;
    
    public GameObject[] ObjPrefabs;
   

    [System.Serializable]
    public class myPool{
        public string tag;
        public GameObject Customer;
        public int ServiceTime;
    }

    public List<GameObject> CustomerPool;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

	// Use this for initialization
	void Start () {
        GetCust();
    }
	
	// Update is called once per frame
	/*void Update () {
		
	}*/


    public void GetCust()
    {
        for (int i = 0; i < ObjPrefabs.Length; i++)
        {

            GameObject newObject = (GameObject)Instantiate(ObjPrefabs[Random.Range(0, ObjPrefabs.Length)], Vector3.right, Quaternion.identity);
            newObject.SetActive(false);
            CustomerPool.Add(newObject);
            //
        }


    }

}
