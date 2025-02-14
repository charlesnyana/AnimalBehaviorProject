using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FlowerFoundCT : ConditionTask {

		Blackboard agentBB;
		Transform flowerTarget;
		bool flowerFound;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			agentBB = agent.GetComponent<Blackboard>();
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			flowerTarget = agentBB.GetVariableValue<Transform>("nectaredFlower");
			if (flowerTarget != null)
				flowerFound = true;
			else flowerFound = false;
			return flowerFound;
		}
	}
}