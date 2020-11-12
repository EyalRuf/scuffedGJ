using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{
    public Transform[] atkSpawnPositions;

    public float ATK_CD_TIME = 1f;

    public float atkCDTimer = 0f;

    public Player player;

    public GameObject atkHitboxPrefab;
    public Tool tool;


    // Update is called once per frame
    void Update()
    {
        atkCDTimer = atkCDTimer <= 0 ? 0 : atkCDTimer - Time.deltaTime;

        if (player.pInput.attack && atkCDTimer <= 0)
        {
            StartCoroutine(Attack());
            atkCDTimer = ATK_CD_TIME;
        } 
    }

    private IEnumerator Attack() 
    {
        AttackHitbox atkHitbox = Instantiate(atkHitboxPrefab, player.transform).GetComponent<AttackHitbox>();
        atkHitbox.damage = ToolStatsCalc.FIST_DAMAGE;
        atkHitbox.range = ToolStatsCalc.FIST_RANGE;

        if (tool != null)
        {
            atkHitbox.damage = tool.damage;
            atkHitbox.range = tool.range;
        }

        Vector2 spawnPos = new Vector2(atkSpawnPositions[player.pMovement.direction].localPosition.x, 
            atkSpawnPositions[player.pMovement.direction].localPosition.y);
        float posScale = (atkHitbox.range / 2) > 1 ? atkHitbox.range / 2 : 1;
        atkHitbox.transform.localPosition = new Vector2(spawnPos.x * posScale, spawnPos.y * posScale);
        atkHitbox.transform.rotation = atkSpawnPositions[player.pMovement.direction].rotation;
        atkHitbox.player = player;
        
        yield return new WaitForSeconds(.1f);

        Destroy(atkHitbox.gameObject);

        if (tool != null)
        {
            tool.Attacked();
        }
    }
}
