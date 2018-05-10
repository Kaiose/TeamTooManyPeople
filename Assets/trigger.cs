using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class trigger : MonoBehaviour {

    //public GameObject go;
    // Use this for initialization
    public GameObject go;
    public GameObject boss;


    void OnTriggerEnter2D(Collider2D other)
    {
        go.SetActive(true);
        boss.SetActive(true);

    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //void OnTriggerEnter2D(Collier2D other)
    //{
    //    go.SetActive(true);
    //}
}
