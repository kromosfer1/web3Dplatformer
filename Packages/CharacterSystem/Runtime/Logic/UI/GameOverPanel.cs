using CHARK.ScriptableEvents.Events;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RobotDreams.CharacterSystem
{
    public class GameOverPanel : PanelBase
    {
        protected override string ID => "GameOver";

        private CharacterEventHandler eventHandler;
        private CharacterEventHandler EventHandler => eventHandler ?? FindAnyObjectByType<CharacterEventHandler>();

        public override void HidePanel()
        {
            base.HidePanel();
            EventHandler.OnReviveRequested.Invoke();
        }
    }

}
