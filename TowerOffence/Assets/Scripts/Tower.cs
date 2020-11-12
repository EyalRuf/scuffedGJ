using UnityEngine;
using System.Collections;

public class Tower : Destructable
{
    public override void Destroy()
    {
        Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
