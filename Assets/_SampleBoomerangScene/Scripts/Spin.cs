using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    float m_speedSpeed = 20;
    void FixedUpdate()
    {
        transform.localRotation *= Quaternion.Euler(Vector3.up * m_speedSpeed);
    }
}
