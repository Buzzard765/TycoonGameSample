using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMovement : MonoBehaviour {

    public float movement;
    public GameObject OrderSpot;
    public GameObject[] OrderPicture;
    public float Patience, MaxPatience;
    Rigidbody2D CstmrRB;

    public float OutsideService;
    public bool Ordering;
    public Slider PatienceBar;
    public SpriteRenderer SpRd;
    public bool CancelOrder;
    public bool WrongOrder;
    public int rand;
    public DataModel dm;
    public bool IsSated;
    Vector3 newPos;

    public AudioSource SatedSFX;
    public AudioSource DisSatedSFX;
    public GameObject[] SatedSmiley;
    public GameObject[] DisSatSmiley;
    public Transform ReactionFloat;

    private CustomerSpawning cs;
    private CustomerSpawning leavingAmount;
    //public List<CuisineObject> RandOrder = new List<CuisineObject>();
    public CuisineObject[] RandOrder;

    
    //public SpriteRenderer CsnImage;
        
    
	// Use this for initialization
	void Start () {
        gameObject.layer = 8;
        Patience = MaxPatience;
        CstmrRB = GetComponent<Rigidbody2D>();
        SpRd = GetComponent<SpriteRenderer>();
        SatedSFX = transform.GetChild(3).GetComponent<AudioSource>();
        DisSatedSFX = transform.GetChild(4).GetComponent<AudioSource>();
        ReactionFloat = transform.GetChild(5).GetComponent<Transform>();
        //RecipeObject = GameObject.FindGameObjectWithTag("RecipeObject").GetComponent<RecipeObject>();
        //PatienceBar = GetComponent<Slider>();
        //PatienceBar.value = Patience;
        cs = GameObject.Find("ObjectPool").GetComponent<CustomerSpawning>();
        //leavingAmount = GameObject.Find("CustomerSpawning").GetComponent<CustomerSpawning>();
        dm = GameObject.Find("AllFoodBuyButton").GetComponent<DataModel>();
        //newPos = transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {
        MoveToOrder();               
    }

    public void MoveToOrder() {
        CstmrRB.velocity = new Vector2(movement, 0);

        if (CancelOrder == true)
        { //saat mereka batal pesanan
            //CstmrRB.velocity = new Vector2(-5, 0);
            gameObject.layer = 0;
            Debug.Log("leaving through");
            Physics2D.IgnoreLayerCollision(0, 8);
            movement = -5; //pulang
            transform.localScale = new Vector3(-1f, 1f, 1f); //flip sprite
            DisSatedSFX.Play();
           
            
            //Invoke("LeavingArea", 3f);
        }
        else if (IsSated == true)
        {
            Ordering = false;
            Patience = 1;           
            //  Invoke("LeavingArea", 3f);
        }
        else if (Ordering == true)
        {
            //Debug.Log(collision.gameObject.name);
            movement = 0;
            if (Patience > 0)
            {
                if (WrongOrder == true)
                {
                    Patience -= Time.deltaTime * 2;
                }
                Patience -= Time.deltaTime; //menunggu
                // PatienceBar.value = Patience / 5;
            }
            else //jika sudah menunggu lama
            {
                CancelOrder = true; //batalkan pesanan
                transform.position = new Vector3(transform.position.x, transform.position.y, 2);
                SpRd.sortingOrder = 4;//supaya sprite dapat melewati sprite lain
                OrderPicture[rand].SetActive(false);
                dm.disSatScore += 1;               
                dm.disSatScoreText.text = dm.disSatScore.ToString();
                //RequestBaloon.setactive(true);
                //CsnImage.enabled = false;
            }
            
        }
    } 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("OrderingPoint") || collision.gameObject.CompareTag("Customer")) && CancelOrder == false)
        {//untuk customer paling depan, dan bila ada antrian dibelakang          
            Ordering = true; //nyalakan status sedang memesan
            movement = 0;
        }
        else {
            int NegFeedback = Random.Range(0, 2);
            Instantiate(DisSatSmiley[NegFeedback], ReactionFloat.position, Quaternion.identity);
        }
    }

    
    //RecipeObject.FoodName.Length
    // ProductOrder = OrderRequest[rand];
    //RequestBaloon.setactive(true); 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Customer")) {
            Debug.Log("Stacking a queue");
            movement = 3;
        }
        /*if ((collision.gameObject.CompareTag("OrderingPoint") || collision.gameObject.CompareTag("Customer")) && CancelOrder == false)
        {//untuk customer paling depan, dan bila ada antrian dibelakang          
            Ordering = true; //nyalakan status sedang memesan         
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //bool PickOrder = false;
        if (!collision.gameObject.CompareTag("OrderingPoint")) 
            return;
        rand = Random.Range(0, 3);

        foreach (var icon in OrderPicture) {
            icon.SetActive(false);
        }
        OrderPicture[rand].SetActive(true);

        if (collision.gameObject.CompareTag("Customer"))
        {
            Debug.Log("Stacking a queue");
            movement = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {           
        if (collision.gameObject.CompareTag("OB"))
        {
            Debug.Log("leavingArea");
            cs.customersleaving -= 1;
            Destroy(gameObject);
        }

        if (Ordering == true)
        {
            if (rand == 0)
            { //
                if (collision.gameObject.CompareTag("Rendang"))
                {
                    Debug.Log("Pesanan Rendang");
                    OrderPicture[rand].SetActive(false);
                    Destroy(collision.gameObject);
                    GetRendang();
                    Sated();
                    dm.SatedScore += 1;
                    dm.SatedScoreText.text = dm.SatedScore.ToString();
                    SatedSFX.Play();                   
                }
                else if (collision.gameObject.CompareTag("Rendang") || collision.gameObject.CompareTag("Customer"))
                {
                    WrongOrder = true;
                    Debug.Log("Wrong Order");
                    Destroy(collision.gameObject);
                }
                //Destroy(gameObject);*/
            }
            else if (rand == 1)
            { //
                if (collision.gameObject.CompareTag("Gado Gado"))
                {//
                    Debug.Log("Pesanan Gado Gado");
                    OrderPicture[rand].SetActive(false);
                    Destroy(collision.gameObject);
                    GetGadoGado();
                    Sated();
                    dm.SatedScore += 1;
                    dm.SatedScoreText.text = dm.SatedScore.ToString();
                    SatedSFX.Play();                   
                }
                else if (collision.gameObject.CompareTag("Rendang") || collision.gameObject.CompareTag("Soto"))
                {
                    WrongOrder = true;
                    Debug.Log("Wrong Order");
                    Destroy(collision.gameObject);
                }  
            }
            else if (rand == 2)
            {
                if (collision.gameObject.CompareTag("Soto"))
                {
                    Debug.Log("Pesanan Soto");
                    OrderPicture[rand].SetActive(false);
                    Destroy(collision.gameObject);
                    GetSoto();
                    Sated();
                    dm.SatedScore += 1;
                    dm.SatedScoreText.text = dm.SatedScore.ToString();
                    SatedSFX.Play();                  
                }
                else if (collision.gameObject.CompareTag("Rendang") || collision.gameObject.CompareTag("Gado Gado"))
                {
                    WrongOrder = true;
                    Debug.Log("Wrong Order");
                    Destroy(collision.gameObject);
                }
            }
            
        }
        int PosFeedback = Random.Range(0, 3);
        Instantiate(SatedSmiley[PosFeedback], ReactionFloat.position, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Customer") ) { //saat customer tidak berdempetan dgn customer lain
            Debug.Log("Moving Out");
            collision.gameObject.GetComponent<CustomerMovement>().movement = 5;
            collision.gameObject.GetComponent<CustomerMovement>().Ordering = false;            
        }
    }

    public void GetRendang() {
        Debug.Log("Paycheck");
        dm.uang += RandOrder[0].Profit;
 
    }

    public void GetGadoGado() {
        Debug.Log("Paycheck");
        dm.uang += RandOrder[1].Profit;
    }

    public void GetSoto() {
        Debug.Log("Paycheck");
        dm.uang += RandOrder[2].Profit;
    }

    public void Sated() {
        Debug.Log("I'm Satisfied");
        IsSated = true;
        movement = 5;
        gameObject.layer = 0;
        Physics2D.IgnoreLayerCollision(0, 9);
    }
}
