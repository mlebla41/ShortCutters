using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour {
    private GameObject player;
    private GameObject gate;
    private bool range = false;
    private bool leverPulled = false;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gate = GameObject.FindGameObjectWithTag("Gate");

    }
	void Update () {
        if (range && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pulled lever!");
            leverPulled = true;
            gate.GetComponent<BoxCollider2D>().enabled = false;
            gate.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            range = true;
            Debug.Log("in range of lever");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            range = false;
            Debug.Log("out of range");
        }
    }
}
