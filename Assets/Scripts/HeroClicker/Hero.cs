using System;
using UnityEngine;

namespace HeroClicker
{
    public class Hero : MonoBehaviour
    {
        // Bool Property to check for Target Component or not
        private bool HasTarget => GetComponent<Target>() != null;

        // Kolla om inte har target. Isf skapa enemy och hitta Enemy
        private void Update()
        {
            if (!this.HasTarget)
            {
                var enemy = FindObjectOfType<Enemy>();

                // Om enemy finns. Skapa en ny comonent target
                // Sätt target.targetValue till enemy
                if (enemy != null)
                {
                    var target = this.gameObject.AddComponent<Target>();
                    target.targetValue = enemy.gameObject;
                }
            }
        }
    }  
}

