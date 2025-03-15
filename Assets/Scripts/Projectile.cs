using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static Projectile;
using static UnityEditor.PlayerSettings;


public class Projectile : MonoBehaviour
{
    public class ProjectileData
    {
        [SerializeField]
        private float power;

        [SerializeField]
        private float speed = 5;

        [SerializeField]
        [Tooltip("Between 0 and PI, 0 meaning no spread at all, PI meaning completly random fire angle")]
        [Range(0, Mathf.PI)]
        private float maxSpread;

        [SerializeField]
        private Vector3 direction;

        [SerializeField]
        private uint duration;

        [SerializeField]
        private EnumList.StatusEffect statusEffect;

        [SerializeField]
        private uint effectDuration;

        [SerializeField]
        private string targetTag;

        public ProjectileData(float p, float s, float maxS, Vector3 dirr, uint dur, EnumList.StatusEffect sE, uint eD, string tT)
        {
            power = p;
            speed = s;
            maxSpread = maxS;
            direction = dirr;
            duration = dur;
            statusEffect = sE;
            effectDuration = eD;
            targetTag = tT;
        }

        public Vector3 GetDirection()
        {
            return direction;
        }

        public float GetPower()
        {
            return power;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public float GetMaxSpread()
        {
            return maxSpread;
        }

        public float GetDuration()
        {
            return duration;
        }

        public EnumList.StatusEffect GetEffect()
        {
            return statusEffect;
        }

        public uint GetEffectDuration()
        {
            return effectDuration;
        }

        public string GetTag()
        {
            return targetTag;
        }

    }

    [SerializeField]
    private ProjectileData projectileData;

    private bool is_instantiate = false;

    private Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    private IEnumerator ManageDuration()
    {
        yield return new WaitForSeconds(projectileData.GetDuration() / 1000f);

        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_instantiate)
        {
            is_instantiate = true;

            // get mouse position TODO : remove after getting direction from caller
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            //Vector3 dest = ray.origin + ray.direction;

            // compute direction with spread
            //projectileData.direction = new Vector3(dest.x-transform.position.x, 0,  dest.z-transform.position.z).normalized; // TODO : remove after getting direction from caller
            //Debug.Log(projectileData.GetDirection());
            Vector3 target = transform.position + projectileData.GetDirection();
            transform.LookAt(target);


            // spread
            float randomSpread = Random.Range(-projectileData.GetMaxSpread(), projectileData.GetMaxSpread());
            transform.Rotate(Vector3.up, randomSpread);
            StartCoroutine(ManageDuration());
        }
        else
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            //Vector3 dest = ray.origin + ray.direction;

            //direction = new Vector3(dest.x - transform.position.x, 0, dest.z - transform.position.z).normalized;
            //Debug.Log(direction);
            transform.position += transform.right * Time.deltaTime * projectileData.GetSpeed();
            //Debug.Log(transform.position);
        }
    }

    public void setProjectileData(ProjectileData pData)
    {
        projectileData = pData;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision != null && collision.transform.CompareTag(projectileData.GetTag()))
        {
            // TODO : call hit on collider GameObject
            //collision.transform.gameObject.GetComponent("entityLogic").Hit(projectileData.GetPower(), projectileData.GetEffect(), projectileData.GetEffectDuration();
            Debug.Log("TODO : call Hit !!");
        }
    }

}
