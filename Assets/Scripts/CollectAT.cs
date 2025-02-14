using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CollectAT : ActionTask {
		public BBParameter<float> skinnyBeeSize;
        public BBParameter<float> chunkyBeeSize;
		Vector3 beeSize;
		public BBParameter<float> nectarCarried;
        public BBParameter<float> maxNectar;
        float nectarRatio;
		public BBParameter<float> nectarGainSpeed;

		Animator beeAnimator;


        float sizeFactor;
		Vector3 minSize;
		Vector3 fullSize;

		Blackboard agentBB;
		public BBParameter<Transform> flowerTransform;
		Blackboard flowerBB;
       float flowerNectar;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			beeAnimator = agent.GetComponent<Animator>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			agentBB = agent.GetComponent<Blackboard>();
			flowerBB = flowerTransform.value.GetComponent<Blackboard>();
			flowerNectar = flowerBB.GetVariableValue<float>("nectar");


            beeSize = Vector3.one;
			minSize = beeSize * skinnyBeeSize.value;
			fullSize = beeSize * chunkyBeeSize.value;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			nectarCarried.value += nectarGainSpeed.value * Time.deltaTime;
            flowerNectar -= nectarGainSpeed.value * Time.deltaTime;

            nectarRatio = nectarCarried.value / maxNectar.value;

			sizeFactor = Mathf.Lerp(skinnyBeeSize.value, chunkyBeeSize.value, nectarRatio);

            agent.transform.localScale = beeSize*sizeFactor;

			flowerBB.SetVariableValue("nectar",flowerNectar);
            

			if (nectarCarried.value >= maxNectar.value)
			{
				nectarCarried.value = maxNectar.value;
				EndAction(true);
			}
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			agent.transform.localScale = fullSize;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}