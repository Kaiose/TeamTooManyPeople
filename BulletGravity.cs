using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGravity : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		rb.gravityScale = 0;
	}
}
