using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private float sphereSpeed;
    private Vector3 targetPos;

    void Start()
    {
        sphereSpeed = 2.5f;
        targetPos = transform.position + (6.5f * Vector3.up);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, sphereSpeed * Time.deltaTime);
    }
}
