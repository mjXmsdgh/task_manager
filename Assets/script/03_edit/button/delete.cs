using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete : MonoBehaviour {

	private edit_panel my_panel;

	public void OnClick () {
		//Debug.Log ("delete");

		my_panel = GameObject.Find ("Edit Panel").GetComponent<edit_panel> ();

		my_panel.delete_task ();
		my_panel.move_to_main_scene ();
	}
}