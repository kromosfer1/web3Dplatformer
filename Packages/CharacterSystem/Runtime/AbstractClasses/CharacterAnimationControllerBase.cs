using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public abstract class CharacterAnimationControllerBase : MonoBehaviour, ICharacterAnimationController
    {
        private Animator animator;
        protected Animator Animator { get { return animator == null ? animator = GetComponentInChildren<Animator>() : animator; } }

        private ICharacterController characterController;

        protected ICharacterController CharacterController { get { return characterController == null ? 
                    characterController = GetComponentInChildren<ICharacterController>() :
                    characterController; } }  

        public abstract void ApplyAnimations();
    }
}
