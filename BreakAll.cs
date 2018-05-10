using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;
public class BreakAll : MonoBehaviour {

    public float Speed = 15.0f;
    private float distance = 0.0f;
    public GameObject go;
    // Use this for initialization
	void Start () {
        Speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3 (transform.position.x + Speed * Time.deltaTime, transform.position.y, 0);
        if (transform.position.x > go.transform.position.x) gameObject.SetActive(false);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        EnemyBehaviour enemy = coll.gameObject.GetComponent<EnemyBehaviour>();
        enemy.Die2();
    }


}
