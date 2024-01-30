using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    [Serializable]
    public class AudioData
    {
        public string ID;
        public AudioClip AudioClip;
    }
    
    [CreateAssetMenu(menuName = "RobotDreams/CharacterSystem/CharacterAudioData")]
    public class CharacterAudioData : ScriptableObject
    {
        public List<AudioData> Data = new List<AudioData>();


        public Dictionary<string, AudioClip> CharacterAudioCollection = new Dictionary<string, AudioClip>();

        private void Awake()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                CharacterAudioCollection[Data[i].ID] = Data[i].AudioClip;
            }
        }
    }
}
