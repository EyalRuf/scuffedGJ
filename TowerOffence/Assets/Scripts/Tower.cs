using UnityEngine;
using System.Collections;

public class Tower : Destructable
{
    public Player player;

    public AudioSource towerHitAS;
    public AudioSource towerDiedAS;
    public AudioSource victoryAS;

    public override void Destroy()
    {
        //towerDiedAS.Play();
        victoryAS.Play();
        Time.timeScale = 0;
        // WIN GAME
        Destroy(gameObject);
    }

    public new void Damage(float dmg)
    {
        towerHitAS.Play();
        base.Damage(dmg);
    }
}
