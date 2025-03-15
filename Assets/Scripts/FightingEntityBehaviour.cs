using UnityEngine;
using UnityEngine.Rendering;

public class FightingEntityBehaviour : MonoBehaviour
{

    public FightingEntity fightingEntity;

    private float hp;
    private float speed;
    private float fireRate;
    private float power;
    private float projSpeed;
    private float projSpread;
    private uint projDuration;
    private uint projStatusDuration;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        this.hp = fightingEntity.Hp;
        this.speed = fightingEntity.Speed;
        this.fireRate = fightingEntity.FireRate;
        this.power = fightingEntity.Power;
        this.projSpeed = fightingEntity.ProjSpeed;
        this.projSpread = fightingEntity.ProjSpread;
        this.projDuration = fightingEntity.ProjDuration;
        this.projStatusDuration = fightingEntity.ProjStatusDuration;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Vector3 GetDirection()
    {
        return this.gameObject.transform.rotation * Vector3.right;
    }

    private void Shoot()
    {
        Projectile.ProjectileData projectileData = new(power, projSpeed, projSpread, GetDirection(), projDuration, fightingEntity.ProjStatusEffect, projStatusDuration, fightingEntity.GetTarget());

        // Projectile proj = gameObject.AddComponent<Projectile>();
        // proj.setProjectileData(projectileData);
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
        if (this.hp - damage <= 0)
            Die();
        else
        {
            this.hp -= damage;
        }
    }

    private void ApplyTickStatusEffect(uint statusDuration)
    {
        if (!fightingEntity.CanTakeTickDamage)
            return;


    }

    private void ApplySlowStatusEffect(uint statusDuration)
    {

    }

    protected bool IsAlive() { return this.hp > 0; }

    virtual protected void Die()
    {
        this.hp = 0;
    }
}
