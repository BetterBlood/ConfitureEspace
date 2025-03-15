using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlimeAlliesManager : MonoBehaviour
{

    [SerializeField]
    private float radius = 3f;
    [SerializeField]
    private GameObject ally;
    private LinkedList<GameObject> allies = new LinkedList<GameObject> ();
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnSlimes();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            timer = 0;
            if (allies.Count > 7)
            {
                //RemoveLastSlime();
            }
            //else AddSlime(ally);
        }
    }

    public void SpawnSlimes()
    {
        int alliesNumber = allies.Count;

        if (alliesNumber <= 0) return;

        float incr = 2 * MathF.PI / alliesNumber;

        for (int i = 0; i < alliesNumber; i++)
        {
            Vector3 point;
            point.x = transform.position.x + radius * Mathf.Cos(i * incr);
            point.y = transform.position.y;
            point.z = transform.position.z + radius * Mathf.Sin(i * incr);
            GameObject g = Instantiate(allies.ElementAt(i), point, transform.rotation);
            g.transform.SetParent(transform);
        }
    }

    public void ReComputeSlimesPositions(int size)
    {
        int alliesNumber = allies.Count;

        if (alliesNumber <= 0) return;

        float incr = 2 * MathF.PI / (size);

        for (int i = 0; i < alliesNumber; i++)
        {
            Vector3 point;

            point.x = transform.position.x + radius * Mathf.Cos(i * incr);
            point.y = transform.position.y;
            point.z = transform.position.z + radius * Mathf.Sin(i * incr);

            allies.ElementAt(i).transform.SetPositionAndRotation(point, transform.rotation);
        }
    }

    public void AddSlime(GameObject new_slime)
    {
        int alliesNumber = allies.Count;
        ReComputeSlimesPositions(alliesNumber + 1);

        float incr = 2 * MathF.PI / (alliesNumber + 1);

        Vector3 point = Vector3.zero;
        point.x = transform.position.x + radius * Mathf.Cos(alliesNumber * incr);
        point.y = transform.position.y;
        point.z = transform.position.z + radius * Mathf.Sin(alliesNumber * incr);

        GameObject g = Instantiate(new_slime, point, transform.rotation);
        g.transform.SetParent(transform);
        allies.AddLast(g);
    }

    public void RemoveLastSlime()
    {
        GameObject slimeToDestroy = allies.ElementAt(allies.Count - 1);
        allies.RemoveLast();
        Destroy(slimeToDestroy);
        ReComputeSlimesPositions(allies.Count);
    }

}
