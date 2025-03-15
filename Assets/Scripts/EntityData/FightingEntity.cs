using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingEntity", menuName = "Scriptable Objects/EntityData/FightingEntity")]
[System.Serializable]
public class FightingEntity : ScriptableObject
{
    [SerializeField]
    public string EntityName;

    [SerializeField]
    public float Hp;

    [SerializeField]
    public float SizeScale = 1f;

    [SerializeField]
    public float Speed = 1f;

    [SerializeField]
    public uint UnvulnerabilityDuration = 0;

    [SerializeField]
    public bool CanShoot = false;

    [SerializeField]
    public bool CanHitDamage = false;

    [SerializeField]
    public bool CanTakeTickDamage = false;

    [SerializeField]
    public bool CanBeSlowed = false;

    [SerializeField]
    public bool HasTickEffect = false;

    [SerializeField]
    public bool HasSlownessEffect = false;

    [SerializeField]
    public float FireRate = 0.5f;

    [SerializeField]
    public float Power = 1f;

    [SerializeField]
    public float TickDamageMultiplier = 0.1f;

    virtual public string GetTarget()
    {
        return "None";
    }
}
