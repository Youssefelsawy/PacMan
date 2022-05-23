using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsP : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.forward * 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
