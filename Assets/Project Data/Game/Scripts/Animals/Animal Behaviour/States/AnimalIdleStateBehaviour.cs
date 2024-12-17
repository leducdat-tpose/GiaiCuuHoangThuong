using UnityEngine;
using UnityEngine.AI;

namespace Watermelon
{
    public class AnimalIdleStateBehaviour : AnimalStateBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Transform transform;
        public AnimalIdleStateBehaviour(AnimalStateMachineController stateMachineController) : base(stateMachineController)
        {

        }

        public override void OnStateRegistered()
        {
            navMeshAgent = stateMachineController.ParentBehaviour.NavMeshAgent;
            transform = stateMachineController.ParentBehaviour.transform;
        }

        public override void OnStateActivated()
        {
        }

        public override void OnStateDisabled()
        {

        }

        public override void Update()
        {
            
        }

        public override void OnTriggerEnter(Collider other)
        {
        }

        public override void OnTriggerExit(Collider other)
        {
        }
    }
}