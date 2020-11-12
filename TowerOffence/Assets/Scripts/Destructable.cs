using UnityEngine;
using System.Collections;

public abstract class Destructable : MonoBehaviour
{
    public float health;

    public void Damage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            this.Destroy();
        }
    }
    public abstract void Destroy();
}
