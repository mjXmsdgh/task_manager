using System;
using System.Collections.Generic;

namespace utility_namespace {

	public class utility {

		private string m_file_name; //!< ファイル名

		private string m_folder_name; //!< フォルダ名

		/** 
		@brief フォルダ名をもとにファイル名を作成
		@param folder_name フォルダ名
		@return void
		@details 特になし
		 */
		public void set_file_name (string folder_name) {
			m_folder_name = folder_name;
			m_file_name = m_folder_name + "/input_text.txt";
		}

		/** 
		@brief フォルダ名を取得
		@return string フォルダ名
		@details 特になし
		 */
		public string get_folder_name () {
			return m_folder_name;
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