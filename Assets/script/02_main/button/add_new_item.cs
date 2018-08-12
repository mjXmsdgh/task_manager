using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_new_item : MonoBehaviour {
	public void OnClick () {
		GameObject.Find ("Content").GetComponent<Scroll_view_content> ().add_new_item ();
	}
}