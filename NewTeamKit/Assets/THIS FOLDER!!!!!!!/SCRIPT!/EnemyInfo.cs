using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {
    public int HP;
    private EnemyData enemyData;
    public float speed;

    public float distance = 10.0f;
    

    // Use this for initialization
    void Start()
    {
        enemyData = new EnemyData(HP);
        Debug.Log(gameObject.name + "의 체력 : " + enemyData.getHP());
    }

    void Update()
    {
        if (enemyData.getHP() <= 0)
        {
            Debug.Log("파괴!!!!!");
            Destroy(this.gameObject);
            // 현재 적의 오브젝트를 메모리풀링으로 만들지 않았기 때문에
            // Destroy로 처리합니다.
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player Missile"일 경우
        if (collision.CompareTag("Player Missile"))
        {
            Debug.Log("미사일과 충돌");
            enemyData.decreaseHP(10);   // 체력을 10 감소
            Debug.Log(gameObject.name + "의 현재 체력 : " + enemyData.getHP());
        }

        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(collision);
        }
    }

    void OnBecameInvisible() //화면밖으로 나가 보이지 않게 되면 호출이 된다.
    {
        Destroy(this.gameObject); //객체를 삭제한다.
    }
}
