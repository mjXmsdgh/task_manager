using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancel : MonoBehaviour {

	private edit_panel my_panel;

	public void OnClick () {
		//Debug.Log ("cancel");

		my_panel = GameObject.Find ("Edit Panel").GetComponent<edit_panel> ();

		my_panel.delete_star ();
		my_panel.move_to_main_scene ();
	}
}