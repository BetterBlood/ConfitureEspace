using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Objects/Enemy")]
public class Enemy : FightingEntity
{
    public Enemy(GameObject gameObject) : base(gameObject)
    {
        this.CanTakeTickDamage = true;
        this.Power = 1;
    }

    protected override string GetTarget()
    {
        return "Player";
    }
}
