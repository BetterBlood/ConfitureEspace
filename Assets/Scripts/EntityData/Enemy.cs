using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/EntityData/Enemy")]
public class Enemy : FightingEntity
{
    public Enemy()
    {
        this.CanTakeTickDamage = true;
        this.CanBeSlowed = true;
        this.Power = 1;
    }

    public override string GetTarget()
    {
        return "Player";
    }
}
