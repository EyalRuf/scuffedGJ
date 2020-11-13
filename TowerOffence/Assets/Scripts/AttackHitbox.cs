using UnityEngine;
using System.Collections;

public class AttackHitbox : MonoBehaviour
{
    public Player player;
    public float damage;
    public float range;

    void Start ()
    {
        float scale = 1;
        if (range > 5)
        {
            scale = 5;
        } else
        {
            scale = range * 0.35f;
        }

        if (scale <= 1)
        {
            scale = 0;
        }

        transform.localScale = new Vector2(transform.localScale.x + scale, transform.localScale.y + scale);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Resource")
        {
            Resource r = collision.GetComponent<Resource>();
            r.SetLastAttacker(player);
            r.Damage(damage);
        }
        else if (collision.tag == "Player" && player.pInput.isP1 != collision.GetComponent<PlayerInput>().isP1)
        {
            Player p = collision.GetComponent<Player>();
            p.pLife.Damage(damage);
            p.pMovement.Knockback(player.transform.position);

        } else if (collision.tag == "Tower")
        {
            Tower tower = collision.GetComponent<Tower>();
            if (player.pInput.isP1 != tower.player.pInput.isP1)
            {
                tower.Damage(damage);
            }
        }
    }
}
