using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public abstract class CharacterBrainBase : MonoBehaviour, ICharacterBrain
    {
        private ICharacterController characterController;
        protected ICharacterController CharacterController { get { return characterController == null ? characterController = GetComponentInChildren<ICharacterController>() : characterController; } }

        public abstract void Execute();
    }
}
