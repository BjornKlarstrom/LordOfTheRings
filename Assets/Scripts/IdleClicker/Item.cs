using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {
    public int price;

    public string name {
        get {
            if(this == null)
                throw new System.Exception("I am destroyed.");
            return base.name;
        }
    }
}
