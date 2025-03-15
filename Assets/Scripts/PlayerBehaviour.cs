using System.Collections;
using UnityEngine;

public class PlayerBehaviour : FightingEntityBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        if (!IsAlive()) return;

        StartCoroutine(UnvulnerabilityCoroutine());

    }

    IEnumerator UnvulnerabilityCoroutine()
    {
        this.gameObject.GetComponent<Collider>().enabled = false;
        //TODO Faire clignoter le sprite
        yield return new WaitForSeconds(fightingEntity.UnvulnerabilityDuration / 1000f);
        this.gameObject.GetComponent<Collider>().enabled = false;
    }
}
