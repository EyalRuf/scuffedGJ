using UnityEngine;
using System.Collections;
using System;

public class Tool : MonoBehaviour
{
    public float range;
    public float durability;
    public float damage;

    public void Attacked()
    {
        durability--;

        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
