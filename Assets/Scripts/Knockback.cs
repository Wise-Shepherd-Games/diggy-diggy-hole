using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public int knockbackForce;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player")
        {
            var pRb = obj.gameObject.GetComponent<Rigidbody>();

            pRb.AddForce(Vector3.up * knockbackForce, ForceMode.Impulse);
            pRb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * knockbackForce);
        }
    }
}
