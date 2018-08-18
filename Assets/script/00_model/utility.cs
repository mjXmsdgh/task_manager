using System;
using System.Collections.Generic;

namespace utility_namespace {

	public class utility {

		private string m_file_name; //!< ファイル名
		/** 
		@brief フォルダ名をもとにファイル名を作成
		@param folder_name フォルダ名
		@return void
		@details 特になし
		 */
		public void set_file_name (string folder_name) {
			m_file_name = folder_name + "/input_text.txt";
		}

		/** 
		@brief ファイル名を取得
		@return string ファイル名
		@details フルパスを返す
		 */
		public string get_file_name () {
			return m_file_name;
		}
	}
}