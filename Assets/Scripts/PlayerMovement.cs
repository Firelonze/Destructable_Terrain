using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2D;
    private Vector2 moveVelocity;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject bomb;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
    }
}
