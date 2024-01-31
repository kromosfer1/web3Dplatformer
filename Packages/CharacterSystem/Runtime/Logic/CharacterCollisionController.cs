using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class CharacterCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            CollectableBase collectable = other.GetComponent<CollectableBase>();

            if (collectable != null)
            {
                collectable.Collect();
            }
        }
    }
}
