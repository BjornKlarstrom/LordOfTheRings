using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnitScript : MonoBehaviour {
    public GoldProductionUnit goldProductionUnit;
    public Text goldAmountText;
    public Text purchaseButtonLabel;
    private Gold gold;
    float elapsedTime;

    public void SetUp(GoldProductionUnit goldProductionUnit) {
        this.goldProductionUnit = goldProductionUnit;
        this.gameObject.name = goldProductionUnit.name;
        this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name} {goldProductionUnit.costs}";
    }
	
    private int GoldPressAmount {
        get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
        set {
            PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
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
        ProductionReady();
        UpdatePurchaseColor();
    }

    private void Timer()
    {
        this.elapsedTime += Time.deltaTime;
    }

    private void ProductionReady()
    {
        if (this.elapsedTime >= this.goldProductionUnit.productionTime) 
        {
            ProduceGold();
            this.elapsedTime -= this.goldProductionUnit.productionTime;
        }
    }

    private void UpdatePurchaseColor()
    {
        if (gold.GoldAmount < goldProductionUnit.costs)
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
        this.goldAmountText.text = this.GoldPressAmount.ToString($"0 {this.goldProductionUnit.name}");
    }

    private void ProduceGold() {
        var gold = FindObjectOfType<Gold>();
        gold.GoldAmount += this.goldProductionUnit.productionAmount * this.GoldPressAmount;
    }

    public void BuyGoldPress() {
        var gold = FindObjectOfType<Gold>();
        if (gold.GoldAmount >= this.goldProductionUnit.costs) {
            gold.GoldAmount -= this.goldProductionUnit.costs;
            this.GoldPressAmount++;
        }
    }
}