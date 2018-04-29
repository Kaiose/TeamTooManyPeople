using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float TotalHp = 5000;
    float CurrentHp;


	// Use this for initialization
	void Start () {
        CurrentHp = TotalHp;
	}
	


	// Update is called once per frame
	void Update () {
        CurrentHp--;
	    if(CurrentHp == 0)
        {
            Destroy(this.gameObject);
        }	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
            CurrentHp -= 1;
            transform.localScale = new Vector3((CurrentHp / TotalHp), 1, 1);
     
    }
}
