using UnityEngine;
using UnityEngine.UI;

namespace IdleClicker
{
    public class GoldProducer : MonoBehaviour {
        public GoldProductionData goldProductionData;
        public Text purchaseButtonText;
        public Text goldPressesAmount;
        
        public Text costUpgradeText;
        public Text upgradeLevelText;

        float _timePassed;

        Gold gold;
        public ProductionPopUp popUpPrefab;
        
        int Amount {
            get => PlayerPrefs.GetInt(this.goldProductionData.name, 0);
            set {
                PlayerPrefs.SetInt(this.goldProductionData.name, value);
                UpdateInfoTexts();
            }
        }
        
        bool IsAffordable => FindObjectOfType<Gold>().GoldAmount >= this.goldProductionData.GetActualCost(this.Amount);
        
        float UpgradeLevel {
            get => PlayerPrefs.GetFloat($"{this.goldProductionData.name}UpgradeLevel", 0);
            set {
                PlayerPrefs.SetFloat($"{this.goldProductionData.name}UpgradeLevel", value);
                this.costUpgradeText.text = 
                    this.goldProductionData.upgradeCost.ToString($"Upgrade: ${this.goldProductionData.upgradeCost}");
                this.upgradeLevelText.text =
                    this.UpgradeLevel.ToString($"Level {this.UpgradeLevel}");
            }
        }

        public void SetUp(GoldProductionData data) {
            this.goldProductionData = data;
            this.gameObject.name = data.name;
            this.purchaseButtonText.text = $"{data.name}, ${this.goldProductionData.GetActualCost(this.Amount)}";
            this.costUpgradeText.text = $"Upgrade ${data.upgradeCost}";
        }

        public void ProduceGold() {
            if(this.Amount == 0) 
                return;
            
            gold.GoldAmount += this.goldProductionData.upgradeLevel * 
                               this.goldProductionData.ProductionAmount *
                               this.Amount;
            
            var instance = Instantiate(this.popUpPrefab, this.transform);
            instance.GetComponent<Text>().text =
                $"{this.goldProductionData.upgradeLevel * this.goldProductionData.ProductionAmount * this.Amount}";
        }
        

        public void Purchase() {
            if (this.IsAffordable)
            {
                gold.GoldAmount -= this.goldProductionData.GetActualCost(this.Amount);
                this.Amount += 1;
                this.purchaseButtonText.text = $"Purchase for {this.goldProductionData.GetActualCost(this.Amount)}";
            }
        }

        public void BuyUpgrade() {
            if (gold.GoldAmount < this.goldProductionData.upgradeCost || Amount == 0) return;
            this.UpgradeLevel++;
            this.goldProductionData.upgradeLevel++;
            this.gold.GoldAmount -= this.goldProductionData.upgradeCost;
            
            // Increase basicCost with 10%
            this.goldProductionData.upgradeCost = 
                (int) (this.goldProductionData.upgradeCost);
            this.SetUp(this.goldProductionData);
        }
        
        
        void Start() {
            gold = FindObjectOfType<Gold>();
            UpdateInfoTexts();
        }

        void Update() {
            Timer();
            ProductionReadyCheck();
            UpdateCostTextColor();
        }

        void Timer() {
            this._timePassed += Time.deltaTime;
        }
        
        void ProductionReadyCheck() {
            if (this._timePassed < this.goldProductionData.productionTime) return;
            ProduceGold();
            this._timePassed -= this.goldProductionData.productionTime;
        }
        
        void UpdateCostTextColor() {
            if (this.goldProductionData.GetActualCost(Amount) > gold.GoldAmount)
            {
                this.purchaseButtonText.color = Color.red;
            }
            else
            {
                this.purchaseButtonText.color = Color.green;
            }
        }

        void UpdateInfoTexts() {
            this.goldPressesAmount.text = 
                this.Amount.ToString($"0 {this.goldProductionData.name}");

            this.upgradeLevelText.text =
                this.UpgradeLevel.ToString($"Level {this.UpgradeLevel}");
        }
    }
}