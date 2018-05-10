using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedAroundEllen : MonoBehaviour {

    public Transform obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(obj.position, Vector3.up, 1.5f * Time.deltaTime);
   	}
}
