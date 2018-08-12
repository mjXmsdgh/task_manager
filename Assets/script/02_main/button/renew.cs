using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renew : MonoBehaviour {
	public void OnClick () {
		GameObject.Find ("Content").GetComponent<Scroll_view_content> ().renew_item ();
	}
}