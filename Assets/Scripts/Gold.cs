using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {
	public int goldAmountPerClick = 5;
	public Text goldAmountText;

	public int GoldAmount {
		get => PlayerPrefs.GetInt("Gold", 1);
		set {
			PlayerPrefs.SetInt("Gold", value);
			UpdateGoldAmountLabel();
		}
	}

	private void UpdateGoldAmountLabel() {
		this.goldAmountText.text = this.GoldAmount.ToString("0 Gold");
	}

	private void Start() {
		UpdateGoldAmountLabel();
	}
	
	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			ProduceGold();
		}
	}

	private void ProduceGold() {
		this.GoldAmount += this.goldAmountPerClick; 
	}
}