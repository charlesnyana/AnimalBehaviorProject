using NodeCanvas.Framework;
using ParadoxNotion.Design;
using static UnityEngine.GraphicsBuffer;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class BeelineAT : ActionTask {
		Blackboard agentBB;

        public BBParameter<Transform> flowerTarget;
        public BBParameter<float> speed;
        public BBParameter<float> arrivalDistance;
		public BBParameter<Vector3> targetPos;
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

		}

        //Called once per frame while the action is active.
		protected override void OnUpdate() {

            float distanceToTarget = Vector3.Distance(flowerTarget.value.position, agent.transform.position);
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