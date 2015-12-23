using UnityEngine;
using System.Collections;

public class CardboardSwitch : MonoBehaviour {
	
	private CardboardHead head;
	private Vector3 startingPosition;
	private float delay;

	// Use this for initialization
	void Start () {
		delay = 0.0f;
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) {
			delay = Time.time + 2.0f;
		}
		if ((Cardboard.SDK.CardboardTriggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			delay = Time.time + 2.0f;
			Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
		}
	}

}
