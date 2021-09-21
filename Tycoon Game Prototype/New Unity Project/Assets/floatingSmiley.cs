using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingSmiley : MonoBehaviour {

    public float floatUp;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(0, floatUp));
        Destroy(gameObject, 0.5f);
    }
}
