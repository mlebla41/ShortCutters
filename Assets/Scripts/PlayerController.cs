using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public float speed;
    private string Inventory;
    private bool rangeBoards = false;
    private bool placedBoards = false;
    private bool placedZipline = false;
    public GameObject boardBridge;
    private Collider2D col;
    private bool leverPulled;
    private bool leverRange;
    private bool rangeZipline;


    void start()
    {
    }
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (rangeBoards && Input.GetMouseButtonDown(0) && Inventory == "WoodenBoardPickup")
        {
            Debug.Log("Placed boards!");
            placedBoards = true;
            col.GetComponentInChildren<BoxCollider2D>().enabled = false;
            col.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!rangeBoards && placedBoards)
        {
            Debug.Log("removed boards!");
            placedBoards = false;
            col.GetComponentInChildren<BoxCollider2D>().enabled = true;
            col.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (rangeZipline && Input.GetMouseButtonDown(0) && Inventory == "ZiplinePickup")
        {
            Debug.Log("Placed Zipline!");
            placedZipline = true;
            col.GetComponentInChildren<BoxCollider2D>().enabled = false;
            col.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!rangeZipline && placedZipline)
        {
            Debug.Log("removed Zipline!");
            placedBoards = false;
            col.GetComponentInChildren<BoxCollider2D>().enabled = true;
            col.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            Inventory = other.gameObject.name;
            Debug.Log("Your pickup is now: " + Inventory + " as a thing");

        }
        if (other.CompareTag("BoardBridge"))
        {
            col = other;
            rangeBoards = true;
            Debug.Log("in range");
            
        }
        if (other.CompareTag("Zipline"))
        {
            col = other;
            rangeZipline = true;
            Debug.Log("in range");

        }
        if (other.CompareTag("Rough"))
        {
            speed = 1;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BoardBridge"))
        {
            rangeBoards = false;
            Debug.Log("out of range");
        }
        if (other.CompareTag("Zipline"))
        {
            rangeZipline = false;
            Debug.Log("out of range");
        }
        if (other.CompareTag("Rough"))
        {
            speed = 3;
        }
    }
}
