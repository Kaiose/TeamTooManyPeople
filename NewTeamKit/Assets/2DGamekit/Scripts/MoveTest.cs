using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveTest : MonoBehaviour {

    private Rigidbody rb;



	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("space"))
        {
            rb.AddForce(Vector3.up * 100.0f);
        }
	}
}
