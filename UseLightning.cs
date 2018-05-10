using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLightning : MonoBehaviour {

    public GameObject go;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckKey();

    }


    void CheckKey()
    {
        if (Input.GetKeyDown("r"))
        {
            go.SetActive(true);
        }
    }

}
