using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    [Range(0, 100)]
    public float knockbackForce;
    [Range(0, 100)]
    public float rotateForce;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            var pRb = obj.gameObject.GetComponent<Rigidbody>();

            pRb.AddForce(Vector3.up * knockbackForce, ForceMode.Impulse);
            pRb.AddTorque(new Vector3(Random.value, 1, Random.value) * rotateForce, ForceMode.Impulse);
        }
    }
}
