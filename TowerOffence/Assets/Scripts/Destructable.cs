using UnityEngine;
using System.Collections;

public abstract class Destructable : MonoBehaviour
{
    public float startingHealth;
    public float health;

    public bool isRespawining = false;
    public float respawnCounter = 0;
    public float respawnTime = 1;

    public virtual void Damage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            this.Destroy();
        }
    }
    public virtual void Destroy()
    {
        respawnCounter = respawnTime;
        isRespawining = true;
    }

    protected virtual void Update()
    {
        if (isRespawining)
        {
            respawnCounter -= Time.deltaTime;

            if (respawnCounter <= 0)
            {
                this.Respawn();
            }
        }
    }

    protected virtual void Respawn ()
    {
        health = startingHealth;
        isRespawining = false;
    }
}
