using System.Linq;
using UnityEngine;

public class AllySlimeBehaviour : FightingEntityBehaviour
{
    [SerializeField]
    private Transform direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        GameObject pc = FindObjectsByType<GameObject>(FindObjectsSortMode.None).ToList().Find(o => o.name == "PlayerContainer");

        if(pc != null )
        {
            direction = pc.transform.Find("Direction");
        }
    }

    public override Vector3 GetDirection()
    {
        return direction.forward;
    }
}
