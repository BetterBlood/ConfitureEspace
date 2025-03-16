using UnityEngine;

[CreateAssetMenu(fileName = "FriendlyEntity", menuName = "Scriptable Objects/FriendlyEntity")]
public class FriendlyEntity : FightingEntity
{
    public FriendlyEntity()
    {

    }

    public override string GetTarget()
    {
        return "Enemy";
    }
}
