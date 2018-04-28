using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpawnObstacle : MonoBehaviour {
    public GameObject[] obj;
    public float time = 5;
	// Use this for initialization
	void Start () {
        
        InvokeRepeating("Check",0,time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Check()
    {

        for (int i = 0; i <= obj.Length; i++)
        {

            if (obj[i].activeSelf) continue;
            else
            {
                obj[i].SetActive(true);
                return;
            }
        }
    }

}
