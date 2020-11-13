using UnityEngine;
using System.Collections;
using TMPro;

public class Tower : Destructable
{
    public Player player;

    public AudioSource towerHitAS;
    public AudioSource towerDiedAS;
    public AudioSource victoryAS;

    public TextMeshProUGUI towerHP;

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

    protected override void Update()
    {
        base.Update();
        towerHP.text = ((int) health).ToString();
    }
}
