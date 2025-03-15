using UnityEngine;

[CreateAssetMenu(fileName = "FriendlyEntity", menuName = "Scriptable Objects/FriendlyEntity")]
public class FriendlyEntity : FightingEntity
{
    public FriendlyEntity(GameObject gameObject) : base(gameObject)
    {

    }

    protected override string GetTarget()
    {
        return "Enemy";
    }
}
