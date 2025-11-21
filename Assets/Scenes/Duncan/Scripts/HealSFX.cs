using UnityEngine;
using static ItemSO;

public class HealSFX : MonoBehaviour
{
    public StatToChange statToChange = new StatToChange();
    public AudioSource source;
    public AudioClip clip;

    // Update is called once per frame
    void Update()
    {
        if(statToChange == StatToChange.health)
        {
            Health playerHealth = GameObject.Find("Player").GetComponent<Health>();
            if (playerHealth.health == playerHealth.maxHealth)
            {
                source.PlayOneShot(clip);
            }
            
        }
    }
}
