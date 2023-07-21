using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        public float rotationSpeed = 720f;

        void Update()
        {
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");
            Vector3 moveVec = new Vector3(right, 0, forward) * speed * Time.deltaTime;

            if (moveVec != Vector3.zero)
            {
                transform.Translate(moveVec, Space.World);
                // https://www.ketra-games.com/2020/12/rotating-a-character-in-the-direction-of-movement-unity-game-tutorial.html
                Quaternion toRotation = Quaternion.LookRotation(moveVec, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}