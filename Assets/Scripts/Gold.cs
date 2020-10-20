using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    public int goldAmount = 0;
    public Text goldAmountText;

    private void Start()
    {
        this.goldAmount = PlayerPrefs.GetInt("SavedGold", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("SavedGold", this.goldAmount);
    }

    private void Update() {
        this.goldAmountText.text = this.goldAmount.ToString("Gold: 0");

        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }
    
    

    public void ProduceGold()
    {
        this.goldAmount += 5;
    }
}
