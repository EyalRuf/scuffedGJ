using UnityEngine;
using System.Collections;

public class PlayerLife : Destructable
{
    Player p;

    void Start()
    {
         p = GetComponent<Player>();
    }

    public override void Destroy()
    {
        base.Destroy();
        Player p = GetComponent<Player>();

        if (p.pAttack.tool != null)
        {
            Destroy(p.pAttack.tool.gameObject);
            p.pAttack.tool = null;
        }

        p.pAttack.enabled = false;
        p.pInput.enabled = false;
        p.pMovement.enabled = false;
        p.pResources.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        p.pAudio.PlayDeathSound();
        // MOVE PLAYER TO START POS?
    }

    public new void Damage(float dmg)
    {
        p.pAudio.PlayBeingHitSound();
        base.Damage(dmg);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Respawn()
    {
        base.Respawn();
        
        p.pAttack.enabled = true;
        p.pInput.enabled = true;
        p.pMovement.enabled = true;
        p.pResources.enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        p.pAudio.PlayRespawnSound();
    }
}

