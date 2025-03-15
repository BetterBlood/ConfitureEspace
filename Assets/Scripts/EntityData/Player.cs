using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : FriendlyEntity
{
    public Player()
    {
        this.Hp = 3;
        this.CanTakeTickDamage = false;
        this.CanHitDamage = false;
        this.EntityName = "";
        this.CanShoot = true;
    }
}
