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
        public float upgradeCostIncrease = 1.1f;
        public float upgradeLevelBonus = 0.05f;
        public float upgradeValue = 1f;
        
        float _timePassed;

        Gold gold;
        public Text floatingTextPrefab;
        
        float Amount {
            get => PlayerPrefs.GetFloat(this.goldProductionData.name, 0);
            set {
                PlayerPrefs.SetFloat(this.goldProductionData.name, value);
                UpdateInfoTexts();
            }
        }
        
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
            this.purchaseButtonText.text = $"{data.name}, ${data.basicCost}";
            this.costUpgradeText.text = $"Upgrade ${data.upgradeCost}";
        }

        public void ProduceGold() {
            gold.GoldAmount += this.upgradeValue * 
                               this.goldProductionData.productionAmount *
                               this.Amount;
                               
            
            //Trigger Text Animation
            if(this.Amount < 1) return;
            var instance = Instantiate(floatingTextPrefab, this.transform);
            instance.text =
                (this.upgradeValue * 
                 this.goldProductionData.productionAmount * 
                 this.Amount).ToString();
        }
        

        public void Purchase() {
            if (gold.GoldAmount < this.goldProductionData.basicCost) return;
            this.Amount++;
            gold.GoldAmount -= this.goldProductionData.basicCost;
            
            // Increase basicCost with 10%
            this.goldProductionData.basicCost = 
                this.goldProductionData.basicCost * this.upgradeCostIncrease;
            this.SetUp(this.goldProductionData);
        }

        public void BuyUpgrade() {
            if (gold.GoldAmount < this.goldProductionData.upgradeCost || Amount == 0) return;
            this.UpgradeLevel++;
            this.upgradeValue = this.upgradeValue + this.upgradeLevelBonus ;
            Debug.Log(upgradeValue);
            this.gold.GoldAmount -= this.goldProductionData.upgradeCost;
            
            // Increase basicCost with 10%
            this.goldProductionData.upgradeCost = 
                (int) (this.goldProductionData.upgradeCost * this.upgradeCostIncrease);
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
            if (this.goldProductionData.basicCost > gold.GoldAmount)
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