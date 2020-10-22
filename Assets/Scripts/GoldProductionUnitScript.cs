using UnityEngine;
using UnityEngine.UI;

public class GoldProductionUnitScript : MonoBehaviour {
	public GoldProductionUnit goldProductionUnit;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
<<<<<<< HEAD
	[Ser]float timePassed;
	private Gold gold;
=======
	float timePassed;
>>>>>>> parent of 4fd6878... adds color green red to purchase button

	public void SetUp(GoldProductionUnit goldProductionUnit) {
		this.goldProductionUnit = goldProductionUnit;
		this.gameObject.name = goldProductionUnit.name;
		this.purchaseButtonLabel.text = $"Purchase {goldProductionUnit.name}";
	}
	
	public int GoldpressTotal {
		get => PlayerPrefs.GetInt(this.goldProductionUnit.name, 0);
		set {
			PlayerPrefs.SetInt(this.goldProductionUnit.name, value);
			UpdateGoldPressAmountLabel();
		}
	}

	void UpdateGoldPressAmountLabel() {
		this.goldAmountText.text = this.GoldpressTotal.ToString($"0 {this.goldProductionUnit.name}");
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
<<<<<<< HEAD

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
=======
>>>>>>> parent of 4fd6878... adds color green red to purchase button
	}

	void ProduceGold() {
		var gold = FindObjectOfType<Gold>();
		gold.GoldTotal += this.goldProductionUnit.productionAmount * this.GoldpressTotal;
	}

	public void BuyGoldPress() {
		var gold = FindObjectOfType<Gold>();
		if (gold.GoldTotal >= this.goldProductionUnit.costs) {
			gold.GoldTotal -= this.goldProductionUnit.costs;
			this.GoldpressTotal += 1;
		}
	}
}