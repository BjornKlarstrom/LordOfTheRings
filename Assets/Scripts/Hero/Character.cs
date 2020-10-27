using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 100;
    public float chargingAttackTime = 1.0f;
    public float attackDamage = 5.0f;

    public void Attack()
    {
        Debug.Log("Hej");
    }
}
