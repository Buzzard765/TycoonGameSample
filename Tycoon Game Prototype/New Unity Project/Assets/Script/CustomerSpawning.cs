using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawning : MonoBehaviour {

    public GameObject[] Customer;
    
    public Transform SpawnSpot;
    public float TimeBtwnSpawn;
    public float StartBtwnSpawn;
    public float EndSpawn;
    public int RemainingCustomer;
    public Text RemainingText;

    CustomerMovement CM;

    public string nextlevel;
    public int LeveltoUnlock;

    [SerializeField]
    public Queue<GameObject> WaitingLine;
    

    private GameObject temp;
    private int Rand;

    public int TargetScore;
    public int customersleaving;
    public GameObject ResultPanel;
    public DataModel Evaluation;
    public GameObject[] Rank;

    public AudioSource[] BGM;
    public AudioSource LevelClearApplause;
    public AudioSource LevelFailedFart;
    public AudioSource Bell;

    private void Awake()
    {
        WaitingLine = new Queue<GameObject>();

        /*for (int a = 0; a <= 5; a++)
        {
            Rand = Random.Range(0, OrderSpot.Count);
            temp = Instantiate(OrderSpot[Rand], new Vector3(), OrderSpot[Rand].transform.rotation);
            WaitingLine.Enqueue(temp);
        }*/
    }

    // Use this for initialization
    void Start () {
        /*TimeBtwnSpawn = StartBtwnSpawn;
        Rand = Random.Range(0, OrderSpot.Count);
        temp = Instantiate(OrderSpot[Rand], new Vector3(), OrderSpot[Rand].transform.rotation);
        WaitingLine.Enqueue(temp);*/
        //RemainingText = GameObject.Find("Remaining").GetComponent<Text>();      
    }
	
	// Update is called once per frame
	void Update () {
        StartSpawning();
        StageIsOver();
        
    }

    public void StartSpawning() {
        if (TimeBtwnSpawn <= 0 && RemainingCustomer > 0)
        //for (int i = 0; i < 30; i++)
        {
            int randomCustomer = Random.Range(0, Customer.Length);
            Instantiate(Customer[randomCustomer], SpawnSpot.position, Quaternion.identity);
            //CM.gameObject.layer = 8;
            RemainingCustomer-=1;
            TimeBtwnSpawn = Random.Range(StartBtwnSpawn, EndSpawn);
            CM.gameObject.layer = 8;           
            /*Rand = Random.Range(0, OrderSpot.Count);
            temp = Instantiate(Customer[Rand], new Vector3(), Customer[Rand].transform.rotation);
            WaitingLine.Enqueue(temp);*/
            
        }else{
            TimeBtwnSpawn -= Time.deltaTime;
        }
        RemainingText.text = RemainingCustomer.ToString();
    }

    public void StageIsOver() {
        if (customersleaving == 0) {
            BGM[0].Stop();
            BGM[1].Stop();
            ResultPanel.SetActive(true);
            Invoke("EvaluationCounting", 1.5f);
            Bell.Play();
        }
    }

    public void EvaluationCounting() {

       

        if (Evaluation.SatedScore == TargetScore)
        {
            //PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
            Rank[0].SetActive(true);
            LevelClearApplause.Play();
            PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
        }
        else if (Evaluation.SatedScore >= TargetScore / 2)
        {
            //PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
            Rank[1].SetActive(true);
            LevelClearApplause.Play();
            PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
        }
        else if (Evaluation.SatedScore >= TargetScore / 4)
        {
            //PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
            Rank[2].SetActive(true);
            LevelClearApplause.Play();
            PlayerPrefs.SetInt("levelReached", LeveltoUnlock);
        }
        else
        {       
            Rank[3].SetActive(true);
            LevelFailedFart.Play();
        }
    }

    public void ReduceQueueSpot() {
        temp = (GameObject)WaitingLine.Dequeue();
        //CM.LeaveQueue();
        ResetQueuePos();
    }

    private void ResetQueuePos()
    {
        GameObject[] tempList = new GameObject[WaitingLine.Count];
        WaitingLine.CopyTo(tempList, 0);
        for (int x = 0; x < tempList.Length; x++) {
            tempList[x].transform.position = new Vector2(-(float)x / 2, 0);
        }
    }


}
