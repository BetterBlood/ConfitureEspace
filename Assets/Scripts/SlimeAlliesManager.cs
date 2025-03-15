using System;
using UnityEngine;

public class SlimeAlliesManager : MonoBehaviour
{

    [SerializeField]
    private float radius = 5f;
    [SerializeField]
    private GameObject[] allies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnSlimes();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Camera.main.transform.position, -Vector3.up); // TODO : export dans un script à part ?
    }

    public void SpawnSlimes()
    {
        int alliesNumber = allies.Length;

        if (alliesNumber == 0) return;

        float incr = 2 * MathF.PI / alliesNumber;

        for (int i = 0; i < alliesNumber; i++)
        {
            Vector3 point;
            point.x = transform.position.x + radius * Mathf.Cos(i * incr);
            point.y = 0;
            point.z = transform.position.z + radius * Mathf.Sin(i * incr);
            GameObject g = Instantiate(allies[i], point, transform.rotation);
            g.transform.SetParent(transform);
        }
    }
}
