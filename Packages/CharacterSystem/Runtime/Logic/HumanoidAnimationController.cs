using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class HumanoidAnimationController : CharacterAnimationControllerBase
    {
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

        private const string speedId = "Speed";
        private const string jumpId = "Jump";
        private const string groundedId = "IsGrounded";

        private void OnEnable()
        {
            CharacterEventHandler.OnCharacterJumped.AddListener(TriggerJump);
        }

       
        private void OnDisable()
        {
            CharacterEventHandler.OnCharacterJumped.RemoveListener(TriggerJump);
        }


        private void Update()
        {
            ApplyAnimations();
        }

        public override void ApplyAnimations()
        {
            Animator.SetFloat(speedId, CharacterController.CurrentSpeed);
            Animator.SetBool(groundedId, CharacterController.IsGrounded);
        }

        private void TriggerJump()
        {
            Animator.SetTrigger(jumpId);
        }

    }
}
