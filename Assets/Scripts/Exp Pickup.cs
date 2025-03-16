using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    public int expValue;
    public float rotationSpeedY = 1.0f;
    public float rotationSpeedX = 1.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeedX, rotationSpeedY, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ExperienceLevelController.instance.GetExp(expValue);

            Destroy(gameObject);
        }
    }
}
