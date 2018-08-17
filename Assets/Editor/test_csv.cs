using System.Collections;
using csv_file_namespace;
using NUnit.Framework;
using utility_namespace;
using UnityEngine;
using UnityEngine.TestTools;

public class csv_test {

    private string get_test_file_name () {
        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");
        //Debug.Log (Application.persistentDataPath);

        return my_util.get_file_name ();
    }

    [Test]
    public void test_init () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name ());

        //処理
        Assert.AreEqual (4, test_obj.get_task_number ());

        //テスト
        Assert.AreEqual ("1", test_obj.get_data (0, 0));
        Assert.AreEqual ("task_name1", test_obj.get_data (0, 1));
        Assert.AreEqual ("my_detail1", test_obj.get_data (0, 2));
        Assert.AreEqual ("my_status1", test_obj.get_data (0, 3));
    }

    [Test]
    public void test_save_to_file () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name ());

        //テスト
        //test_obj.save_to_file ("D: \\Unity\\ Android_Sample\\ Assets\\ resource\\ output.txt ");
    }

    [Test]
    public void test_add_new_task () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name ());

        //処理
        test_obj.add_new_task ("new_task_name", "new_task_detail", "new_status");

        //テスト
        Assert.AreEqual (5, test_obj.get_task_number ());
    }

    [Test]
    public void test_delete_task () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name ());

        //処理
        test_obj.delete_task ("1");
        //テスト
        Assert.AreEqual (3, test_obj.get_task_number ());

        //処理
        test_obj.delete_task ("3");
        //テスト
        Assert.AreEqual (2, test_obj.get_task_number ());
    }

    [Test]
    public void test_delete_all () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name ());

        //処理
        test_obj.delete_all ();

        //テスト
        Assert.AreEqual (0, test_obj.get_task_number ());
    }
}