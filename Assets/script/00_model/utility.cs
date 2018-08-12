using System;
using System.Collections.Generic;

namespace utility_namespace {

	public class utility {

		private string m_file_name;

		public void set_file_name (string input_data) {
			m_file_name = input_data + "/input_text.txt";
		}

		public string get_file_name () {
			return m_file_name;
		}
	}
}