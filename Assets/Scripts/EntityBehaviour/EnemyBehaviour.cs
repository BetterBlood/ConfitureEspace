using UnityEngine;

public class EnemyBehaviour : FightingEntityBehaviour
{

    [SerializeField]
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.position += GetSpeed() * Time.deltaTime * GetDirection();
    }
    public override Vector3 GetDirection()
    {
        return Vector3.Normalize(player.transform.position - transform.position);
    }
}
