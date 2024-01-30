using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public abstract class CharacterAudioControllerBase : MonoBehaviour, ICharacterAudioController
    {
        [SerializeField]
        private CharacterAudioData audioData;
        protected CharacterAudioData AudioData => audioData;

        public abstract void PlayAudioOneShot(string audioId);
    }
}
