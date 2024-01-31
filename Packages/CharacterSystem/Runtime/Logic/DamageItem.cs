using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class DamageItem : CollectableBase, IDamager
    {
        [SerializeField] private float damageValue;
        public float DamageValue => damageValue;

        private DefaultHealthController healthController;
        private DefaultHealthController HealthController => healthController ?? FindAnyObjectByType<DefaultHealthController>();

        public override void Collect()
        {
            base.Collect();
            HealthController.TakeDamage(damageValue);
            Debug.Log(HealthController.CurrentHealth.ToString());

        }
    }
}
