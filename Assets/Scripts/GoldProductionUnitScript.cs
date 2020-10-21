using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnitScript : MonoBehaviour {
	public GoldProductionUnit goldProductionUnit;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	float timePassed;
	private Gold gold;

	public void SetUp(GoldProductionUnit goldProductionUnit) {
		this.goldProductionUnit = goldProductionUnit;
		this.gameObject.name = goldProductionUnit.name;
		this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name} {goldProductionUnit.costs}";
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
		gold = FindObjectOfType<Gold>();
		UpdateGoldPressAmountLabel();
	}
	
	void Update() {
		this.timePassed += Time.deltaTime;
		if (this.timePassed >= this.goldProductionUnit.productionTime) {
			ProduceGold();
			this.timePassed -= this.goldProductionUnit.productionTime; 
		}

		UpdatePuschaseColor();
	}

	void UpdatePuschaseColor()
	{
		if (gold.GoldTotal < goldProductionUnit.costs)
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

	void ProduceGold() {
		var gold = FindObjectOfType<Gold>();
		gold.GoldTotal += this.goldProductionUnit.productionAmount * this.GoldPressTotal;
	}

	public void BuyGoldPress() {
		
		if (gold.GoldTotal >= this.goldProductionUnit.costs) {
			gold.GoldTotal -= this.goldProductionUnit.costs;
			this.GoldPressTotal += 1;
		}
	}
}