using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RobotDreams.CharacterSystem
{
    public interface ICharacterController 
    {
        float CurrentSpeed { get; }
        bool IsGrounded { get; }

        void Move(Vector3 direction);
        void Jump();
        void Crouch();
        void ToggleMovement(bool value);
    }
}
