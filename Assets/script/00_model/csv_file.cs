using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_file_namespace {

	public class csv_file {

		private string m_file_name; //!< ファイル名

		private List<List<string>> m_string_data; //!< データ

		/** 
		@brief クラスを初期化する
		@param input_file_name ファイル名
		@param test_mode trueならテストモード
		@return void
		@details 特になし
		 */
		public void init (string input_file_name, bool test_mode = false) {

			//ファイル名
			m_file_name = input_file_name;

			//領域確保
			m_string_data = new List<List<string>> ();

			//ファイルの存在確認
			bool file_exist = target_file_exist ();

			if (file_exist == false) {
				//ファイルが無いので作成
				create_initial_file (test_mode);

				//内部データを削除
				delete_all ();
			}

			//データ読み込み
			load_data ();
		}

		/** 
		@brief ファイルの存在確認
		@return ファイルが存在するならtrue
		@details 特になし
		*/
		private bool target_file_exist () {
			return System.IO.File.Exists (m_file_name);
		}

		/** 
		@brief 初期ファイルの生成
		@param test_mode trueならテスト用のファイルを生成
		@return なし
		@details 特になし
		*/
		private void create_initial_file (bool test_mode) {

			if (test_mode) {
				add_new_task ("test_name1", "test_detail1", "test_status1");
				add_new_task ("test_name2", "test_detail2", "test_status2");
				add_new_task ("test_name3", "test_detail3", "test_status3");
				add_new_task ("test_name4", "test_detail4", "test_status4");

			} else {
				add_new_task ("sample_task", "sample_detail", "sample_state");
			}
			save_to_file (m_file_name);
		}

		/** 
		@brief csvデータを読み出す
		@return void
		@details 特になし
		 */
		private void load_data () {
			//ファイルが存在するので読み込む
			using (var sr = new System.IO.StreamReader (m_file_name)) {
				while (!sr.EndOfStream) {
					var line = sr.ReadLine ();
					string[] values = line.Split (',');

					List<string> test = new List<string> () { values[0], values[1], values[2], values[3] };
					m_string_data.Add (test);
				}
			}
		}

		/** 
		@brief ファイルに保存する
		@param file_name ファイル名
		@return void
		@details 特になし
		 */
		public void save_to_file (string file_name) {
			using (System.IO.StreamWriter sw = new System.IO.StreamWriter (file_name, false)) {
				for (int i = 0; i < get_task_number (); i++) {

					string ID = (i + 1).ToString ();

					if (m_string_data[i][0].IndexOf ("*") != -1) {

						ID = "*" + ID;
					}

					sw.Write (ID);
					sw.Write (",");
					sw.Write (m_string_data[i][1]);
					sw.Write (",");
					sw.Write (m_string_data[i][2]);
					sw.Write (",");
					sw.Write (m_string_data[i][3]);
					if (i < get_task_number () - 1) {
						sw.WriteLine ("");
					}
				}
			}
		}

		/** 
		@brief データを取得
		@param row 行
		@param column 列
		@return データ
		@details 特になし
		 */
		public string get_data (int row, int column) {
			return m_string_data[row][column];
		}

		/** 
		@brief データを設定
		@param row 行
		@param column 列
		@param data データ
		@return void
		@details 特になし
		 */
		public void set_data (int row, int column, string data) {
			m_string_data[row][column] = data;
		}

		/** 
		@brief タスク数を取得
		@return int タスク数
		@details 特になし
		 */
		public int get_task_number () {
			return m_string_data.Count;
		}

		/** 
		@brief 新しいタスクを設定
		@param name   タスク名
		@param detail 詳細
		@param status 状態
		@return void
		@details 特になし
		 */
		public void add_new_task (string name, string detail, string status) {
			List<string> temp = new List<string> ();

			int num = get_task_number () + 1;

			temp.Add (num.ToString ());
			temp.Add (name);
			temp.Add (detail);
			temp.Add (status);

			m_string_data.Add (temp);
		}

		/** 
		@brief 指定されたタスクを削除
		@param ID タスク名
		@return void
		@details 特になし
		 */
		public void delete_task (string ID) {
			for (int i = 0; i < get_task_number (); i++) {
				if (m_string_data[i][0] == ID) {
					m_string_data.RemoveAt (i);
					break;
				}
			}
		}

		/** 
		@brief すべてのタスクを削除
		@return void
		@details 特になし
		*/
		public void delete_all () {
			m_string_data.RemoveRange (0, get_task_number ());
		}
	}
}