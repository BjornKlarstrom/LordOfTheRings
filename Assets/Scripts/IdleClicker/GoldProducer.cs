using UnityEngine;
using UnityEngine.UI;

public class GoldProducer : MonoBehaviour {
	public GoldProductionData GoldProductionData;
	public Text goldAmountText;
	public Text purchaseButtonLabel;
	public Text upgradeButtonLabel;
	public ProductionPopUp popupPrefab;
	public Gold gold;
	float elapsedTime;

	int Amount {
		get => PlayerPrefs.GetInt(this.GoldProductionData.name, 1);
		set {
			PlayerPrefs.SetInt(this.GoldProductionData.name, value);
			UpdateTitleLabel();
		}
	}

	string UpgradeAmountPlayerPrefKey => $"{this.GoldProductionData.name}_Upgrade";

	int UpgradeAmount {
		get => PlayerPrefs.GetInt(this.UpgradeAmountPlayerPrefKey, 0);
		set {
			PlayerPrefs.SetInt(this.UpgradeAmountPlayerPrefKey, value);
			UpdateTitleLabel();
		}
	}

	bool IsAffordable => this.gold.GoldAmount >= this.GoldProductionData.GetActualCosts(this.Amount);
	bool IsUpgradeAffordable => this.gold.GoldAmount >= this.GoldProductionData.GetActualCosts(this.UpgradeAmount);

	public void SetUp(GoldProductionData goldProductionData) {
		this.GoldProductionData = goldProductionData;
		this.gameObject.name = goldProductionData.name;
		this.purchaseButtonLabel.text = $"Purchase for {this.GoldProductionData.GetActualCosts(this.Amount)}";
		this.upgradeButtonLabel.text = $"Upgrade for {this.GoldProductionData.GetActualCosts(this.UpgradeAmount)}";
	}

	public void Purchase() {
		if (this.IsAffordable) {
			this.gold.GoldAmount -= this.GoldProductionData.GetActualCosts(this.Amount);
			this.Amount += 1;
			this.purchaseButtonLabel.text = $"Purchase for {this.GoldProductionData.GetActualCosts(this.Amount)}";
		}
	}

	public void Upgrade() {
		if (this.IsUpgradeAffordable) {
			this.gold.GoldAmount -= this.GoldProductionData.GetActualCosts(this.UpgradeAmount);
			this.UpgradeAmount += 1;
			this.upgradeButtonLabel.text = $"Upgrade for {this.GoldProductionData.GetActualCosts(this.UpgradeAmount)}";
		}
	}

	void Start() {
		UpdateTitleLabel();
	}

	void Update() {
		this.elapsedTime += Time.deltaTime;
		if (this.elapsedTime >= this.GoldProductionData.productionTime) {
			ProduceGold();
			this.elapsedTime -= this.GoldProductionData.productionTime; // DO NOT SET TO ZERO HERE
		}

		UpdateTextColor();
	}

	void UpdateTextColor() {
		this.purchaseButtonLabel.color = this.IsAffordable ? Color.black : Color.red;
		this.upgradeButtonLabel.color = this.IsUpgradeAffordable ? Color.black : Color.red;
	}

	void UpdateTitleLabel() {
		this.goldAmountText.text = $"{this.Amount}x {this.GoldProductionData.name} Level {this.UpgradeAmount}";
	}

	void ProduceGold() {
		if (this.Amount == 0)
			return;
		this.gold.GoldAmount += Mathf.RoundToInt(CalculateProductionAmount());
		var instance = Instantiate(this.popupPrefab, transform);
		instance.GetComponent<Text>().text = $"+{CalculateProductionAmount()}";
	}

	float CalculateProductionAmount() {
		return this.GoldProductionData.GetProductionAmount(this.UpgradeAmount) * this.Amount;
	}
}