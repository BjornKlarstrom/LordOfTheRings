using System;
using UnityEngine;
using UnityEngine.UI;

namespace IdleClicker
{
    public class ProductionPopUp : MonoBehaviour
    {
        public float movmentSpeed = 20f;
        public float alphaFadeSpeed = 20f;

        private void Update()
        {
            // Move Up
            this.transform.position += Vector3.up * (movmentSpeed * Time.deltaTime);
            var text = GetComponent<Text>();

            // Fade over time
            var color = text.color;
            color.a -= this.alphaFadeSpeed * Time.deltaTime;
            text.color = color;
            
            // Destroy when fade is finish
            if(color.a <= 0f)
                Destroy(this.gameObject);
        }
    }
}
