using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    
    [Header("Combat Stats")]
    public int damager;
    public float weaponRange;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int moveSpeed;

    [Header("Health Stats")]
    public int maxHealth;
    public int health;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}