using UnityEditor;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float Speed { get; set; }
    public float Spread { get; set; }
    public uint Duration { get; set; }

    public EnumList.StatusEffect StatusEffect { get; set; }
    public uint StatusDuration { get; set; }
    public uint StatusTickDelay { get; set; }
    public float EntitySpeedMultiplier { get; set; }

    public void SetData(Bullet bullet)
    {
        Speed = bullet.speed;
        Spread = bullet.spread;
        Duration = bullet.duration;
        StatusEffect = bullet.statusEffect;
        StatusDuration = bullet.statusDuration;
        StatusTickDelay = bullet.statusTickDelay;
        EntitySpeedMultiplier = bullet.entitySpeedMultiplier;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
