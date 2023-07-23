using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public PlayerMovement.PlayerMovement player;
    public float rating;

    void Awake()
    {
        player.enabled = false;
        Destroy(this.gameObject, 1.5f);
    }

    void Update()
    {
        transform.localScale -= Vector3.one * rating * Time.deltaTime;
    }

    void OnDestroy()
    {
        player.enabled = true;
    }
}
