using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public Texture2D[] levels;
    public Vector2 size = new Vector3(25, 12);
    private Texture2D currentLevel;
    private int placeholder;
    private Color currentPixel;

    void Start () {
        placeholder = Random.Range(0, 1);
        currentLevel = levels[placeholder];
    }

	void Update () {
        int x = Mathf.FloorToInt(transform.position.x / size.x * currentLevel.width);
        int y = Mathf.FloorToInt(transform.position.y / size.y * currentLevel.height);
        Vector2 pos = transform.position;
        pos.y = currentLevel.GetPixel(x, y).grayscale * size.y;
        pos.x = currentLevel.GetPixel(x, y).grayscale * size.x;

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("next level");
            currentLevel = levels[Random.Range(0, 1)];

        }
    }
}
