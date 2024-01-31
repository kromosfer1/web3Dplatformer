using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class BurgerCollectable : CollectableBase, IScoreItem
    {
        [SerializeField] private float scoreIncreaseValue;
        public float ScoreIncreaseValue => scoreIncreaseValue;

        public override void Collect()
        {
            base.Collect();
            Debug.Log("BurgerColelcted");
        }
    }
}
