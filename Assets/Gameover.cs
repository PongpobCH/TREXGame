using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D Cactus)
    {
        if(Cactus.tag == "Player")
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(1);
        }
    }
}
