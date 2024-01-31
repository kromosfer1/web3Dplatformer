using CHARK.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RobotDreams.CharacterSystem
{
    public class CharacterEventHandler : MonoBehaviour
    {        
        public UnityEvent OnCharacterJumped;
        public UnityEvent OnCharacterCrouched;
        public UnityEvent OnCharacterTakeDamage;
        public UnityEvent OnCharacterRecieveHeal;
        public UnityEvent OnCharacterDeath;
        public UnityEvent OnCharacterRevive;
        public UnityEvent OnReviveRequested;
    }
}
