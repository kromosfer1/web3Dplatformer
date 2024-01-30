using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotDreams.CharacterSystem
{
    public class PatrolAI : CharacterBrainBase
    {
        public List<Transform> wayPoints;
        private int currentWaypointIndex;

        private void Update()
        {
            Execute();
        }

        public override void Execute()
        {

            if(CheckDistance(wayPoints[currentWaypointIndex], transform) <0.2f)
            {
                currentWaypointIndex++;

                if(currentWaypointIndex > wayPoints.Count - 1) 
                {
                    currentWaypointIndex = 0;
                }
            }

            CharacterController.Move(wayPoints[currentWaypointIndex].position - transform.position);
        }

        private float CheckDistance(Transform targetPoint, Transform currentPoint)
        {
            return Vector3.Distance(targetPoint.position, currentPoint.position);
        }
    }
}
