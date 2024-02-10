using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public interface ICheckpoint 
    {
        Vector3 LastCheckpoint { get; }
    }
}
