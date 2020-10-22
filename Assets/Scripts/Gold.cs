using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour {
    public int goldAmountPerClick = 5;
    public Text goldAmountText;

    public int GoldTotal {
        get => GoldTotal;
        set {
            GoldTotal = value;
            UpdateGoldAmountLabel();
        }
    }

    void UpdateGoldAmountLabel() {
        this.goldAmountText.text = this.GoldTotal.ToString("0 Gold");
    }

    void Awake() {
        PlayerPrefs.GetInt("GoldTotal", 0);
        UpdateGoldAmountLabel();
    }
	
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            ProduceGold();
        }
    }

    public void ProduceGold() {
        this.GoldTotal += this.goldAmountPerClick; 
    }

    void OnApplicationQuit() {
        PlayerPrefs.SetInt("GoldTotal", GoldTotal);
    }
}