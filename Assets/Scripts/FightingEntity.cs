using System.IO;
using System.Linq.Expressions;
using UnityEngine;

[CreateAssetMenu(fileName = "FightingEntity", menuName = "Scriptable Objects/FightingEntity")]
public class FightingEntity : ScriptableObject
{
    [Header("Entity Name")]
    public string entityName;

    [Header("HP")]
    public float hp;

    [Header("Size Scale")]
    public float sizeScale = 1.0;

    [Header("Movement Speed")]
    public float speed = 1.0;

    public uint invincibilityMs = 0;

    [Header("Can Shoot Bullets ?")]
    public bool canShoot;

    [Header("Can hit damage ?")]
    public bool canHitDamage;

    [Header("Fire Rate")]
    public float fireRate = 1.0;

    [Header("Power")]
    public float power;

    [Header("Bullet Speed")]
    public float bulletSpeed = 1.0;

    [Header("Bullet Spread")]
    public float bulletSpread = 0;

    [Header("Bullet Duration (ms)")]
    public float bulletDurationMs = 0;

    private void shoot();

    private void hit();

    private void takeDamage(float damage)
    {
        if (hp - damage <= 0)
            die();
        else
        {
            hp -= damage;
        }
    }

    private void die();
}
