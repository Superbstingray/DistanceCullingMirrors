
using UnityEngine;
using VRC.SDKBase;
using VRC.SDK3.Components;
using UdonSharp;

namespace superbstingray
{
	[UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
	public class SetMirrorCullDistances : UdonSharp.UdonSharpBehaviour 
	{
	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float PlayerCullingDistance = 10F;

	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float PickupCullingDistance = 20F;

	[Tooltip("A Value Of 0 Will Disable Culling Behaviour")]
	public float OtherCullingDistances = 75F;

	[Tooltip("Set Individual Layer Culling Distances")]
	public float[] LayerCullDistances;

	private GameObject MirrorCamObject;
	private Camera MirrorCamera;

		void OnValidate()
		{
			// Force Initialize Float Array in Editor if it is Null
			if  (LayerCullDistances == null) { LayerCullDistances = new float[32]; }
		}
		public void OnEnable()
		{
			// Force Float Array Size
			if  (LayerCullDistances.Length != 32) { LayerCullDistances = new float[32]; }	
			SendCustomEvent("_MirrorUpdate");
		}
		public void _MirrorUpdate()
		{
			// Find the Camera Generated by the Mirror
			if  (MirrorCamObject == null) { MirrorCamObject = GameObject.Find(string.Format("{0}{1}", "MirrorCam", gameObject.name)); }
			if (Utilities.IsValid(MirrorCamObject))
			{
				// Update Specified Layers 
				if ((LayerCullDistances[9] == 0F)) // Player
				{ LayerCullDistances[9] = PlayerCullingDistance;
				}
				if ((LayerCullDistances[10] == 0F)) // PlayerLocal
				{ LayerCullDistances[10] = PlayerCullingDistance;
				}
				if ((LayerCullDistances[18] == 0F)) // MirrorReflection
				{ LayerCullDistances[18] = PlayerCullingDistance;
				}
				if ((LayerCullDistances[8] == 0F)) // Interactive
				{ LayerCullDistances[8] = PickupCullingDistance;
				}
				if ((LayerCullDistances[13] == 0F)) // Pickup
				{ LayerCullDistances[13] = PickupCullingDistance;
				}
				if ((LayerCullDistances[14] == 0F)) // PickupNoEnvironment
				{ LayerCullDistances[14] = PickupCullingDistance;
				}
				// Update Unspecified Layers Distances to OtherCullingDistances
				for(int i=0; i<32; i++)
					if ((LayerCullDistances[i] == 0F)) { LayerCullDistances[i] = OtherCullingDistances; }

				// Update Camera Name & Culling Properties
				MirrorCamObject.name = string.Format("{0}{1}", gameObject.name, "_DCM");
				MirrorCamera = MirrorCamObject.GetComponent<Camera>();
				MirrorCamera.layerCullDistances = LayerCullDistances;
				MirrorCamera.layerCullSpherical = true;

				// Log Mirror Update
				Debug.Log(string.Format("[<color=yellow>DCM</color>] [<color=orange>{0}</color>] {1}", gameObject.name, "Applying Mirror Culling Distances"));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Player Culling Distance", PlayerCullingDistance));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Pickups Culling Distance", PickupCullingDistance));
				Debug.Log(string.Format("[<color=yellow>DCM</color>] {0} <color=lightblue>{1}m</color>", "Other Culling Distances", OtherCullingDistances));

				//Disable this Behaviour Once Completed
				gameObject.GetComponent<SetMirrorCullDistances>().enabled = false;

			} else
			{	// Retry if Mirror Camera Wasn't Initialized f
				SendCustomEventDelayedSeconds("_MirrorUpdate", 1F);
			}
		}
	} 
}
