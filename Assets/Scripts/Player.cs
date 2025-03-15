using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Scriptable Objects/Player")]
public class Player : FriendlyEntity
{
    public Player(GameObject gameObject) : base(gameObject)
    {
        this.Hp = 3;
        this.CanTakeTickDamage = false;
        this.CanHitDamage = false;
        this.EntityName = "";
        this.CanShoot = true;
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (!IsAlive()) return;

        //TODO Appeler méthode pour rendre invulnérable sur le GameObject
    }
}
