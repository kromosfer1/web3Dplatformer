using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    [CreateAssetMenu(menuName = "RobotDreams/CharacterSystem/CharacterMovementData")]
    public class CharacterMovementData : ScriptableObject
    {
        [Range(0, 100)] public float MaxSpeed;
        [Range(0,100)] public float JumpForce;
        public float CrouchingSpeed;
        public float NormalHeight;
        public float CrouchHeight;
        public Vector3 CharacterOffset;        
    }
}
