using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    PlayerController player;
    int currentScene ;
    int index;
    public AudioSource chaseMusic;
    
    void Start()
    {
        currentScene = 0;
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("next level");
            index = Random.Range(1, 4);
            while (SceneManager.GetActiveScene().buildIndex == index)
            {
                index = Random.Range(1, 4);
            }
            SceneManager.LoadScene(index);
        }
    }
}
