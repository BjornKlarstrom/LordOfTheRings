using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Gold : MonoBehaviour
{
    // Fields
    [SerializeField] private int goldValue = 5;
    public Text goldAmountText;

    public int goldPressesOwned = 0;
    private int goldpressCost = 100;

    // Property for total amount of gold and Goldpresses
    public int GoldTotal
    {
        get => PlayerPrefs.GetInt("SavedGoldTotal",0);
        set
        {
            PlayerPrefs.SetInt("SavedGoldTotal", value);
            UpdateGoldAmountText();
        }
    }

    public int GoldPressesOwned
    {
        get => goldPressesOwned;
        set => goldPressesOwned = value;
    }


    // Methods
    void UpdateGoldAmountText()
    {
        this.goldAmountText.text = this.GoldTotal.ToString("Gold: 0");
    }

    private void Start()
    {
        UpdateGoldAmountText();
    }

    private void Update() 
    {
        
    }

    public void ProduceGold()
    {
        this.GoldTotal += this.goldValue;
    }

    public void ByGoldpress()
    {
        if (GoldTotal < goldpressCost)
        {
            Debug.Log("Not enough gold for this! ");
            return;
        }
        else
        {
            GoldPressesOwned++;
            StartCoroutine(PressGoldAndWait(1f));
            Debug.Log("You bought a goldpress!");   
        }
    }

    IEnumerator PressGoldAndWait(float waitTime)
    {
        while (true)
        {
            GoldTotal += 1;
            Debug.Log("Goldpress pressed 1 gold!");
            yield return new WaitForSeconds(waitTime);
        }
    }
}
