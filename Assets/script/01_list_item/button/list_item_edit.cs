using System.Collections;
using System.Collections.Generic;
using csv_file_namespace;
using utility_namespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class list_item_edit : MonoBehaviour {

	private string m_file_name;

	public void Start () {
		utility my_util = new utility ();
		my_util.set_file_name (Application.persistentDataPath);
		m_file_name = my_util.get_file_name ();
	}

	public void OnClick () {

		//IDを取得
		string ID = transform.parent.gameObject.GetComponent<task_data_GUI> ().task_ID;

		check_edit (ID);

		SceneManager.LoadScene ("edit");
	}

	private void check_edit (string ID) {

		csv_file file = new csv_file ();
		file.init (m_file_name);

		int number = file.get_task_number ();

		for (int i = 0; i < number; i++) {
			string temp = file.get_data (i, 0);

			if (ID == temp) {
				file.set_data (i, 0, "*" + ID);
			}
		}

		file.save_to_file (m_file_name);
	}
}