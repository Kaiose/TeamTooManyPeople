using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixed : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
    }
}
