using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private float randomY;
    private int randomObject;
    private float movement;
    private bool enableSpawn;


    public GameObject[] obstacles;
    public float startY, endY;
    public float speed = -1;
    public Transform[] pos;

  

    void Awake() {

        //  obstacles = new GameObject[numberOfGameObject];
     //   movement = speed * Time.deltaTime; 
    }


	// Use this for initialization
	void Start () {
        //InvokeRepeating("GenerateObstacles", 1, 3);
        enableSpawn = true;
        GenerateObstacles();
        pos = gameObject.GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {


        movement = speed * Time.deltaTime;
        foreach (Transform t in pos)
        {
         //  t.position = new Vector3(t.position.x + movement, t.position.y, t.position.z);
            t.position = new Vector3(transform.position.x+ movement, t.position.y, t.position.z);
        }

	}

    void GenerateObstacles()
    {
        if (enabled == false) return;
        int randomNum = Random.Range(1, 4); // 한번에 생성할 객체수 
        for (int i = 0; i < randomNum; i++)
        {
            randomY = Random.Range(startY, endY); // 오브젝트 생성을 어디서 할것인가?
            randomObject = Random.Range(0, obstacles.Length); // 몇번째 오브젝트를 생성할것인가?
        
            GameObject Enemy = (GameObject)Instantiate(obstacles[randomObject], new Vector3(transform.position.x, randomY, 0f), Quaternion.identity);
            Enemy.transform.parent = transform;
        }
        enableSpawn = false;
        
        

    }

}
