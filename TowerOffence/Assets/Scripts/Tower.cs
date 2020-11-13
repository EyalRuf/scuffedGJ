using UnityEngine;
using System.Collections;

public class Tower : Destructable
{
    public Player player;

    public override void Destroy()
    {
        Time.timeScale = 0;
        // WIN GAME
        Destroy(gameObject);
    }
}
