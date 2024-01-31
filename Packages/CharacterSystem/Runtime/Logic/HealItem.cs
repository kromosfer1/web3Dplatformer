using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class HealItem : CollectableBase, IHealer
    {
        [SerializeField] private float healValue;

        public float HealValue => healValue;

        private DefaultHealthController healthController;
        private DefaultHealthController HealthController => healthController?? FindAnyObjectByType<DefaultHealthController>();

        public override void Collect()
        {
            base.Collect();
            HealthController.Heal(healValue);
            Debug.Log(HealthController.CurrentHealth.ToString());
        }
    }
}
