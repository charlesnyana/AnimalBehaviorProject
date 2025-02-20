using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ReturnAT : ActionTask {

		Blackboard agentBB;
        public BBParameter<Transform> targetTransform;
        public BBParameter<Transform> hiveTarget;
        public BBParameter<float> speed;
        public BBParameter<float> arrivalDistance;
        public BBParameter<Vector3> targetPos;
        Vector3 directionToTarget;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			agentBB = agent.GetComponent<Blackboard>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			targetTransform.value = null;

            Vector3 directionToTarget = hiveTarget.value.position;

            targetPos.value = directionToTarget;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            float distanceToTarget = Vector3.Distance(hiveTarget.value.position, agent.transform.position);
            if (distanceToTarget < arrivalDistance.value)
            {
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}