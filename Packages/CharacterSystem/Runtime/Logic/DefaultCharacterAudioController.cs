using CHARK.ScriptableEvents.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class DefaultCharacterAudioController : CharacterAudioControllerBase
    {
        [SerializeField]
        private StringScriptableEvent OnAudioRequested;

        private CharacterEventHandler characterEventHandler;
        private CharacterEventHandler CharacterEventHandler 
        { get { return characterEventHandler == null ? characterEventHandler 
                    = transform.root.GetComponentInChildren<CharacterEventHandler>() 
                    : characterEventHandler; } }


        private string takeDamageID = "Take Damage";

        private void OnEnable()
        {
            CharacterEventHandler.OnCharacterJumped.AddListener(PlayJumpClip);
            CharacterEventHandler.OnCharacterTakeDamage.AddListener(PlayTakeDamageClip);
            CharacterEventHandler.OnCharacterRecieveHeal.AddListener(PlayRecieveHealClip);
        }

        private void OnDisable()
        {
            CharacterEventHandler.OnCharacterJumped.RemoveListener(PlayJumpClip);
            CharacterEventHandler.OnCharacterTakeDamage.RemoveListener(PlayTakeDamageClip);
            CharacterEventHandler.OnCharacterRecieveHeal.RemoveListener(PlayRecieveHealClip);
        }

        public override void PlayAudioOneShot(string audioId)
        {
            Debug.Log($"Audio Quee Played {audioId}");

            OnAudioRequested.Raise(audioId);

            //Example Implementation
            //AudioSource.PlayOneShot(AudioData.CharacterAudioCollection[audioId]);
        }

        private void PlayTakeDamageClip()
        {
            PlayAudioOneShot(takeDamageID);
        }

        private void PlayJumpClip()
        {
            PlayAudioOneShot("Jump");
        }

        private void PlayRecieveHealClip()
        {
            PlayAudioOneShot("RecieveHeal");
        }
    }
}
