using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] Obstacle prefab;
    [SerializeField] float targetDelay = 3f;
    [SerializeField] float randomOffset = 5f;
    
    float currentDelay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }
        else
        {
            var newObstacle = Instantiate(prefab, GetRandomSpawnPosition(), quaternion.identity);
            currentDelay = targetDelay;
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(transform.position.x + Random.Range(-randomOffset, randomOffset), transform.position.y, transform.position.z);
    }
}
