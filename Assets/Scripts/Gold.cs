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
        GoldPressesOwned++;
        Debug.Log("You bought a goldpress!");
    }
}
