using UnityEngine;

public class Logo : MonoBehaviour
{
    private PlayerMovement.PlayerMovement player;
    public float rating;

    void Awake()
    {
        player = FindFirstObjectByType<PlayerMovement.PlayerMovement>();
        player.enabled = false;
        Destroy(this.gameObject, 4.8f);
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
