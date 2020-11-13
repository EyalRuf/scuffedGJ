using UnityEngine;
using System.Collections;
using System;

public class Resource : Destructable
{
    public PlayerResources lastPHitResources;
    public int resourceType; // 0 = wood, 1 = rock, 2 = metal

    public AudioSource resourceHitAS;
    public AudioClip resourceHitClip;

    void Start()
    {
        resourceHitAS.clip = resourceHitClip;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Destroy()
    {
        base.Destroy();

        // Hide then start respawning
        AddResourceToPlayer();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    protected override void Respawn()
    {
        base.Respawn();
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void AddResourceToPlayer()
    {
        switch (resourceType)
        {
            case 0:
                {
                    lastPHitResources.AddWood();
                    break;
                }
            case 1:
                {
                    lastPHitResources.AddRock();
                    break;
                }
            case 2:
                {
                    lastPHitResources.AddMetal();
                    break;
                }
            default:
                break;
        }
    }

    public new void Damage(float dmg)
    {
        resourceHitAS.Play();
        base.Damage(dmg);
    }

    public void SetLastAttacker(Player pr)
    {
        lastPHitResources = pr.pResources;
    }
}
