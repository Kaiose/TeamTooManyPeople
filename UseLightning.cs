using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLightning : MonoBehaviour {


    public GameObject[] child;
    // Use this for initialization
    void Start () {
        child = GetComponentsInChildren<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckKey();

    }


    void CheckKey()
    {
        if (Input.GetKeyDown("r"))
        {
            foreach (GameObject temp in child)
            {
                if (temp.activeSelf == false)
                {
                    temp.SetActive(true);
                    break;
                }

            }
        }
    }

}
