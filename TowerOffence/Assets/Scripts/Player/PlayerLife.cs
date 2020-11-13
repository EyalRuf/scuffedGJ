using UnityEngine;
using System.Collections;

public class PlayerLife : Destructable
{
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

        // MOVE PLAYER TO START POS?
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Respawn()
    {
        base.Respawn();
        Player p = GetComponent<Player>();
        p.pAttack.enabled = true;
        p.pInput.enabled = true;
        p.pMovement.enabled = true;
        p.pResources.enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}

