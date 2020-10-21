using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnitScript : MonoBehaviour {
	public GoldProductionUnit goldProductionUnit;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	float timePassed;

	public void SetUp(GoldProductionUnit goldProductionUnit) {
		this.goldProductionUnit = goldProductionUnit;
		this.gameObject.name = goldProductionUnit.name;
		this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
	}
	
	public int GoldPressTotal {
		get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
		set {
			PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
			UpdateGoldPressAmountLabel();
		}
	}

	void UpdateGoldPressAmountLabel() {
		this.goldAmountText.text = this.GoldPressTotal.ToString($"0 {this.goldProductionUnit.name}");
	}

	void Start() {
		UpdateGoldPressAmountLabel();
	}
	
	void Update() {
		this.timePassed += Time.deltaTime;
		if (this.timePassed >= this.goldProductionUnit.productionTime) {
			ProduceGold();
			this.timePassed -= this.goldProductionUnit.productionTime; 
		}
	}

	void ProduceGold() {
		var gold = FindObjectOfType<Gold>();
		gold.GoldTotal += this.goldProductionUnit.productionAmount * this.GoldPressTotal;
	}

	public void BuyGoldPress() {
		var gold = FindObjectOfType<Gold>();
		if (gold.GoldTotal >= this.goldProductionUnit.costs) {
			gold.GoldTotal -= this.goldProductionUnit.costs;
			this.GoldPressTotal += 1;
		}
	}
}