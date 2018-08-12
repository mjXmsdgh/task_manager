using System.Collections;
using NUnit.Framework;
using task_data_namespace;
using task_list_namespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class check_list_model {

	[Test]
	public void test_setup () {

		task_data obj = new task_data ();

		string ID = "test_ID";
		string name = "test_name";
		string detail = "test_detail";
		string status = "test_status";

		obj.setup (ID, name, detail, status);

		Assert.AreEqual (ID, obj.ID);
		Assert.AreEqual (name, obj.name);
		Assert.AreEqual (detail, obj.detail);
		Assert.AreEqual (status, obj.status);
	}
}