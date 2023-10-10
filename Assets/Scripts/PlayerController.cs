using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;

    public float moveSpeed;

    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Move() {
        if (!isMoving) {
            if (Input.GetButtonDown("Moveup")) {
                player.velocity = new Vector2(0, moveSpeed);
            }
            if (Input.GetButtonDown("Movedown")) {
                player.velocity = new Vector2(0, -moveSpeed);
            }
            if (Input.GetButtonDown("Moveright")) {
                player.velocity = new Vector2(moveSpeed, 0);
            }
            if (Input.GetButtonDown("Moveleft")) {
                player.velocity = new Vector2(-moveSpeed, 0);
            }
        }
        if(isMoving && player.velocity.magnitude <= 0.1f)
            GameManager.GetInstance().CameraShake(0.03f);
        isMoving = player.velocity.magnitude > 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
