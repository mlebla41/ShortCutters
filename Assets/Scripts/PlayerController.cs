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
    private Collider2D colBoardBridge;
    private Collider2D colZipline;
    private bool leverPulled;
    private bool leverRange;
    private bool rangeZipline;
    public Image InventoryBoards;
    public Image InventoryZipline;
    public Image InventoryEmpty;
    private AudioSource source;
    public AudioClip boardsSound;
    public AudioClip zipSound;

    LevelController levelControl = new LevelController();


    void start()
    {
        source = GetComponent<AudioSource>();
        InventoryBoards.enabled = false;
        InventoryEmpty.enabled = true;
        InventoryZipline.enabled = false;
    }
	void Update () {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + movement * Time.deltaTime * speed;

        if (rangeBoards && Input.GetMouseButtonDown(0) && Inventory == "WoodenBoardPickup")
        {
            Debug.Log("Placed boards!");
            placedBoards = true;
            colBoardBridge.GetComponentInChildren<BoxCollider2D>().enabled = false;
            colBoardBridge.GetComponent<SpriteRenderer>().enabled = true;
            source.PlayOneShot(boardsSound, 5);

        }
        if (!rangeBoards && placedBoards)
        {
            Debug.Log("removed boards!");
            placedBoards = false;
            colBoardBridge.GetComponentInChildren<BoxCollider2D>().enabled = true;
            colBoardBridge.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (rangeZipline && Input.GetMouseButtonDown(0) && Inventory == "ZiplinePickup")
        {
            Debug.Log("Placed Zipline!");
            placedZipline = true;
            colZipline.GetComponentInChildren<BoxCollider2D>().enabled = false;
            colZipline.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (!rangeZipline && placedZipline)
        {
            Debug.Log("removed Zipline!");
            placedBoards = false;
            colZipline.GetComponentInChildren<BoxCollider2D>().enabled = true;
            colZipline.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Inventory == "ZiplinePickup")
        {
            InventoryBoards.enabled = false;
            InventoryEmpty.enabled = false;
            InventoryZipline.enabled = true;
        }
        if (Inventory == "WoodenBoardPickup")
        {
            InventoryBoards.enabled = true;
            InventoryEmpty.enabled = false;
            InventoryZipline.enabled = false;
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
            colBoardBridge = other;
            rangeBoards = true;
            Debug.Log("in range");
            
        }
        if (other.CompareTag("Zipline"))
        {
            colZipline = other;
            rangeZipline = true;
            Debug.Log("in range");

        }
        if (other.CompareTag("Rough"))
        {
            speed = 1.5f;
        }
        if (other.CompareTag("Monster"))
        {
            levelControl.Respawn();
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
    public void resetInv()
    {
        Inventory = "";
        Debug.Log("Inv reset");
    }
}
