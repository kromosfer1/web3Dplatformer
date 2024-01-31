using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class PlayerBrain : CharacterBrainBase
    {

        private Vector3 moveDirection = Vector3.zero;

        private void Update()
        {
            Execute();
        }

        public override void Execute()
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            CharacterController.Move(moveDirection);

            if (CharacterController.IsGrounded)
            {
                if (Input.GetButton("Jump"))
                {
                    CharacterController.Jump();
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    CharacterController.Crouch();
                }
            }
        }
    }
}
