using UnityEngine;
using System.Collections;
namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        [Range(0, 45)] public float turnAngle = 15f;
        [Range(0, 1f)] public float dashForce = 0.1f;
        public float rotationSpeed = 720f;
        private Rigidbody rb;
        private bool dashing = false;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            Vector3 move = MoveVector();
            if (!dashing) MoveAndRotate(move);

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                dashing = true;
                StartCoroutine(Dash(move == Vector3.zero ? transform.forward : move.normalized));
            }

        }

        Vector3 MoveVector()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Transform cam = Camera.main.transform;

            Vector3 direction = cam.forward * vertical + cam.right * horizontal;
            return direction * speed * Time.deltaTime;
        }

        void MoveAndRotate(Vector3 move)
        {
            if (move != Vector3.zero)
                transform.Translate(move, Space.World);

            Transform cam = Camera.main.transform;
            float horizontal = Input.GetAxis("Horizontal");
            transform.rotation = Quaternion.Euler(0f, cam.rotation.eulerAngles.y + turnAngle * horizontal, 0f);
        }

        IEnumerator Dash(Vector3 direction)
        {
            rb.AddForce(direction * dashForce, ForceMode.Impulse);

            yield return new WaitForSeconds(1f);
            dashing = false;
        }
    }
}