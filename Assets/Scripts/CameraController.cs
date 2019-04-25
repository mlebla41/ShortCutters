using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    private float lorp;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
        lorp = Mathf.Lerp(0, 3, 0.2f);
    }
    
    void LateUpdate()
    {
        transform.position = (player.transform.position + offset) * lorp;
    }
}
