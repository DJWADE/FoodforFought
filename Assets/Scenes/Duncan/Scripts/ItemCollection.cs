using UnityEngine;

public class ItemCollection : MonoBehaviour
{

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player");
        {
            audioSource.Play();
   
        }

    }
}
