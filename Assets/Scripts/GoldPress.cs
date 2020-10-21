using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldPress : MonoBehaviour
{
    public int productionAmount = 1;
    public int cost = 100;
    public float pressTime = 1;
    public Text goldAmountText;
    public float timePassed;
    
    public int AmountOfGoldpresses
    {
        get => PlayerPrefs.GetInt("Goldpresses", 0);
        set
        {
            PlayerPrefs.SetInt("Goldpresses", value);
        }
    }

}
