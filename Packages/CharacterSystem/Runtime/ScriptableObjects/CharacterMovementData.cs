using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    [CreateAssetMenu(menuName = "RobotDreams/CharacterSystem/CharacterMovementData")]
    public class CharacterMovementData : ScriptableObject
    {
        public float MaxSpeed;
        public float JumpForce;
    }
}
