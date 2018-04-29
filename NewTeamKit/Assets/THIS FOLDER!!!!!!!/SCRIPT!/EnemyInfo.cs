using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {
    public int HP;
    private EnemyData enemyData;
    public float speed;

    public GameObject explosionPrefab;


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

            Instantiate(explosionPrefab,
            // Instantiate는 객체를 하나 생성(복제)합니다 첫번째 인자로는 생성할 객체의 원본을 넣어주고
                this.transform.position,
                //두번째 인자로는 생성될 위치를 넣어줍니다. this.transform.position은 자기자신의 위치를 나타냅니다.
                Quaternion.identity);
            //세번째 인자로는 객체의 회전값을 넣어주는데요, Quaternion.identity는 회전이 적용되지 않은 값을 나타냅니다.
            /* 여기까지 */
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible() //화면밖으로 나가 보이지 않게 되면 호출이 된다.
    {
        Destroy(this.gameObject); //객체를 삭제한다.
    }
}
