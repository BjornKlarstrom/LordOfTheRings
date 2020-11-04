using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour {
	public Text goldAmountText;
	public Gold gold;

	void UpdateGoldAmountLabel() {
		goldAmountText.text = gold.GoldAmount.ToString("0 Gold");
	}

	void Update() {
		UpdateGoldAmountLabel();
	}
}
