using UnityEngine;
using System.Collections;
using System;
using TMPro;

[RequireComponent(typeof(Player))]
public class PlayerResources : MonoBehaviour
{
    public Player player;

    public int wood = 0;
    public int rock = 0;
    public int metal = 0;

    public GameObject toolPrefab;
    public TextMeshProUGUI woodTMP;
    public TextMeshProUGUI rockTMP;
    public TextMeshProUGUI metalTMP;

    // Update is called once per frame
    void Update()
    {
        if (player.pInput.craft && (wood > 0 || rock > 0 || metal > 0)) {
            CraftTool();
        }

        woodTMP.text = wood.ToString();
        rockTMP.text = rock.ToString();
        metalTMP.text = metal.ToString();
    }

    private void CraftTool()
    {
        if (player.pAttack.tool)
        {
            Destroy(player.pAttack.tool.gameObject);
        }

        Tool craftedTool = Instantiate(toolPrefab, player.transform).GetComponent<Tool>();

        craftedTool.range = ToolStatsCalc.CalcToolRange(wood, rock, metal);
        craftedTool.durability = ToolStatsCalc.CalcToolDurabilty(wood, rock, metal);
        craftedTool.damage = ToolStatsCalc.CalcToolDamage(wood, rock, metal);
        craftedTool.GetComponent<ToolPositioning>().pMovement = player.pMovement;

        player.pAttack.tool = craftedTool;
        player.pAudio.PlayEquipSound();

        wood = 0;
        rock = 0;
        metal = 0;
    }

    public void AddWood()
    {
        player.pAudio.PlayResourceSound();
        wood++;
    }
    public void AddRock()
    {
        player.pAudio.PlayResourceSound();
        rock++;
    }
    public void AddMetal()
    {
        player.pAudio.PlayResourceSound();
        metal++;
    }
}