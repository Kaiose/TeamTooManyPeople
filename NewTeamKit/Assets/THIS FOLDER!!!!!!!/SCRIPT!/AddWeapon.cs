﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWeapon : AddBulletFire {
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player"일 경우
        if (collision.CompareTag("Player"))
        {
            FireState = true;
            Destroy(this.gameObject);
        }
    }
    
}