using System.Collections;
using System.Collections.Generic;
using task_list_namespace;
using utility_namespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scroll_view_content : MonoBehaviour {

	public RectTransform list_item_prefab;

	public RectTransform content;

	private task_list my_task_list;

	private string m_file_name;

	// Use this for initialization
	void Start () {
		utility my_util = new utility ();
		my_util.set_file_name (Application.persistentDataPath);
		m_file_name = my_util.get_file_name ();

		Debug.Log (my_util.get_file_name ());

		content = GetComponent<RectTransform> ();

		my_task_list = new task_list ();
		my_task_list.init (m_file_name);

		renew_item ();
	}

	public void add_new_item () {
		SceneManager.LoadScene ("edit");
	}

	public void renew_item () {
		Delete_display ();

		int number = my_task_list.get_item_count ();

		for (int i = 0; i < number; i++) {

			RectTransform item = GameObject.Instantiate (list_item_prefab) as RectTransform;
			item.name = my_task_list.my_task_list[i].ID;

			//copy
			item.GetComponent<task_data_GUI> ().task_ID = my_task_list.my_task_list[i].ID;
			item.GetComponent<task_data_GUI> ().task_name = my_task_list.my_task_list[i].name;
			item.GetComponent<task_data_GUI> ().task_detail = my_task_list.my_task_list[i].detail;
			item.GetComponent<task_data_GUI> ().task_status = my_task_list.my_task_list[i].status;

			foreach (Transform child in item) {
				if (child.name == "Text") {
					child.GetComponent<Text> ().text = my_task_list.my_task_list[i].name;
				}
			}

			item.SetParent (content, false);
		}
	}

	public void Delete_display () {
		//表示削除
		List<string> delete_target = new List<string> ();

		foreach (Transform child in transform) {
			GameObject child_object = child.gameObject;
			delete_target.Add (child_object.name);
		}

		for (int i = 0; i < delete_target.Count; i++) {
			delete_list_item (delete_target[i]);
		}
	}

	private void delete_list_item (string ID) {

		foreach (Transform child in transform) {
			GameObject child_object = child.gameObject;

			string temp_id = child_object.GetComponent<task_data_GUI> ().task_ID;

			if (temp_id == ID) {
				DestroyImmediate (child_object);
				break;
			}
		}
	}

	public void delete_task_file () {
		my_task_list.delete_task_file ();
	}
}