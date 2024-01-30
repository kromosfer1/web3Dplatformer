using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public interface ICharacterHealthController 
    {
        float CurrentHealth { get; }

        void TakeDamage(float damage);
        void Heal(float health);

        void KillCharacter();
        void ReviveCharacter();
    }
}
