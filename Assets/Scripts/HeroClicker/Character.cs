using System;
using UnityEngine;

namespace HeroClicker
{
    public class Character : MonoBehaviour
    {
        // Fields
        public float chargingTime = 0.6f;
        public float damage = 5.0f;
        public float health = 100.0f;
        private float _passedTime;
        
        // Properties
        private GameObject Target => GetComponent<Target>().targetValue;
        private bool HasTarget => GetComponent<Target>() != null && GetComponent<Target>().TargetExists;
        private bool IsChargingAttack => this._passedTime < this.chargingTime;
        private bool CanAttack => !this.IsChargingAttack && this.HasTarget;
        private bool IsDead => this.health <= 0.0f;
        
        // Update
        private void Update()
        {
            UpdateTimer();

            if (this.CanAttack)
            {
                Attack();
            }
        }

        void UpdateTimer()
        {
            this._passedTime += Time.deltaTime;
        }

        void Attack()
        {
            var character = this.Target.GetComponent<Character>();
            character.TakeDamage(this.damage);
            Debug.Log($"{this} attacks {this.Target} for {this.damage} damage! ...{this}");
            this._passedTime -= this.chargingTime;
        }

        public void TakeDamage(float damageToGive)
        {
            this.health -= damageToGive;

            if (this.IsDead)
            {
                Destroy(this.gameObject);
            }
        }
    }
}