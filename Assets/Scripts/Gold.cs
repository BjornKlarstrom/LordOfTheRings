using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    // Fields
    [SerializeField] private int goldValue = 5;
    public Text goldAmountText;

    private int _goldTotal = 0;

    // Property for _goldTotal
    public int GoldTotal
    {
        get => PlayerPrefs.GetInt("SavedGoldTotal",0);
        set
        {
            PlayerPrefs.SetInt("SavedGoldTotal", value);
            UpdateGoldAmountText();
        }
    }


    // Methods
    void UpdateGoldAmountText()
    {
        this.goldAmountText.text = this.GoldTotal.ToString("Gold: 0");
    }

    private void Start()
    {
        UpdateGoldAmountText();
    }

    private void Update() 
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            ProduceGold();
        }
    }

    public void ProduceGold()
    {
        this.GoldTotal += this.goldValue;
    }
}
