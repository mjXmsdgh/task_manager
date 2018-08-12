using System;

namespace task_data_namespace {

	public class task_data {

		public string ID; //!< タスクID
		public string name; //!< タスク名

		public string detail; //!< タスク詳細

		public string status; //!< タスク状態

		/** 
		@brief タスクを設定
		@param task_ID タスクID
		@param task_name   タスク名
		@param task_detail 詳細
		@param task_status 状態
		@return void
		@details 特になし
		 */
		public void setup (string task_ID, string task_name, string task_detail, string task_status) {
			ID = task_ID;
			name = task_name;
			detail = task_detail;
			status = task_status;
		}
	}
}