using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingEntity", menuName = "Scriptable Objects/FightingEntity")]
public class FightingEntity : ScriptableObject
{
    [Header("Entity Name")]
    protected string EntityName { get; set; }

    [Header("HP")]
    protected float Hp { get; set; }

    [Header("Size Scale")]
    protected float SizeScale { get; set; } = 1f;

    [Header("Movement Speed")]
    protected float Speed { get; set; } = 1f;

    [Header("Unvulnerability Duration (ms)")]
    protected uint UnvulnerabilityDuration { get; set; } = 0;

    [Header("Can Shoot Bullets ?")]
    protected bool CanShoot { get; set; } = false;

    [Header("Can hit damage ?")]
    protected bool CanHitDamage { get; set; } = false;

    [Header("Can take Tick Damage ?")]
    protected bool CanTakeTickDamage { get; set; } = false;

    [Header("Fire Rate")]
    protected float FireRate { get; set; } = 1f;

    [Header("Power")]
    protected float Power { get; set; } = 1f;

    [Header("Bullet Speed")]
    protected float ProjSpeed { get; set; } = 1f;

    [Header("Bullet Spread")]
    protected float ProjSpread { get; set; } = 0f;

    [Header("Bullet Duration (ms)")]
    protected uint ProjDuration { get; set; } = 0;

    [Header("Bullet Status Effect")]
    protected EnumList.StatusEffect ProjStatusEffect { get; set; } = EnumList.StatusEffect.NORMAL;

    [Header("Bullet Status Duration (ms)")]
    protected uint ProjStatusDuration { get; set; } = 0;

    protected GameObject GameObject { get; }

    protected FightingEntity(GameObject gameObject)
    {
        this.GameObject = gameObject;
    }

    virtual protected string GetTarget()
    {
        return null;
    }

    private Vector3 GetDirection()
    {
        return Vector3.zero;
        // return this.GameObject.transform.
    }

    private void Shoot()
    {
        // Projectile.ProjectileData projectileData = new(this.Power, this.ProjSpeed, this.ProjSpread, this.GetDirection(), this.ProjDuration, this.ProjStatusEffect, this.ProjStatusDuration, this.GetTarget());
    }

    public void Hit(float damage, EnumList.StatusEffect statusEffect = EnumList.StatusEffect.NORMAL, uint statusDuration = 0)
    {
        switch (statusEffect)
        {
            case EnumList.StatusEffect.NORMAL:
                TakeDamage(damage);
                break;
            case EnumList.StatusEffect.TICK:
                ApplyTickStatusEffect(statusDuration);
                break;

            case EnumList.StatusEffect.SLOW:
                ApplySlowStatusEffect(statusDuration);
                break;
        }
    }

    virtual protected void TakeDamage(float damage)
    {
        if (this.Hp - damage <= 0)
            Die();
        else
        {
            this.Hp -= damage;
        }
    }

    private void ApplyTickStatusEffect(uint statusDuration)
    {
        if (!this.CanTakeTickDamage)
            return;


    }

    private void ApplySlowStatusEffect(uint statusDuration)
    {

    }

    protected bool IsAlive() { return Hp > 0; }

    virtual protected void Die()
    {
        this.Hp = 0;
    }
}
