using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

	public float Scroll_Speed = 0.3f;
	private Renderer rd;
	private float Offset;


	// Use this for initialization
	void Start () {
		rd = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Offset += Time.deltaTime * Scroll_Speed;
		rd.material.mainTextureOffset = new Vector2(Offset, 0);
	}
}
