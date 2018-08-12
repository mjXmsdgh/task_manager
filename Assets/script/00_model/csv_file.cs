using System;
using System.Collections.Generic;
using System.Linq;

namespace csv_file_namespace {

	public class csv_file {

		//! ファイル名
		private string m_file_name;

		//! データ
		private List<List<string>> m_string_data;

		/** 
		@brief クラスを初期化する
		@param input_file_name ファイル名
		@return void
		@details 特になし
		 */
		public void init (string input_file_name) {

			//ファイル名
			m_file_name = input_file_name;

			//領域確保
			m_string_data = new List<List<string>> ();

			//データ読み込み
			load_data ();
		}

		/** 
		@brief csvデータを読み出す
		@return void
		@details 特になし
		 */
		private void load_data () {
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
		@brief データを取得
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