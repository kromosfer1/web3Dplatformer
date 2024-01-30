using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RobotDreams.CharacterSystem
{
    public abstract class CharacterControllerBase : MonoBehaviour, ICharacterController
    {
        [SerializeField]
        private CharacterMovementData characterMovementData;
        protected CharacterMovementData CharacterMovementData => characterMovementData;

        public abstract float CurrentSpeed { get; }

        public abstract bool CanMove { get; protected set; }

        public abstract bool IsGrounded { get; }

        public abstract void Crouch();

        public abstract void Jump();
        public abstract void Move(Vector3 direction);

        public void ToggleMovement(bool value)
        {
            CanMove = value;
        }
    }
}
