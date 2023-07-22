using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        public float rotationSpeed = 720f;

        void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Transform cam = Camera.main.transform;

            Vector3 forward = cam.forward;
            forward.y = 0f;
            Vector3 right = cam.right;
            right.y = 0f;

            Vector3 direction = forward * vertical + right * horizontal;
            Vector3 moveVec = direction * speed * Time.deltaTime;

            if (moveVec != Vector3.zero)
            {
                transform.Translate(moveVec, Space.World);
                // https://www.ketra-games.com/2020/12/rotating-a-character-in-the-direction-of-movement-unity-game-tutorial.html
                Quaternion toRotation = Quaternion.LookRotation(moveVec, Vector3.up);

                float y = Mathf.Abs(toRotation.eulerAngles.y);

                if (y >= 250 && y == 270)
                {
                    toRotation.y += 0.45f;
                }
                else if (y >= 60 && y <= 90)
                {
                    toRotation.y -= 0.45f;
                }

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}