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
        get => _goldTotal;
        set
        {
            _goldTotal = value;
            this.goldAmountText.text = value.ToString();
        }
    }


    // Methods
    private void Start()
    {
        this.GoldTotal = PlayerPrefs.GetInt("SavedGoldTotal", 0);
        this.goldAmountText.text = this.GoldTotal.ToString();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("SavedGoldTotal", this._goldTotal);
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
