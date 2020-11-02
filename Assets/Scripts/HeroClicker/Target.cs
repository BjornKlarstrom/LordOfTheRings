using System;
using UnityEngine;

namespace HeroClicker
{
    // Component with a target gameobject
    public class Target : MonoBehaviour
    {
        // Bool Property to check if target targetValue exists.
        public bool TargetExists => this.targetValue != null;

        // Skapar en publik GameObject som kan sättas utifrån 
        public GameObject targetValue;

        // Om det inte finns nåt target.targetValue. Förstör Target
        private void Update()
        {
            if (!this.targetValue)
            {
                Destroy(this);
            }
        }
    }
}
