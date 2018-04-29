using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class LookAtPlayer : MonoBehaviour {

    // 플레이어 위치정보
    Transform target;
    float distance = 5.0f;
    Transform myTransform;

    EnemyBehaviour eb;
    


    void Awake()
    {
        myTransform = transform;
    }


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= distance)
        {
            eb.SetMoveVector(Vector2.up);
        }
    }
}
