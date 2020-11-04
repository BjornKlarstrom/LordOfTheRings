using UnityEngine;

[CreateAssetMenu]
public class Gold : ScriptableObject {
    public int goldAmountPerClick = 5;
    const string goldPlayerPrefKey = "Gold";

    public int GoldAmount {
        get => PlayerPrefs.GetInt(goldPlayerPrefKey, 1);
        set => PlayerPrefs.SetInt(goldPlayerPrefKey, value);
    }

    public void ProduceGold() {
        this.GoldAmount += this.goldAmountPerClick; // this.GoldAmount = this.GoldAmount + this.goldAmountPerClick;
    }
}
