using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FlowerUpdateAT : ActionTask {

		Blackboard agentBB;
		public BBParameter<float> nectar;
		public BBParameter<float> nectarReplenishRate;
        public BBParameter<float> nectarMax;
		Transform nectarObject;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			agentBB = agent.GetComponent<Blackboard>();
			nectarObject = agent.transform.GetChild(0);
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (nectar.value < 0) nectar.value = 0;

			if (nectar.value <= nectarMax.value)
			{
				nectar.value += nectarReplenishRate.value * Time.deltaTime;
			} else
			{
				nectar.value = nectarMax.value;
			}

			nectarObject.localScale = (Vector3.one * 0.9f) * (nectar.value / nectarMax.value);
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}