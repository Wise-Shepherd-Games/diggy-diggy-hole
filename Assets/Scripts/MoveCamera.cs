using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
