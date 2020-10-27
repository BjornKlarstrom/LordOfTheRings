using System;
using System.Threading;
using UnityEngine;

namespace HeroClicker
{
    public class Enemy : MonoBehaviour
    {
        // Bool Property to check for Target Component
        private bool HasTarget => GetComponent<Target>();

        // Kolla om inte har target. Isf skapa hero och hitta Hero
        private void Update()
        {
            if (!this.HasTarget)
            {
                var hero = FindObjectOfType<Hero>();
                
                // Om hero inte är null. Skapa en ny comonent target
                // Sätt target.value till hero
                if (hero != null)
                {
                    var target = this.gameObject.AddComponent<Target>();
                    target.value = hero.gameObject;
                }
            }
        }
    }
}

