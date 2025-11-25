using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StatsManager.Instance.health = StatsManager.Instance.maxHealth;
        slider.maxValue = StatsManager.Instance.maxHealth;
        slider.value = StatsManager.Instance.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        StatsManager.Instance.health -= amount;
        slider.value = StatsManager.Instance.health;

        if(StatsManager.Instance.health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.health += amount;
        if(StatsManager.Instance.health > StatsManager.Instance.maxHealth) 
        {
            StatsManager.Instance.health = StatsManager.Instance.maxHealth;
        }
        slider.value = StatsManager.Instance.health;
    }

}
