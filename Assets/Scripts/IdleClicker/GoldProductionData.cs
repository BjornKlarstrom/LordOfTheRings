using UnityEngine;

namespace IdleClicker
{
    [CreateAssetMenu]
    public class GoldProductionData : ScriptableObject
    {
        [SerializeField] int basicCost = 100;
        [SerializeField] float costMultiplier = 1.1f;
        public float productionTime = 1f;
        public float upgradeCost = 50;
        public float upgradeLevelBonus = 0.05f;
        public float upgradeLevel = 1f;

        public int ProductionAmount => this.ProductionAmount;

        public int GetActualCost(int amount)
        {
            var result = this.basicCost * Mathf.Pow(this.costMultiplier, amount);
            return Mathf.RoundToInt(result);
        }
    }
}