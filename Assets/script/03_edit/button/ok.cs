using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ok : MonoBehaviour {

	private edit_panel my_panel;

	public void OnClick () {
		//Debug.Log ("ok");

		my_panel = GameObject.Find ("Edit Panel").GetComponent<edit_panel> ();

		//入力値を取得
		string task_name = my_panel.get_task_name ();
		string task_detail = my_panel.get_task_detail ();

		//タスクを追加
		my_panel.add_task (task_name, task_detail);

		//修正前のデータを削除
		my_panel.delete_task ();

		//mainに戻る
		my_panel.move_to_main_scene ();
	}
}