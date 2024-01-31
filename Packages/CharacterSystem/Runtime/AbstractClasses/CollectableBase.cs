using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public abstract class CollectableBase : MonoBehaviour
    {
        public virtual void Collect()
        {
            Destroy(gameObject);
        }
    }
}
