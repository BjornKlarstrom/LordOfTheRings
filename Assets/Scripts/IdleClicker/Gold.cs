using UnityEngine;
using UnityEngine.UI;

namespace IdleClicker
{
    public class Gold : MonoBehaviour {
        public float goldPerClick = 5.0f;
        public Text goldAmountText;
        private const string goldPlayerPrefsKey = "Gold";

        public float GoldAmount {
            get => PlayerPrefs.GetFloat(goldPlayerPrefsKey, 0.0f);
            set
            {
                PlayerPrefs.SetFloat(goldPlayerPrefsKey, value);
                this.goldAmountText.text = this.GoldAmount.ToString("Gold 0.0");
            }
        }
    
        void UpdateGoldAmountLabel() {
            this.goldAmountText.text = this.GoldAmount.ToString("Gold 0.0");
        }

        void Start() {
            UpdateGoldAmountLabel();
        }
    
        public void ProduceGold() {
            this.GoldAmount += this.goldPerClick;
        }
    }
}
