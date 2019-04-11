using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public float speed = 5;
    private Vector2 moveDirection = Vector2.zero;
    private CharacterController controller;


	void Update () {

        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        controller.Move(moveDirection * Time.deltaTime);

    }
}
