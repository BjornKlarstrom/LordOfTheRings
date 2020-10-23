using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
    public GoldProductionData goldProductionData;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    public Text producedGoldText;

    private Gold gold;
    float elapsedTime;
    private float timeFraction = 0f;

    public void SetUp(GoldProductionData goldProductionData) {
        this.goldProductionData = goldProductionData;
        this.gameObject.name = goldProductionData.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionData.name} {goldProductionData.costs}";
    }
	
    private int GoldPressAmount {
        get => PlayerPrefs.GetInt(this.goldProductionData.name, 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionData.name, value);
            UpdateGoldPressAmountLabel();
        }
    }

    private void Start() {
        gold = FindObjectOfType<Gold>();
        UpdateGoldPressAmountLabel();
    }
	
    private void Update()
    {
        Timer();
        ProductionDone();
        UpdatePurchaseColor();
        
    }

    private void Timer()
    {
        this.elapsedTime += Time.deltaTime;
    }

    private void ProductionDone()
    {
        

        if (this.elapsedTime >= this.goldProductionData.productionTime) 
        {
            ProduceGold();
            this.elapsedTime -= this.goldProductionData.productionTime;
            
            
        }
    }
    

    private void UpdatePurchaseColor()
    {
        if (gold.GoldAmount < goldProductionData.costs)
        {
            Debug.Log("true");
            this.purchaseButtonLabel.color = Color.red;
        }
        else
        {
            Debug.Log("false");
            this.purchaseButtonLabel.color = Color.green;
        }
    }
    
    private void UpdateGoldPressAmountLabel() {
        this.goldAmountText.text = this.GoldPressAmount.ToString($"0 {this.goldProductionData.name}");
    }

    private void ProduceGold() {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.goldProductionData.productionAmount * this.GoldPressAmount;
    }

    public void BuyGoldPress() {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount >= this.goldProductionData.costs) 
        {
            this.GoldPressAmount++;
            gold.GoldAmount -= this.goldProductionData.costs;
        }
    }
}