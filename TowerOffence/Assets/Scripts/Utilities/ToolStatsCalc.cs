using UnityEngine;
using System.Collections;

public static class ToolStatsCalc
{
    public const float WOOD_RANGE  = 1;
    public const float ROCK_RANGE  = 0.25f;
    public const float METAL_RANGE = 0.25f;

    public const float WOOD_DURABILITY  = 4;
    public const float ROCK_DURABILITY  = 8;
    public const float METAL_DURABILITY = 2;

    public const float WOOD_DAMAGE  = 4;
    public const float ROCK_DAMAGE  = 8;
    public const float METAL_DAMAGE = 2;

    public const float WOOD_HP  = 6;
    public const float ROCK_HP  = 12;
    public const float METAL_HP = 50;

    public const float FIST_DAMAGE = 0.75f;
    public const float FIST_RANGE = 1;

    public static float CalcToolRange(int wood, int rock, int metal)
    {
        float rng = 0;

        rng += wood * WOOD_RANGE;
        rng += rock > 0 ? ROCK_RANGE : 0;
        rng += metal > 0 ? METAL_RANGE : 0;

        return rng;
    }

    public static float CalcToolDurabilty(int wood, int rock, int metal)
    {
        float dur = 0;

        dur += wood > 0 ? WOOD_DURABILITY : 0;
        dur += rock * ROCK_DURABILITY; 
        dur += metal > 0 ? METAL_RANGE : 0;

        return dur;
    }

    public static float CalcToolDamage(int wood, int rock, int metal)
    {
        float dmg = 0;

        dmg += wood > 0 ? WOOD_DURABILITY : 0;
        dmg += rock > 0 ? ROCK_RANGE : 0;
        dmg += metal * METAL_DAMAGE;
        
        return dmg;
    }
}
