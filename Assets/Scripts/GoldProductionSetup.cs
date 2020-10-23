using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldProductionSetup : MonoBehaviour {

    public GoldProductionData[] goldProductionUnits;
    public Transform goldProductionUnitParent;
    public GameObject goldProductionUnitPrefab;

    void Start()
    {
        foreach (var unit in this.goldProductionUnits) {
            var instance = Instantiate(this.goldProductionUnitPrefab, this.goldProductionUnitParent);
            instance.GetComponent<GoldProducer>().SetUp(unit);
        }
    }
}