using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QueueHandler : MonoBehaviour {

    public class BahanMakanan{
        public int Nasi;
        public int Ikan;
        public int Telor;
        public int Sambel;
    }

	// Use this for initialization
	void Start () {
        List<Vector3> QueuePosList = new List<Vector3>();
        Vector3 firstQueuePos = new Vector3(5, 7);
        float PositionGap = 5f;
        for (int a = 0; a <= 4; a++) {
            QueuePosList.Add(firstQueuePos + new Vector3(-1, 0) * PositionGap);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

   


}
