using UnityEngine;

public class Transition : MonoBehaviour
{
    public float rating;

    void Awake()
    {
        Destroy(this.gameObject, 1.5f);
    }

    void Update()
    {
        transform.localScale -= Vector3.one * rating * Time.deltaTime;
    }

    void OnDestroy()
    {
        RunesManager.first = false;
    }
}
