using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 메소드 호출
        Move();
        
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
        
    }

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))  // W 방향키를 누를 때
        {
            // Translate는 현재 위치에서 ()안에 들어간 값만큼 값을 변화시킨다.
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            // Time.deltaTime은 모든 기기(컴퓨터, OS를 망론하고)에 같은 속도로 움직이도록 하기 위한 것
        }
        if (Input.GetKey(KeyCode.S))  // S 방향키를 누를 때
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))  // D 방향키를 누를 때
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))  // A 방향키를 누를 때
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }
    }

}