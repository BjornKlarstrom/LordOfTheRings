using System;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public float goldPerClick = 5.0f;
    public Text goldAmountText;

    public float GoldAmount
    {
        get => PlayerPrefs.GetFloat("Gold", 0.0f);
        set
        {
            PlayerPrefs.SetFloat("Gold", value);
            this.goldAmountText.text = this.GoldAmount.ToString("Gold 0.0");
        }
    }
    
    void UpdateGoldAmountLabel()
    {
        this.goldAmountText.text = this.GoldAmount.ToString("Gold 0.0");
    }

    void Start()
    {
        UpdateGoldAmountLabel();
    }
    
    public void ProduceGold()
    {
        this.GoldAmount += this.goldPerClick;
    }
}
