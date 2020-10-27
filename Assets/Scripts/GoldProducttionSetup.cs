using UnityEngine;

public class GoldProducttionSetup : MonoBehaviour
{
    public GoldProductionData[] productionUnits;
    public Transform transformParent;
    public GameObject goldProductionUnitPrefab;

    private void Start()
    {
        foreach (var unit in this.productionUnits)
        {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.transformParent);
            instance.GetComponent<GoldProducer>().SetUp(unit);
        }
    }
}
