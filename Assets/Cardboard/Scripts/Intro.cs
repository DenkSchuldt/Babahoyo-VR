using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	
	private CardboardHead head;
	private GameObject fade;
	private Vector3 startingPosition;
	private float delay;

	// Use this for initialization
	void Start () {
		delay = 0.0f;
		fade = GameObject.Find ("Fade");
		head = Camera.main.GetComponent<StereoController>().Head;
		startingPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		bool isLookedAt = GetComponent<Collider>().Raycast(head.Gaze, out hit, Mathf.Infinity);
		if (!isLookedAt) {
			delay = Time.time + 2.0f;
		} else {
			transform.Rotate(0,0,4);
		}
		if ((Cardboard.SDK.Triggered && isLookedAt) || (isLookedAt && Time.time>delay)) {
			delay = Time.time + 2.0f;
			onClick();
		}
	}

	public void onClick() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
		float fadeTime = fade.GetComponent<Fade>().BeginFade(1);
		Application.LoadLevel (Constants.INTRO_SCENE);
	}

}
