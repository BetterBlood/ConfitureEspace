using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool destroyOnTriggerEnter = true;
    [SerializeField] string tagFilter   = "Player";
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    [SerializeField] GameObject prefabToSpawn;
    private GameObject spawnedEnemy;
    
    //[SerializeField] Transform spawnPoint;
    [SerializeField] List<Transform> enemySpawnPoints = new List<Transform>();
    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
        {
            return;
        }
        onTriggerEnter.Invoke();
        for (int i = 0; i < enemySpawnPoints.Count; i++)
        {
            spawnedEnemy = Instantiate(prefabToSpawn, enemySpawnPoints[i].position, Quaternion.identity);
        }
        if (destroyOnTriggerEnter)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
        {
            return;
        }
        onTriggerExit.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
