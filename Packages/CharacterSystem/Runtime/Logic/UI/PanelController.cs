using CHARK.ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField]
        private List<string> panelsToShow = new List<string>();
        [SerializeField]
        private List<string> panelsToHide = new List<string>();

        [SerializeField]
        private StringScriptableEvent OnPanelShow;
        [SerializeField]
        private StringScriptableEvent OnPanelHide;


        public void Execute()
        {
            for (int i = 0; i < panelsToShow.Count; i++)
            {
                OnPanelShow.Raise(panelsToShow[i]);
            }

            for (int i = 0; i < panelsToHide.Count; i++)
            {
                OnPanelHide.Raise(panelsToHide[i]);
            }
        }
    }
}