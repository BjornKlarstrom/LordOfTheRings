using UnityEngine;

public class GoldProductionSetup : MonoBehaviour {
        public GoldProductionData[] productionUnits;
        public GoldProducer goldProductionUnitPrefab;

        private void Start()
        {
            foreach (var unit in this.productionUnits)
            {
                var instance = Instantiate(this.goldProductionUnitPrefab, this.transform);
                instance.SetUp(unit);
            }
        }
    }

