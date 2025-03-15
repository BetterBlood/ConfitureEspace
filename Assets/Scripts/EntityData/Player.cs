using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/EntityData/Player")]
public class Player : FriendlyEntity
{
    public Player()
    {
        this.Hp = 3f;
        this.CanTakeTickDamage = false;
        this.CanHitDamage = false;
        this.EntityName = "";
        this.CanShoot = true;
        this.Speed = 5f;
    }
}
