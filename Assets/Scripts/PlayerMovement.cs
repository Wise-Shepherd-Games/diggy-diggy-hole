using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        public static UnityAction playerDied;
        public float speed = 10f;
        [Range(0, 45)] public float turnAngle = 15f;
        public float rotationSpeed = 720f;
        private Rigidbody rb;
        private bool isDead = false;
        private Tuple<float, float> dashDir;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (!isDead)
            {
                Vector3 move = MoveVector();
                MoveAndRotate(move);

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

        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Trap")
            {
                isDead = true;
                transform.rotation = Quaternion.Euler(90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                playerDied();
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject?.tag == "Trap")
            {
                isDead = true;
                transform.rotation = Quaternion.Euler(90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                playerDied();
            }
        }
    }
}