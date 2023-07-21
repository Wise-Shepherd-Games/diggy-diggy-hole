using UnityEngine;

namespace PlayerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [RangeAttribute(0f, 1f)] public float speed = 0.25f;
        private CharacterController ct;

        void Start()
        {
            ct = GetComponent<CharacterController>();
        }

        void Update()
        {
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");
            Vector3 directon = new(right, 0, forward);
            ct.Move(directon * speed);
        }
    }
}