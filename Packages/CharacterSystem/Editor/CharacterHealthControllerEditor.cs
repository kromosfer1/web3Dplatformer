using RobotDreams.CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RobotDreamsCharacterSystem.Editor
{
    [CustomEditor(typeof(CharacterHealthControllerBase), true)]
    public class CharacterHealthControllerEditor : UnityEditor.Editor
    {
        CharacterHealthControllerBase characterHealthController;

        private void OnEnable()
        {
            characterHealthController = (CharacterHealthControllerBase)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Take Damage"))
            {
                characterHealthController.TakeDamage(1);
            }

            if (GUILayout.Button("Heal"))
            {
                characterHealthController.Heal(1);
            }

            if (GUILayout.Button("Revive"))
            {
                characterHealthController.ReviveCharacter();
            }
        }
    }
}
