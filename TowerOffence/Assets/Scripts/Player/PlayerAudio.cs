using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour
{
    Player p;

    public AudioSource walkingAS;
    public AudioSource respawnAS;
    public AudioSource resourceAS;
    public AudioSource equipAS;
    public AudioSource beingHitAS;
    public AudioSource deathAS;

    // Use this for initialization
    void Start()
    {
        p = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.pMovement.isWalking)
        {
            if (!walkingAS.gameObject.activeSelf)
                walkingAS.gameObject.SetActive(true);
        } else
        {
            if (walkingAS.gameObject.activeSelf)
                walkingAS.gameObject.SetActive(false);
        }
    }

    public void PlayRespawnSound ()
    {
        respawnAS.Play();
    }

    public void PlayResourceSound()
    {
        resourceAS.Play();
    }

    public void PlayEquipSound()
    {
        equipAS.Play();
    }

    public void PlayBeingHitSound()
    {
        beingHitAS.Play();
    }

    public void PlayDeathSound()
    {
        deathAS.Play();
    }
}
