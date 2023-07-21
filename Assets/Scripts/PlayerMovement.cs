using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        public float rotationSpeed = 720f;

        void FixedUpdate()
        {
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");
            Vector3 moveVec = new Vector3(right, 0, forward) * speed * Time.deltaTime;

            if (moveVec != Vector3.zero)
            {
                transform.Translate(moveVec, Space.World);
                // https://www.ketra-games.com/2020/12/rotating-a-character-in-the-direction-of-movement-unity-game-tutorial.html
                Quaternion toRotation = Quaternion.LookRotation(moveVec, Vector3.up);

                var y = Mathf.Abs(toRotation.eulerAngles.y);

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