using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{

    private float randomY;
    private int randomObject;
    private float movement;
    private bool enableSpawn;
    private Transform[] pos;

    public Transform startPosition;
    public Transform endPosition;
    public GameObject[] obstacles;
    public float startY, endY;
    public float speed = -1;
  

    // Use this for initialization
    void Start()
    {

        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < endPosition.position.x)
        {

            for (int i = 0; i < pos.Length; i++)
            {
                if (pos[i] != transform)
                {
                    if (pos[i] == null) continue;
                    Destroy(pos[i].gameObject);

                }

            }
            Initialize();
            this.gameObject.SetActive(false);
            return;
        }


        movement = speed * Time.deltaTime;
        for(int i = 0; i < pos.Length;i++)
        {
            if (pos[i] == null) continue;
            //  t.position = new Vector3(t.position.x + movement, t.position.y, t.position.z);
            pos[i].position = new Vector3(transform.position.x + movement, pos[i].position.y, pos[i].position.z);
        }


    }

    void Initialize()
    {
        transform.position = new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z);
        enableSpawn = true;
        GenerateObstacles();
        pos = gameObject.GetComponentsInChildren<Transform>();
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
