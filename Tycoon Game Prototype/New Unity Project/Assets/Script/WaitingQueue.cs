using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue : MonoBehaviour {

    public List<GameObject> Customer;
    public Queue<GameObject> WaitingLine;
    public Vector3 QueuePosition;

    private GameObject temp;
    private int Rand;

     private void Awake()
     {
         WaitingLine = new Queue<GameObject>();

         for (int a = 0; a <= 5; a++) {
            Rand = Random.Range(0, Customer.Count);
            temp = Instantiate(Customer[Rand], new Vector3((float)-a/2,0,0), Customer[Rand].transform.rotation);
            WaitingLine.Enqueue(temp);
         } 
     }

    //utk Construct yg nanti menerima list posisi dr QueueHandler
    /*public WaitingQueue(List<Vector3> Customer) {
        this.Customer = Customer;
        QueuePosition = Customer[Customer.Count-1] + new Vector3(-3f, 0);
        foreach (Vector3 position in Customer) {
            //fungsi utk meng spawn random customer
        }
        


    }*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Invoke("CustomerEnqueue", 3f);
	}

    public void CustomerEnqueue() {
        Rand = Random.Range(0, Customer.Count);
        temp = Instantiate(Customer[Rand], new Vector3((float)WaitingLine.Count/ 2, 0, 0), Customer[Rand].transform.rotation);
        WaitingLine.Enqueue(temp);
    }

    public void CustomerDequeue()
    {
        temp = (GameObject)WaitingLine.Dequeue();
        GameObject.Destroy(temp);
        ResetQueuePos();
    }

    public void ResetQueuePos() {
        GameObject[] TempList = new GameObject[WaitingLine.Count];
        WaitingLine.CopyTo(TempList, 0);

        for (int x = 0; x < TempList.Length; x++) {
            TempList[x].transform.position = new Vector2(-(float)x / 2, 0); 
        }
    }


}
