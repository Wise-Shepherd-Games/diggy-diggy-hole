using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public void FlyAway(float velocity, float rotateForce)
    {
        var rbFish = this.gameObject.GetComponent<Rigidbody>();
        rbFish.constraints = RigidbodyConstraints.None;
        rbFish.AddForce(this.transform.forward * velocity, ForceMode.Impulse);
        rbFish.AddTorque(new Vector3(0, 1, 0) * rotateForce, ForceMode.Impulse);
    }
}
