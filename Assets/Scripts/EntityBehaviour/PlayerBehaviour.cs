using System.Collections;
using UnityEngine;
using static Projectile;

public class PlayerBehaviour : FightingEntityBehaviour
{

    [SerializeField]
    private GameObject direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        UIController.instance.UpdateLife((int)hp);
    }

    public override Vector3 GetDirection()
    {
        return direction.transform.forward;
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UIController.instance.UpdateLife((int) hp);

        if (!IsAlive()) return;

        StartCoroutine(UnvulnerabilityCoroutine());

    }

    IEnumerator UnvulnerabilityCoroutine()
    {
        isUnvulnerable = true;
        //TODO Faire clignoter le sprite
        yield return new WaitForSeconds(fightingEntity.UnvulnerabilityDuration / 1000f);
        isUnvulnerable = false;
    }

    protected override void Die()
    {
        base.Die();
        // GAME OVER
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider != null && collider.gameObject.CompareTag(fightingEntity.GetTarget()))
        {
            FightingEntityBehaviour feb = collider.gameObject.GetComponent<FightingEntityBehaviour>();
            feb.TriggerHit(this);
        }
    }
}
