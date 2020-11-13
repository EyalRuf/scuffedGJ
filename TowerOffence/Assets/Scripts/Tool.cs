using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class Tool : MonoBehaviour
{
    public float range;
    public float durability;
    public float damage;
    public TextMeshProUGUI text;

    public void Attacked()
    {
        durability--;

        if (durability <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        text.text = durability.ToString();
    }
}
