using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        [Range(0, 45)] public float turnAngle = 15f;
        public float rotationSpeed = 720f;

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Transform cam = Camera.main.transform;

            Vector3 direction = cam.forward * vertical + cam.right * horizontal;
            Vector3 moveVec = direction * speed * Time.deltaTime;

            if (moveVec != Vector3.zero)
                transform.Translate(moveVec, Space.World);

            transform.rotation = Quaternion.Euler(0f, cam.rotation.eulerAngles.y + turnAngle * horizontal, 0f);
        }
    }
}