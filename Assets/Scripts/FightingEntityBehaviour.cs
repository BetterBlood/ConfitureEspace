using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class FightingEntityBehaviour : MonoBehaviour
{

    public FightingEntity fightingEntity;

    [SerializeField]
    private GameObject projectile;


    private float hp;
    private float speed;
    private float fireRate;
    private float power;
    private float projSpeed;
    private float projSpread;
    private uint projDuration;
    private uint projStatusDuration;

    private float timer = 0f;
    
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
        timer += Time.deltaTime;

        if (timer > 3f)
        {
            Shoot();
            timer = 0f;
        }
    }
    protected abstract Vector3 GetDirection();

    private void Shoot()
    {
        Projectile.ProjectileData projectileData = new(power, projSpeed, projSpread, GetDirection(), projDuration, fightingEntity.ProjStatusEffect, projStatusDuration, fightingEntity.GetTarget());

        GameObject proj = Instantiate(projectile, this.transform);
        proj.transform.parent = null;
        proj.GetComponent<Projectile>().setProjectileData(projectileData);
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
