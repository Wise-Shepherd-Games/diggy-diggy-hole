using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                this.transform.GetComponent<Rigidbody>().isKinematic = true;
                break;

            case "Player":
                if (this.transform.GetComponent<Rigidbody>().isKinematic) return;
                other.gameObject.transform.rotation = Quaternion.Euler(-45, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                break;
        }
    }
}
