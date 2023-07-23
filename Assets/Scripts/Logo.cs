using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class Logo : MonoBehaviour
{
    public PlayerMovement.PlayerMovement player;
    public float rating;

    void Awake()
    {
        player.enabled = false;
        Destroy(this.gameObject, 6);
    }

    void Update()
    {
        transform.position += Vector3.up * rating * Time.deltaTime;
    }

    void OnDestroy()
    {
        player.enabled = true;
    }
}
