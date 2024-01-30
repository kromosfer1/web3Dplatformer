using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class DefaultHealthController : CharacterHealthControllerBase
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

        private void Start()
        {
            ReviveCharacter();
        }

        public override void Heal(float health)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + health, 0, HealthData.MaxHealth);
            CharacterEventHandler.OnCharacterRecieveHeal.Invoke();
        }

        public override void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            CharacterEventHandler.OnCharacterTakeDamage.Invoke();
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
                KillCharacter();
            }
        }

        public override void ReviveCharacter()
        {
            base.ReviveCharacter();
            CurrentHealth = HealthData.MaxHealth;
        }
    }
}
