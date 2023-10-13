using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;

    public float moveSpeed;

    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void HitWall() {
        GameManager.GetInstance().CameraShake(0.04f);
        HitEffectHandlerController.GetInstance().CreateEffect1();
    }

    void Move() {
        if (isMoving && player.velocity.magnitude <= 0.5f) {
            HitWall();
        }
        isMoving = player.velocity.magnitude > 0.5f;
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
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
