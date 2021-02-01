using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementForce;
    public float jumpForce;
    public Rigidbody rigidBody;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //Debug.Log("Move Right");
                //rigidBody.AddForce(new Vector3(1.0f, 0.0f, 0.0f)*movementForce);
                rigidBody.AddForce(Vector3.right * movementForce);
            }
            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                // Debug.Log("Move Left");
                //rigidBody.AddForce(new Vector3(-1.0f, 0.0f, 0.0f) * movementForce);
                rigidBody.AddForce(Vector3.left * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                //Debug.Log("Move Right");
                //rigidBody.AddForce(new Vector3(1.0f, 0.0f, 0.0f)*movementForce);
                rigidBody.AddForce(Vector3.forward * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                // Debug.Log("Move Left");
                rigidBody.AddForce(Vector3.back * movementForce);
            }
            if (Input.GetAxisRaw("Jump") > 0)
                rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
