using System.Collections;
using System.Collections.Generic;
using csv_file_namespace;
using utility_namespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class edit_panel : MonoBehaviour {
	public InputField input_task_name;
	public InputField input_task_detail;

	private string m_file_name;

	void Start () {
		utility my_util = new utility ();
		my_util.set_file_name (Application.persistentDataPath);
		m_file_name = my_util.get_file_name ();

		//ファイルを覗いて、更新ならテキストに記入
		csv_file file = new csv_file ();
		file.init (m_file_name);

		int number = file.get_task_number ();

		for (int i = 0; i < number; i++) {
			string data = file.get_data (i, 0);

			if (data.IndexOf ("*") == -1) {
				//何もしない
			} else {

				input_task_name.text = file.get_data (i, 1);
				input_task_detail.text = file.get_data (i, 2);
			}
		}
		file.save_to_file (m_file_name);
	}

	public string get_task_name () {
		return input_task_name.text;
	}

	public string get_task_detail () {
		return input_task_detail.text;
	}

	public void move_to_main_scene () {
		SceneManager.LoadScene ("task_list_model");
	}

	public void delete_task () {
		//*がついたタスクを削除

		csv_file file = new csv_file ();

		file.init (m_file_name);

		int number = file.get_task_number ();

		for (int i = 0; i < number; i++) {
			string data = file.get_data (i, 0);

			if (data.IndexOf ("*") == -1) {

			} else {
				file.delete_task (data);
				break;
			}
		}
		file.save_to_file (m_file_name);
	}

	public void add_task (string name, string detail) {
		//ファイルに追記
		csv_file file = new csv_file ();

		file.init (m_file_name);
		file.add_new_task (name, detail, "new_status");
		file.save_to_file (m_file_name);
	}

	public void delete_star () {
		csv_file file = new csv_file ();

		file.init (m_file_name);

		int number = file.get_task_number ();
		for (int i = 0; i < number; i++) {
			string data = file.get_data (i, 0);

			if (data.IndexOf ("*") == -1) {

			} else {
				data = data.Replace ("*", "");
				file.set_data (i, 0, data);
				break;
			}
		}
		file.save_to_file (m_file_name);
	}
}