using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    PlayerController player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("next level");
            int index = Random.Range(1, 4);
            SceneManager.LoadScene(index);
            player.resetInv();

        }
    }
}
