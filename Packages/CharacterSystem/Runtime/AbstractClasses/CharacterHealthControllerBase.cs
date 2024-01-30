using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public abstract class CharacterHealthControllerBase : MonoBehaviour, ICharacterHealthController
    {
        [SerializeField]
        private CharacterHealthData healthData;
        protected CharacterHealthData HealthData => healthData;

        private ICharacterController characterController;
        protected ICharacterController CharacterController { get { return characterController == null ? characterController = GetComponentInChildren<ICharacterController>() : characterController; } }

        private float currentHealth;
        public float CurrentHealth { get { return currentHealth; } protected set { currentHealth = value; }  }

        public abstract void Heal(float health);

        public abstract void TakeDamage(float damage);

        public virtual void KillCharacter()
        {
            CharacterController.ToggleMovement(false);
        }

        public virtual void ReviveCharacter()
        {
            CharacterController.ToggleMovement(true);
        }
    }
}
