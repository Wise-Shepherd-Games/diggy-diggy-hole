using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                other.gameObject.transform.rotation = Quaternion.Euler(-45, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
                break;
        }
    }
}
