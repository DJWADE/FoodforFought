using UnityEngine;
using static ItemSO;
using static Unity.VisualScripting.Member;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int amountToChangeAttribute;
   


    public bool UseItem()
    {

        if (statToChange == StatToChange.health)
        {
            Health playerHealth = GameObject.Find("Player").GetComponent<Health>();
            if(playerHealth.health >= playerHealth.maxHealth)
            {
                return false;
            }
            else
            {
                playerHealth.ChangeHealth(amountToChangeStat);
                return true;
            }
        }
        return false;
    }
    public enum StatToChange
    {
        none,
        health
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        speed
    };
}
