using System;
using UnityEngine;



[CreateAssetMenu]
public class Gold : ScriptableObject {
    [SerializeField] int goldPerClick = 5;
    const string goldPlayerPrefsKey = "Gold";
    int gold;

    public int GoldAmount {
        get => PlayerPrefs.GetInt(goldPlayerPrefsKey, 0);
        set
        {
            this.gold = value; PlayerPrefs.SetInt(goldPlayerPrefsKey, value); } }

    private void Awake() {
    }

    public void ProduceGold() { this.GoldAmount += this.goldPerClick;
    }
}
