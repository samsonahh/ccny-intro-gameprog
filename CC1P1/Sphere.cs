using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    bool bVar = false;

    void Start()
    {
        bVar = true;
    }

    void Update()
    {
        Debug.Log(bVar);
    }
}
