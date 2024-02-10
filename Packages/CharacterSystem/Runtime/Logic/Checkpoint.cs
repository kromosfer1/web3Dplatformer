using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class Checkpoint : MonoBehaviour, ICheckpoint
    {
        public Vector3 lastCheckpoint;
        public Vector3 LastCheckpoint => lastCheckpoint;

        private void Start()
        {
            lastCheckpoint = gameObject.transform.position;
        }
    }
}
