using System;
using UnityEngine;
using UnityEngine.Events;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] bool destroyOnTriggerEnter = true;
    [SerializeField] string tagFilter   = "Player";
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public bool IsBossStage()
    {
        return true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter))
        {
            return;
        }
        onTriggerEnter.Invoke();
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
    void Update()
    {
        
    }
}
