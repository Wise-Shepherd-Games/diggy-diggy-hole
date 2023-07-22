using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractability : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Entity")
        {
            other.gameObject.tag = "Interactable";
        }
    }
}
