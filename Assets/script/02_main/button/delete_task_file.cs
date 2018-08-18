using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_task_file : MonoBehaviour {

	public void OnClick () {
		Debug.Log ("click delete_task_file");
		GameObject.Find ("Content").GetComponent<Scroll_view_content> ().delete_task_file ();
	}
}