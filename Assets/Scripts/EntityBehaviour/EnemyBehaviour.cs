using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static Projectile;

public class EnemyBehaviour : FightingEntityBehaviour
{

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public GameObject expPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        if(player == null)
        {
            player = FindObjectsByType<GameObject>(FindObjectsSortMode.None).ToList().Find(o => o.name == "PlayerContainer");
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!isAttacking)
        {
            transform.position += GetSpeed() * Time.deltaTime * GetDirection();
        }
    }
    public override Vector3 GetDirection()
    {
        return Vector3.Normalize(player.transform.position - transform.position);
    }

    protected override void Die()
    {
        base.Die();
        DropXP();
        Destroy(gameObject);
    }

    public void DropXP()
    {
        GameObject exp = Instantiate(expPrefab, gameObject.transform);
        exp.transform.parent = null;
    }
}
