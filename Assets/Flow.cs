using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour {

    private float offset;
    [SerializeField]
    private float Speed;
    private Renderer rd;
    
	// Use this for initialization
	void Start () {
        rd = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        offset += Speed * Time.deltaTime;
        rd.material.mainTextureOffset = new Vector2(offset, 0);
	}
}
