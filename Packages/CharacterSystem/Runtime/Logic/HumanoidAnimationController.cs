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
        private const string deathId = "Death";
        private const string ReviveId = "Revive";
        private const string groundedId = "IsGrounded";
        private const string crouchId = "Crouch";

        private void OnEnable()
        {
            CharacterEventHandler.OnCharacterJumped.AddListener(TriggerJump);
            CharacterEventHandler.OnCharacterCrouched.AddListener(TriggerCrouch);
            CharacterEventHandler.OnCharacterDeath.AddListener(TriggerDeath);
            CharacterEventHandler.OnCharacterRevive.AddListener(TriggerRevive);
        }

       
        private void OnDisable()
        {
            CharacterEventHandler.OnCharacterJumped.RemoveListener(TriggerJump);
            CharacterEventHandler.OnCharacterCrouched.RemoveListener(TriggerCrouch);
            CharacterEventHandler.OnCharacterDeath.RemoveListener(TriggerDeath);
            CharacterEventHandler.OnCharacterRevive.RemoveListener(TriggerRevive);

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

        private void TriggerCrouch()
        {
            Animator.SetBool(crouchId, CharacterController.Crouched);
        }

        private void TriggerDeath()
        {
            Animator.SetTrigger(deathId);
        }
        private void TriggerRevive()
        {
            Animator.SetTrigger(ReviveId);
        }
    }
}
