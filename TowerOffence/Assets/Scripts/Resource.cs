using UnityEngine;
using System.Collections;
using System;

public class Resource : Destructable
{
    public PlayerResources lastPHitResources;
    public int resourceType; // 0 = wood, 1 = rock, 2 = metal

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void Destroy()
    {
        AddResourceToPlayer();
        Destroy(gameObject);
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
        base.Damage(dmg);
    }

    public void SetLastAttacker(Player pr)
    {
        lastPHitResources = pr.pResources;
    }
}
