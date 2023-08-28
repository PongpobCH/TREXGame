using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime , 0 , 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<Player>(out var player))
        {
            player.TakeDamage();
        }
        
        Destroy(gameObject);
    }
}
