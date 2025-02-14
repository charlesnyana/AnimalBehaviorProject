using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class OffloadAT : ActionTask {

        public BBParameter<float> skinnyBeeSize;
        public BBParameter<float> chunkyBeeSize;
        Vector3 beeSize;
        public BBParameter<float> nectarCarried;
        public BBParameter<float> maxNectar;
        float nectarRatio;
        public BBParameter<float> nectarGainSpeed;

        float sizeFactor;
        Vector3 minSize;
        Vector3 fullSize;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            beeSize = Vector3.one;
            minSize = beeSize * skinnyBeeSize.value;
            fullSize = beeSize * chunkyBeeSize.value;
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            nectarCarried.value -= nectarGainSpeed.value * Time.deltaTime;

            nectarRatio = nectarCarried.value / maxNectar.value;

            sizeFactor = Mathf.Lerp(skinnyBeeSize.value, chunkyBeeSize.value, nectarRatio);

            agent.transform.localScale = beeSize * sizeFactor;


            if (nectarCarried.value <= 0f)
            {
                nectarCarried.value = 0f;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
            agent.transform.localScale = minSize;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}