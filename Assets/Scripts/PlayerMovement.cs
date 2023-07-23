using UnityEngine;
using System.Collections;
using System;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 10f;
        [Range(0, 45)] public float turnAngle = 15f;
        public float dashForce = 0.1f;
        public float rotationSpeed = 720f;
        private Rigidbody rb;
        private bool dashing = false;
        private Tuple<float, float> dashDir;

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
                dashDir = new(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                StartCoroutine(Dash());
            }

            if (dashing)
            {
                Vector3 movement = new Vector3(dashDir.Item1, 0, dashDir.Item2);

                transform.Translate(movement * dashForce * Time.deltaTime);
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

        IEnumerator Dash()
        {
            yield return new WaitForSeconds(0.5f);
            dashing = false;
        }
    }
}