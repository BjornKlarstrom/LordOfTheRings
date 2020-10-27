using System;
using UnityEngine;

namespace HeroClicker
{
    // Component with a target gameobject
    public class Target : MonoBehaviour
    {
        // Bool Property to check if target value exists.
        public bool TargetExists => this.value != null;

        // Skapar en publik GameObject som kan sättas utifrån 
        public GameObject value;

        // Om det inte finns nåt target.value. Förstör Target
        private void Update()
        {
            if (!this.value)
            {
                Destroy(this);
            }
        }
    }
}
