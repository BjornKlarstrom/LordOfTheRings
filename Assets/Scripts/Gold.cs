using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    public int goldTotal = 0;
    public Text goldAmountText;

    [SerializeField] int goldValue = 5;

    private void Start()
    {
        this.goldTotal = PlayerPrefs.GetInt("SavedGoldTotal", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("SavedGoldTotal", this.goldTotal);
    }

    private void Update() {
        
        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }

    public void ProduceGold()
    {
        this.goldTotal += goldValue;
        this.goldAmountText.text = this.goldTotal.ToString();
    }
}
