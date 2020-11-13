using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{
    public Transform[] atkSpawnPositions;

    public float atkCDTimer = 0f;
    public float slapCDTimer = 0f;
    public float ATK_CD_TIME = 1f;
    public float SLAP_CD_TIME = 0.5f;
    public float SHARED_CD_TIME = 0.5f;


    public Player player;

    public GameObject atkHitboxPrefab;
    public Tool tool;

    // Update is called once per frame
    void Update()
    {
        atkCDTimer = atkCDTimer <= 0 ? 0 : atkCDTimer - Time.deltaTime;

        if (player.pInput.attack && atkCDTimer <= 0)
        {
            if (tool != null)
            {
                StartCoroutine(Attack());
                atkCDTimer = ATK_CD_TIME;
                slapCDTimer = SHARED_CD_TIME;
            }
        }

        slapCDTimer = slapCDTimer <= 0 ? 0 : slapCDTimer - Time.deltaTime;

        if (player.pInput.slap && slapCDTimer <= 0)
        {
            StartCoroutine(Slap());
            slapCDTimer = SLAP_CD_TIME;
            atkCDTimer = SHARED_CD_TIME;
        }
    }

    private IEnumerator Attack() 
    {
        AttackHitbox atkHitbox = Instantiate(atkHitboxPrefab, player.transform).GetComponent<AttackHitbox>();
        atkHitbox.damage = tool.damage;
        atkHitbox.range = tool.range;

        Vector2 spawnPos = new Vector2(atkSpawnPositions[player.pMovement.direction].localPosition.x, 
            atkSpawnPositions[player.pMovement.direction].localPosition.y);
        float posScale = (atkHitbox.range / 2) > 1 ? atkHitbox.range / 2 : 1;
        atkHitbox.transform.localPosition = new Vector2(spawnPos.x * posScale, spawnPos.y * posScale);
        atkHitbox.transform.rotation = atkSpawnPositions[player.pMovement.direction].rotation;
        atkHitbox.player = player;

        player.pAnimations.AttackAnimation();
        
        yield return new WaitForSeconds(.05f);

        Destroy(atkHitbox.gameObject);

        tool.Attacked();
    }
    private IEnumerator Slap()
    {
        AttackHitbox atkHitbox = Instantiate(atkHitboxPrefab, player.transform).GetComponent<AttackHitbox>();
        atkHitbox.damage = ToolStatsCalc.FIST_DAMAGE;
        atkHitbox.range = ToolStatsCalc.FIST_RANGE;

        atkHitbox.transform.localPosition = atkSpawnPositions[player.pMovement.direction].localPosition;
        atkHitbox.transform.rotation = Quaternion.Inverse(atkSpawnPositions[player.pMovement.direction].rotation);
        atkHitbox.player = player;

        player.pAnimations.SlapAnimation();

        yield return new WaitForSeconds(.05f);
        
        Destroy(atkHitbox.gameObject);
    }
}
