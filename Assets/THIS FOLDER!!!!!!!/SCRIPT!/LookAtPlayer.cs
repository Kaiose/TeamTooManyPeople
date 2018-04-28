using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

    // 플레이어 위치정보
    Transform target;
    float distance = 5.0f;
    Transform myTransform;

    
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
        if (Vector3.Distance(target.position, transform.position) <= distance)
        {
            myTransform.position = Vector3.MoveTowards(transform.position, target.position, 5.0f * Time.deltaTime);
            transform.LookAt(target);
        }
    }
}
