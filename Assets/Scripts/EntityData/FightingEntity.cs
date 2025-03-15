using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingEntity", menuName = "Scriptable Objects/FightingEntity")]
public class FightingEntity : ScriptableObject
{
    [Header("Entity Name")]
    public string EntityName { get; set; }

    [Header("HP")]
    public float Hp { get; set; }

    [Header("Size Scale")]
    public float SizeScale { get; set; } = 1f;

    [Header("Movement Speed")]
    public float Speed { get; set; } = 1f;

    [Header("Unvulnerability Duration (ms)")]
    public uint UnvulnerabilityDuration { get; set; } = 0;

    [Header("Can Shoot Bullets ?")]
    public bool CanShoot { get; set; } = false;

    [Header("Can hit damage ?")]
    public bool CanHitDamage { get; set; } = false;

    [Header("Can take Tick Damage ?")]
    public bool CanTakeTickDamage { get; set; } = false;

    [Header("Fire Rate")]
    public float FireRate { get; set; } = 1f;

    [Header("Power")]
    public float Power { get; set; } = 1f;

    [Header("Bullet Speed")]
    public float ProjSpeed { get; set; } = 1f;

    [Header("Bullet Spread")]
    public float ProjSpread { get; set; } = 0f;

    [Header("Bullet Duration (ms)")]
    public uint ProjDuration { get; set; } = 5000;

    [Header("Bullet Status Effect")]
    public EnumList.StatusEffect ProjStatusEffect { get; set; } = EnumList.StatusEffect.NORMAL;

    [Header("Bullet Status Duration (ms)")]
    public uint ProjStatusDuration { get; set; } = 0;

    public FightingEntity()
    {
    }

    virtual public string GetTarget()
    {
        return "None";
    }
}
