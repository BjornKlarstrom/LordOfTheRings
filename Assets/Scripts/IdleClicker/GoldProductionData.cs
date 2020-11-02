using UnityEngine;

namespace IdleClicker
{
    [CreateAssetMenu]
    public class GoldProductionData : ScriptableObject
    {
        public new string name = "GoldProducer";
        public float productionAmount = 1;
        public float basicCost = 100;
        public float upgradeCost = 50;
        public float productionTime = 1f;
    }
}