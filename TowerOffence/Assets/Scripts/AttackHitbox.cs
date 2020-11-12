using UnityEngine;
using System.Collections;

public class AttackHitbox : MonoBehaviour
{
    public Player player;
    public float damage;
    public float range;

    void Start ()
    {
        transform.localScale *= range;
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
        }
    }
}
