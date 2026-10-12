
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveForce = 15f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;

    private readonly HashSet<Collider> groundContacts = new HashSet<Collider>();

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            x = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            x = 1f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            z = 1f;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            z = -1f;

        movement = new Vector3(x, 0f, z).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            groundContacts.Clear();
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * moveForce, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts.Add(collision.collider);
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContacts.Remove(collision.collider);
            isGrounded = groundContacts.Count > 0;
        }
    }
}
