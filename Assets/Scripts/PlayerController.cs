using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public float speed;
    private string Inventory;
    private bool rangeBoards = false;
    private bool placedBoards = false;
    public GameObject boardBridge;
    private bool placed = false;


    void start()
    {
    }
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (rangeBoards && Input.GetMouseButtonDown(0) && Inventory == "WoodenBoardPickup")
        {
            Debug.Log("Placed boards!");
            placed = true;
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
            rangeBoards = true;
            Debug.Log("in range");
            if (other.CompareTag("BoardBridge") && placed)
            {
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("BoardBridge"))
        {
            rangeBoards = false;
            Debug.Log("out of range");
        }
    }
}
