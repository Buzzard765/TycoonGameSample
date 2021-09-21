using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreGameManager : MonoBehaviour {

    public float GameTime;

	public static CoreGameManager Instance { get; private set; }

    public void Start()
    {
        
    }

    private void Update()
    {
        GameTime = Time.deltaTime;
        
    }
}
