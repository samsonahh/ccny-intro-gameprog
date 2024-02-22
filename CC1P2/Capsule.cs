using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    private float capsuleSpeed;
    private float jumpForce;
    private Rigidbody rb;

    void Start()
    {
        capsuleSpeed = 3f;
        jumpForce = 5f;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);

        transform.Translate(capsuleSpeed * Time.deltaTime * moveDir);

        //jump without grounded check
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
}
