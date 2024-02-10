using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class CheckpointCharacter : MonoBehaviour
    {
        public Vector3 SpawnPoint;

        private void Start()
        {
            SpawnPoint = gameObject.transform.position;
        }
    }
}
