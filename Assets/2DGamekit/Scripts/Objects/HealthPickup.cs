using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit2D
{
    public class HealthPickup : MonoBehaviour
    {
        public enum ItemAttribute { Health, Time_recovery };

        public ItemAttribute MineAttribute;
        public int healthAmount = 1;
        public UnityEvent OnGivingHealth;

        private Shooting_Move shoot_move;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject == PlayerCharacter.PlayerInstance.gameObject)
            {
                switch (MineAttribute)
                {
                    case ItemAttribute.Health:
                        Damageable damageable = PlayerCharacter.PlayerInstance.damageable;
                        if (damageable.CurrentHealth < damageable.startingHealth)
                        {
                            damageable.GainHealth(Mathf.Min(healthAmount, damageable.startingHealth - damageable.CurrentHealth));
                            OnGivingHealth.Invoke();
                        }
                        break;
                    case ItemAttribute.Time_recovery:
                        shoot_move = other.gameObject.GetComponent<Shooting_Move>();

                        if (shoot_move.rest_time < 900)
                            shoot_move.rest_time = shoot_move.rest_time + 100;
                        else
                            shoot_move.rest_time = 1000f;

                        Destroy(this.gameObject);

                        break;
                }
            }
        }
    }
}



