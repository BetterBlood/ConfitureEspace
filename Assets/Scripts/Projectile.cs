using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public class ProjectileData
    {
        [SerializeField]
        public float power = 1f;

        [SerializeField]
        public BulletBehaviour bulletBehaviour;

        [SerializeField]
        public Vector3 direction = new Vector3(1, 0, 0);

        [SerializeField]
        public string targetTag = "Enemy";

        public ProjectileData(float p, BulletBehaviour bB, Vector3 dirr, string tT)
        {
            power = p;
            bulletBehaviour = bB;
            direction = dirr;
            targetTag = tT;
        }

        public Vector3 GetDirection() => direction;

        public float GetPower() => power;

        public float GetSpeed() => bulletBehaviour.Speed;

        public float GetMaxSpread() => bulletBehaviour.Spread;

        public float GetDuration() => bulletBehaviour.Duration;

        public EnumList.StatusEffect GetEffect() => bulletBehaviour.StatusEffect;

        public uint GetEffectDuration() => bulletBehaviour.StatusDuration;

        public uint GetStatusTickDelay() => bulletBehaviour.StatusTickDelay;

        public float GetEntitySpeedMultiplier() => bulletBehaviour.EntitySpeedMultiplier;

        public string GetTag() => targetTag;

    }

    [SerializeField]
    private ProjectileData projectileData;

    private bool isInstantiate = false;

    //private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cam = Camera.main;
    }

    private IEnumerator ManageDuration()
    {
        yield return new WaitForSeconds(projectileData.GetDuration() / 1000f);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!is_instantiate)
        //{
        // get mouse position TODO : remove after getting direction from caller
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        //Vector3 dest = ray.origin + ray.direction;

        // compute direction with spread
        //projectileData.direction = new Vector3(dest.x-transform.position.x, 0,  dest.z-transform.position.z).normalized; // TODO : remove after getting direction from caller
        //Debug.Log(projectileData.GetDirection());
        //Vector3 target = transform.position + projectileData.GetDirection();
        //transform.LookAt(target);


        //// spread
        //float randomSpread = Random.Range(-projectileData.GetMaxSpread(), projectileData.GetMaxSpread());
        //transform.Rotate(Vector3.up, randomSpread);
        //}
        //else
        //{
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        //Vector3 dest = ray.origin + ray.direction;

        //direction = new Vector3(dest.x - transform.position.x, 0, dest.z - transform.position.z).normalized;
        //Debug.Log(direction);
        //transform.position += transform.right * Time.deltaTime * projectileData.GetSpeed();
        //Debug.Log(transform.position);
        //}

        if (isInstantiate) transform.position += transform.forward * Time.deltaTime * projectileData.GetSpeed();
        else Debug.Log("Need To instantiate ProjectileData with setProjectileData");
        
    }

    public void setProjectileData(ProjectileData pData)
    {
        projectileData = pData;
        // TODO : set projectile color ?

        Vector3 target = transform.position + projectileData.GetDirection();
        transform.LookAt(target);

        float randomSpread = Random.Range(-projectileData.GetMaxSpread(), projectileData.GetMaxSpread());
        transform.Rotate(Vector3.up, randomSpread);

        isInstantiate = true;

        StartCoroutine(ManageDuration());
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider != null && collider.transform.CompareTag(projectileData.GetTag()))
        {
            collider.transform.gameObject.GetComponent<FightingEntityBehaviour>().Hit(projectileData.GetPower(), projectileData.bulletBehaviour);
        }
    }

}
