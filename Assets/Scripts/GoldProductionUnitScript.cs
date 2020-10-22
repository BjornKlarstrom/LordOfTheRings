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
	
	public int GoldpressTotal {
		get => GoldpressTotal;
		set {
			GoldpressTotal = value;
			UpdateGoldPressAmountLabel();
		}
	}

	void UpdateGoldPressAmountLabel() {
		this.goldAmountText.text = this.GoldpressTotal.ToString($"0 {this.goldProductionUnit.name}");
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

		UpdatePuschaseTextColor();
	}

	void UpdatePuschaseTextColor()
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
		gold.GoldTotal += this.goldProductionUnit.productionAmount * this.GoldpressTotal;
	}

	public void BuyGoldPress() {
		
		if (gold.GoldTotal >= this.goldProductionUnit.costs) {
			gold.GoldTotal -= this.goldProductionUnit.costs;
			this.GoldpressTotal += 1;
		}
	}
}