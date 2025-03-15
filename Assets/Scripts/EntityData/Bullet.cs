using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Scriptable Objects/EntityData/Bullet")]
public class Bullet : ScriptableObject
{
    public float speed = 4f;

    [Tooltip("Between 0 and PI, 0 meaning no spread at all, PI meaning completly random fire angle")]
    [Range(0, Mathf.PI)]
    public float spread = 0f;

    public uint duration = 5000;

    public EnumList.StatusEffect statusEffect = EnumList.StatusEffect.NORMAL;

    public uint statusDuration = 3000;

    public uint statusTickDelay = 750;

    public float entitySpeedMultiplier = 1f;
}
