using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    const int MOVE_ANGLE = 90;

    void Start()
    {
        offset = transform.worldToLocalMatrix.MultiplyVector(transform.position - target.position);
    }

    void Update()
    {
        int direction = 0;

        if (Input.GetKeyDown(KeyCode.E))
            direction = 1;
        else if (Input.GetKeyDown(KeyCode.Q))
            direction = -1;

        target.RotateAround(target.transform.position, Vector3.up, direction * MOVE_ANGLE);
        transform.RotateAround(target.transform.position, Vector3.up, direction * MOVE_ANGLE);
        transform.position = target.position + transform.localToWorldMatrix.MultiplyVector(offset);
    }
}
