using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_all : MonoBehaviour {
	public void OnClick () {
		GameObject.Find ("Content").GetComponent<Scroll_view_content> ().Delete_display ();
	}
}