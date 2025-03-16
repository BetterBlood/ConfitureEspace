using System;
using UnityEngine;

public abstract class FightingEntityBehaviour : MonoBehaviour
{

    public FightingEntity fightingEntity;
    public Bullet bullet;

    public BulletBehaviour bulletBehaviour;

    [SerializeField]
    public GameObject projectile;

    public float hp;
    public float speed;
    public float fireRate;
    public float power;

    public bool canShoot = false;

    public bool hasTickEffect = false;
    public bool hasSlownessEffect = false;
    public bool isShooting = false;

    public float tickDamageValue = 0f;
    public uint tickPenaltyTimeLeft = 0;
    public uint timeBetweenTickDamages = 0;
    public uint timeUntilNextTickDamage = 0;

    public uint slowPenaltyTimeLeft = 0;
    public float speedMultiplier = 1f;

    public float shootTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        this.hp = fightingEntity.Hp;
        this.speed = fightingEntity.Speed;
        this.fireRate = fightingEntity.FireRate;
        this.power = fightingEntity.Power;
        this.canShoot = fightingEntity.CanShoot;
        this.hasTickEffect = fightingEntity.HasTickEffect;
        this.hasSlownessEffect = fightingEntity.HasSlownessEffect;
        this.bulletBehaviour = gameObject.AddComponent<BulletBehaviour>();

        if (bullet != null ) this.bulletBehaviour.SetData(bullet);

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        TryShoot();
        TryTick();
        CheckSlownessCountdown();
    }
    public abstract Vector3 GetDirection();

    public float GetSpeed() => speed * speedMultiplier;
    public bool HasSlownessEffect => hasSlownessEffect;
    public bool HasTickEffect => hasTickEffect;
    public bool IsShooting => isShooting;

    public void TryShoot()
    {
        if (!canShoot || projectile == null) {
            return;
        }

        shootTimer += Time.deltaTime;

        if (shootTimer > fireRate)
        {
            Shoot();
            shootTimer = 0f;
        }

        isShooting = shootTimer == 0f;
    }

    protected void Shoot()
    {
        Projectile.ProjectileData projectileData = new(power, bulletBehaviour, GetDirection(), fightingEntity.GetTarget());

        GameObject proj = Instantiate(projectile, this.transform);
        proj.GetComponent<Projectile>().setProjectileData(projectileData);
        proj.transform.parent = null;
    }

    public void TryTick()
    {
        if (!fightingEntity.CanTakeTickDamage) return;

        uint deltaTimeMS = (uint) Math.Ceiling(Time.deltaTime*1000);  // Pas idéal mais mieux que de perdre un damage tick à cause de ce qu'on perd après la virgule

        if (deltaTimeMS > tickPenaltyTimeLeft)
        {
            ResetTickStatus();

            if (timeUntilNextTickDamage <= tickPenaltyTimeLeft)
            {
                TickDamage();
            }
            return;
        }

        tickPenaltyTimeLeft -= deltaTimeMS;

        if (deltaTimeMS > timeUntilNextTickDamage)
        {
            timeUntilNextTickDamage = timeBetweenTickDamages + (timeUntilNextTickDamage - deltaTimeMS);
            TickDamage();

            return;
        }

        timeUntilNextTickDamage -= deltaTimeMS;
    }

    public void TickDamage()
    {
        TakeDamage(tickDamageValue);
    }

    public void ResetTickStatus()
    {
        hasTickEffect = false;
        tickDamageValue = 0;
        tickPenaltyTimeLeft = 0;
        timeBetweenTickDamages = 0;
        timeUntilNextTickDamage = 0;
    }

    public void CheckSlownessCountdown()
    {
        if(!fightingEntity.CanBeSlowed || slowPenaltyTimeLeft == 0) return;

        uint deltaTimeMS = (uint)(Time.deltaTime*1000);
        slowPenaltyTimeLeft = Math.Max(slowPenaltyTimeLeft - deltaTimeMS, 0);

        if (slowPenaltyTimeLeft == 0)
        {
            speedMultiplier = 1;
            hasSlownessEffect = false;
        }
    }

    public void Hit(float damage, BulletBehaviour bulletData = null)
    {
        if(bulletData == null || bulletData.StatusEffect == EnumList.StatusEffect.NORMAL)
        {
            TakeDamage(damage);
            return;
        }

        switch (bulletData.StatusEffect)
        {
            case EnumList.StatusEffect.TICK:
                ApplyTickStatusEffect(damage, bulletData.StatusDuration, bulletData.StatusTickDelay);
                break;

            case EnumList.StatusEffect.SLOW:
                ApplySlowStatusEffect(bulletData.StatusDuration, bulletData.EntitySpeedMultiplier);
                break;
        }
    }

    virtual protected void TakeDamage(float damage)
    {
        Debug.Log("DAMAGE OMG");
        if (this.hp - damage <= 0)
            Die();
        else
        {
            this.hp -= damage;
        }
    }

    public void ApplyTickStatusEffect(float damage, uint duration, uint tickDelay)
    {
        if (!fightingEntity.CanTakeTickDamage)
            return;

        hasTickEffect = true;
        tickDamageValue = damage * fightingEntity.TickDamageMultiplier;
        tickPenaltyTimeLeft = duration;
        timeBetweenTickDamages = tickDelay;
        timeUntilNextTickDamage = timeUntilNextTickDamage > 0 ? Math.Min(timeUntilNextTickDamage, timeBetweenTickDamages) : timeBetweenTickDamages;
    }

    public void ApplySlowStatusEffect(uint duration, float speedMultiplier)
    {
        if (!fightingEntity.CanBeSlowed) return;

        hasSlownessEffect = true;
        slowPenaltyTimeLeft = duration;
        this.speedMultiplier = speedMultiplier;
    }

    public bool IsAlive() { return this.hp > 0; }

    virtual protected void Die()
    {
        this.hp = 0;
    }
}
