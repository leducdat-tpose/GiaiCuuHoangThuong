using UnityEngine;
using UnityEngine.AI;

namespace Watermelon
{
    public class AnimalFollowPlayerStateBehaviour : AnimalStateBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public AnimalFollowPlayerStateBehaviour(AnimalStateMachineController stateMachineController) : base(stateMachineController)
        {

        }

        public override void OnStateRegistered()
        {
            navMeshAgent = stateMachineController.ParentBehaviour.NavMeshAgent;
        }

        public override void OnStateActivated()
        {
            stateMachineController.ParentBehaviour.StartMovement();
            stateMachineController.ParentBehaviour.SetMovementSpeed(stateMachineController.ParentBehaviour.GetMoveSpeedFollowPlayer());

            if (stateMachineController.ParentBehaviour.IsMovementAllowed)
            {
                navMeshAgent.SetDestination(stateMachineController.ParentBehaviour.Player.transform.position);
            }
        }

        public override void OnStateDisabled()
        {

        }

        public override void Update()
        {
            if (navMeshAgent.isActiveAndEnabled)
            {
                navMeshAgent.SetDestination(stateMachineController.ParentBehaviour.Player.transform.position);
            }
        }

        public override void OnTriggerEnter(Collider other)
        {

        }

        public override void OnTriggerExit(Collider other)
        {

        }
    }
}
