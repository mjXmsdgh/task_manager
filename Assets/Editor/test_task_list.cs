using System.Collections;
using NUnit.Framework;
using task_data_namespace;
using task_list_namespace;
using utility_namespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class test_task_list {

    /** 
    @brief テスト用のファイル名を取得
    @return string ファイル名
    @details 特になし
    */
    private string get_test_file_name (bool isDisplayFileName = false) {
        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        if (isDisplayFileName) {
            Debug.Log ("テスト用ファイル");
            Debug.Log (Application.persistentDataPath);
        }
        return my_util.get_file_name ();
    }

    [Test]
    public void test_init () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();

        //処理
        test_obj.init (get_test_file_name ());

        //テスト
    }

    [Test]
    public void test_init_data_source () {

    }

    [Test]
    public void test_load_task_list () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();

        test_obj.init (get_test_file_name ());

        int num = test_obj.get_item_count ();

        //処理
        test_obj.load_task_list (num);

        //テスト
        Assert.AreEqual ("1", test_obj.my_task_list[0].ID);
        Assert.AreEqual ("task_name1", test_obj.my_task_list[0].name);
        Assert.AreEqual ("my_detail1", test_obj.my_task_list[0].detail);
        Assert.AreEqual ("my_status1", test_obj.my_task_list[0].status);

        Assert.AreEqual ("4", test_obj.my_task_list[3].ID);
        Assert.AreEqual ("task_name4", test_obj.my_task_list[3].name);
        Assert.AreEqual ("my_detail4", test_obj.my_task_list[3].detail);
        Assert.AreEqual ("my_status4", test_obj.my_task_list[3].status);
    }

    [Test]
    public void test_save_task_list () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();
        test_obj.init (get_test_file_name ());

        //処理
        //test_obj.save_task_list ("D:\\Unity\\Android_Sample\\Assets\\resource\\output_text.txt"

        //テスト
    }

    [Test]
    public void test_get_item_count () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();
        test_obj.init (get_test_file_name ());

        //処理
        int num = test_obj.get_item_count ();

        //テスト
        Assert.AreEqual (4, num);
    }

    [Test]
    public void test_delete_item () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();
        test_obj.init (get_test_file_name ());

        //処理
        test_obj.delete_item ("1");
        test_obj.get_item_count ();

        //テスト
        Assert.AreEqual (3, test_obj.get_item_count ());
    }

    [Test]
    public void test_add_item () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();
        test_obj.init (get_test_file_name ());

        //処理
        test_obj.add_item ("5", "new_item", "new_detail", "new_status");

        //テスト
        Assert.AreEqual (5, test_obj.get_item_count ());
    }
}