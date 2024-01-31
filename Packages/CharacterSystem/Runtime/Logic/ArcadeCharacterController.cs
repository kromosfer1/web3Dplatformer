using System;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class ArcadeCharacterController : CharacterControllerBase
    {
        private CharacterController characterController;
        protected CharacterController CharacterController
        {
            get
            {
                return characterController == null ?
                    characterController = GetComponentInParent<CharacterController>()
                    : characterController;
            }
        }

        private CharacterEventHandler characterEventHandler;
        private CharacterEventHandler CharacterEventHandler
        {
            get
            {
                return characterEventHandler == null ? characterEventHandler
                    = transform.root.GetComponentInChildren<CharacterEventHandler>()
                    : characterEventHandler;
            }
        }

        public override float CurrentSpeed
        {
            get
            {
                var currentSpeed = new Vector3(
                    CharacterController.velocity.x,
                    0,
                    CharacterController.velocity.z)
                    .magnitude;

                return CharacterSystemUtilities.CalculatePercentage(0, CharacterMovementData.MaxSpeed, currentSpeed);
            }
        }


        public override bool IsGrounded => CharacterController.isGrounded;

        private bool canMove;
        public override bool CanMove { get => canMove; protected set => canMove = value; }

        private bool crouched;
        public override bool Crouched { get => crouched; protected set => crouched = value; }

        [SerializeField] [Range(0f, -20.0f)]
        private float _gravity = -20.0f;
        [SerializeField]
        private float _fallAcceleration = 10.0f;
        [SerializeField]
        private float _maxFallSpeed = 40.0f;
        [SerializeField]
        private float _jumpEndedEarlyModifier = 3f;
        [SerializeField]
        private float slopeForce = 3.0f;
        [SerializeField]
        private float smoothTurningTime = 0.05f;
        private float _currentVelocity;

        private Vector3 movementDirection = Vector3.zero;
        private float slopeForceRayLength = 1.5f;
        private Vector3 force = Vector3.zero;
        private Rigidbody lastInteractedRigidbody;
        public Transform CharacterTransform;

        private void FixedUpdate()
        {
            ApplyGravity();
            ApplyForceToRigidbodies();
        }

        private void Update()
        {
            if (IsGrounded)
            {
                HandleSlope();
            }

            ApplyMovement();
        }

        public override void Crouch()
        {
            if (!canMove) return;

            CharacterEventHandler.OnCharacterCrouched.Invoke();
        }

        public override void Jump()
        {
            if (!canMove) return;

            CharacterEventHandler.OnCharacterJumped.Invoke();
        }

        public override void Move(Vector3 direction)
        {
            if (!canMove) return;

            movementDirection = new Vector3(direction.x, movementDirection.y, direction.z);
        }

        public void ApplyJump()
        {
            movementDirection.y = CharacterMovementData.JumpForce;
        }

        public void ApplyCrouch()
        {
            crouched = !crouched;

            if (crouched == true)
            {
                characterController.height = characterController.height - CharacterMovementData.CrouchingSpeed * Time.deltaTime;
                if (characterController.height <= CharacterMovementData.CrouchHeight)
                    characterController.height = CharacterMovementData.CrouchHeight;
            }

            if (!crouched == false)
            {
                characterController.height = characterController.height + CharacterMovementData.CrouchingSpeed * Time.deltaTime;

                if (characterController.height < CharacterMovementData.NormalHeight)
                    CharacterTransform.position = CharacterTransform.position + CharacterMovementData.CharacterOffset * Time.deltaTime;

                if (characterController.height >= CharacterMovementData.NormalHeight)
                    characterController.height = CharacterMovementData.NormalHeight;

            }
        }

        private void ApplyMovement()
        {
            var moveDir = IsGrounded ? movementDirection : movementDirection * 0.5f;

            CharacterController.Move(moveDir * CharacterMovementData.MaxSpeed * Time.deltaTime);

            if (CharacterController.velocity.sqrMagnitude == 0) return;

            var targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTurningTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        private void ApplyGravity()
        {
            if (IsGrounded && movementDirection.y <= 0)
            {
                movementDirection.y = _gravity * (Time.deltaTime * 0.5f);
            }
            else
            {
                var inAirGravity = _fallAcceleration * Time.fixedDeltaTime;
                if (movementDirection.y > 0) inAirGravity *= _jumpEndedEarlyModifier;
                movementDirection.y = Mathf.MoveTowards(movementDirection.y, -_maxFallSpeed, inAirGravity * Time.fixedDeltaTime);
            }
        }

        private void HandleSlope()
        {
            if (IsOnSlope())
            {
                movementDirection.y -= slopeForce;
            }
        }

        private bool IsOnSlope()
        {
            if (movementDirection.y <= 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, CharacterController.height / 2 * slopeForceRayLength))
                {
                    if (hit.normal != Vector3.up)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ApplyForceToRigidbodies()
        {
            if (lastInteractedRigidbody == null || force == Vector3.zero)
                return;


            // Apply the force to the Rigidbody
            lastInteractedRigidbody.AddForce(force);

            // Reset the force
            force = Vector3.zero;
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            // Check whether the object has a Rigidbody
            if (rb != null)
            {
                lastInteractedRigidbody = rb;
                // Calculate the force vector: direction of the hit scaled by the speed of the character controller
                force = hit.moveDirection * CharacterController.velocity.magnitude * 50;
            }
        }
    }
}
