using UnityEngine;

public class Logo : MonoBehaviour
{
    public float rating;

    void Awake()
    {
        Destroy(this.gameObject, 4.8f);
    }

    void Update()
    {
        transform.position += Vector3.up * rating * Time.deltaTime;
    }

}
