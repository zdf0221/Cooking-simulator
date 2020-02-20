using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    public GameObject Apple;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 15f;
    private float nextSpawnTime;

    public Transform spawnDirectionTransform;
    public float spawnForce;

    // Start is called before the first frame update
    void Start()
    {
        SpawnItem();
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnItem();
            nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime) + Time.time;
        }
    }

    public GameObject SpawnItem()
    {
        GameObject item = Instantiate(Apple, transform.position, transform.rotation) as GameObject;
        item.transform.localScale = new Vector3(1, 1, 1);
        item.GetComponentInChildren<Rigidbody>().AddForce(spawnDirectionTransform.forward * spawnForce);
        return item;
    }
}
