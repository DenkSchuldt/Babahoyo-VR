using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	private GameObject fade;
	private GameObject main;
	private GameObject start;
	private GameObject instructions;
	private GameObject footer;


	/**
	 * 
	 */
	void Start () {
		fade = GameObject.Find ("Fade");
		footer = GameObject.Find ("Footer");
		main = GameObject.FindWithTag ("MainContainer");
		start = GameObject.FindWithTag ("StartContainer");
		instructions = GameObject.FindWithTag ("InstructionsContainer");
		MainOption ();
	}

	/**
	 * 
	 */
	public void MainOption() {
		main.SetActive (true);
		start.SetActive (false);
		instructions.SetActive (false);
		footer.SetActive (true);
	}

	/**
	 * 
	 */
	public void StartOption () {
		start.SetActive (true);
		main.SetActive (false);
		instructions.SetActive (false);
	}
	
	/**
	 * 
	 */
	public void InstructionsOption() {
		start.SetActive (false);
		main.SetActive (false);
		instructions.SetActive (true);
		footer.SetActive (false);
	}
	
	/**
	 * 
	 */
	public void RegularMode() {
		Toolbox.Instance.mode = Constants.REGULAR_MODE;
		float fadeTime = fade.GetComponent<Fade>().BeginFade(1);
		Application.LoadLevel (Constants.SOUTH_SCENE);
	}
	
	/**
	 * 
	 */
	public void VRMode() {
		Toolbox.Instance.mode = Constants.VR_MODE;
		float fadeTime = fade.GetComponent<Fade>().BeginFade(1);
		Application.LoadLevel (Constants.SOUTH_SCENE);
	}

}
