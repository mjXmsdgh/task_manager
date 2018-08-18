using System;
using System.Collections.Generic;
using System.Linq;
using csv_file_namespace;
using task_data_namespace;

namespace task_list_namespace {

	public class task_list {

		private csv_file my_file; //!< ファイル名

		public List<task_data> my_task_list; //!< タスクリスト

		/** 
		@brief タスクリストを初期化
		@param file_name ファイル名
		@param test_mode trueならテストモード
		@return void
		@details 特になし
		 */
		public void init (string file_name, bool test_mode = false) {
			init_data_source (file_name, test_mode);

			int number = my_file.get_task_number ();

			load_task_list (number);
		}

		/** 
		@brief タスクファイルを初期化
		@param file_name ファイル名
		@param test_mode trueならテストモード
		@return void
		@details 特になし
		 */
		private void init_data_source (string file_name, bool test_mode) {
			my_file = new csv_file ();
			my_file.init (file_name, test_mode);
		}

		/** 
		@brief タスクファイルを読み出す
		@param[in] number タスク数
		@return void
		@details 特になし
		*/
		private void load_task_list (int number) {
			my_task_list = new List<task_data> ();
			for (int index = 0; index < number; index++) {
				my_task_list.Add (create_item (index));
			}
		}

		/** 
		@brief タスクアイテムを生成
		@param taskID タスクID
		@return タスクデータ
		@details 特になし
		*/
		private task_data create_item (int taskID) {
			task_data my_task = new task_data ();

			my_task.setup (
				my_file.get_data (taskID, 0),
				my_file.get_data (taskID, 1),
				my_file.get_data (taskID, 2),
				my_file.get_data (taskID, 3)
			);
			return my_task;
		}

		/** 
		@brief タスク数を取得
		@return タスク数
		@details 特になし
		*/
		public int get_item_count () {
			return my_task_list.Count;
		}
	}
}