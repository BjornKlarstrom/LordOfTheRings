using System;
using UnityEngine;
using UnityEngine.UI;

    public class GoldProducer : MonoBehaviour
    {
        public GoldProductionData goldProductionData;
        public Text buyGoldPressButtonText;
        public Text goldPressesAmount;
        
        public Text costUpgradeText;
        public Text upgradeLevelText;
        public float upgradeCostIncrease = 1.1f;
        public float upgradeLevelBonus = 0.05f;
        public float upgradeValue = 1f;
        
        private float _timePassed;

        private Gold gold;
        public GameObject floatingTextPrefab;

        public void SetUp(GoldProductionData data)
        {
            this.goldProductionData = data;
            this.gameObject.name = data.name;
            this.buyGoldPressButtonText.text = $"{data.name}, ${data.basicCost}";
            this.costUpgradeText.text = $"Upgrade ${data.upgradeCost}";
        }

        public float UpgradeLevel
        {
            get => PlayerPrefs.GetFloat($"{this.goldProductionData.name}UpgradeLevel", 0);
            set
            {
                PlayerPrefs.SetFloat($"{this.goldProductionData.name}UpgradeLevel", value);
                this.costUpgradeText.text = 
                    this.goldProductionData.upgradeCost.ToString($"Upgrade: ${this.goldProductionData.upgradeCost}");
                this.upgradeLevelText.text =
                    this.UpgradeLevel.ToString($"Level {this.UpgradeLevel}");
            }
        }

        public float GoldPressesAmount
        {
            get => PlayerPrefs.GetFloat(this.goldProductionData.name, 0);
            set
            {
                PlayerPrefs.SetFloat(this.goldProductionData.name, value);
                UpdateInfoTexts();
            }
        }

        private void Awake()
        {
            gold = FindObjectOfType<Gold>();
        }

        private void Start()
        {
            UpdateInfoTexts();
        }

        private void Update()
        {
            Timer();
            ProductionReadyCheck();
            UpdateCostTextColor();
        }
        
        private void Timer()
        {
            this._timePassed += Time.deltaTime;
        }
        
        private void ProductionReadyCheck()
        {
            if (this._timePassed < this.goldProductionData.productionTime) return;
            ProduceGold();
            this._timePassed -= this.goldProductionData.productionTime;
        }
        
        void UpdateCostTextColor()
        {
            if (this.goldProductionData.basicCost > gold.GoldAmount)
            {
                this.buyGoldPressButtonText.color = Color.red;
            }
            else
            {
                this.buyGoldPressButtonText.color = Color.green;
            }
        }

        void UpdateInfoTexts()
        {
            this.goldPressesAmount.text = 
                this.GoldPressesAmount.ToString($"0 {this.goldProductionData.name}");

            this.upgradeLevelText.text =
                this.UpgradeLevel.ToString($"Level {this.UpgradeLevel}");
        }
        

        public void ProduceGold()
        {
            gold.GoldAmount += this.upgradeValue * 
                               this.goldProductionData.productionAmount *
                               this.GoldPressesAmount;
                               
            
            //Trigger Text Animation
            if(this.GoldPressesAmount < 1) return;
            var instance = Instantiate(floatingTextPrefab, this.transform);
            instance.GetComponent<Text>().text =
                (this.upgradeValue * 
                 this.goldProductionData.productionAmount * 
                 this.GoldPressesAmount).ToString();
        }
        

        public void BuyGoldPress()
        {
            if (gold.GoldAmount < this.goldProductionData.basicCost) return;
            this.GoldPressesAmount++;
            gold.GoldAmount -= this.goldProductionData.basicCost;
            
            // Increase basicCost with 10%
            this.goldProductionData.basicCost = 
                 this.goldProductionData.basicCost * this.upgradeCostIncrease;
            this.SetUp(this.goldProductionData);
        }

        public void BuyUpgrade()
        {
            if (gold.GoldAmount < this.goldProductionData.upgradeCost || GoldPressesAmount == 0) return;
            this.UpgradeLevel++;
            this.upgradeValue = this.upgradeValue + this.upgradeLevelBonus ;
            Debug.Log(upgradeValue);
            this.gold.GoldAmount -= this.goldProductionData.upgradeCost;
            
            // Increase basicCost with 10%
            this.goldProductionData.upgradeCost = 
                (int) (this.goldProductionData.upgradeCost * this.upgradeCostIncrease);
            this.SetUp(this.goldProductionData);
        }
    }