using System;
using System.Collections;
using System.IO;
using NUnit.Framework;
using task_data_namespace;
using task_list_namespace;
using utility_namespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class test_task_list {
    private utility get_util () {
        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        return my_util;
    }

    /** 
    @brief テスト用のファイル名を取得
    @return string ファイル名
    @details 特になし
    */
    private string get_test_file_name (bool isDisplayFileName = false) {
        utility my_util = get_util ();

        if (isDisplayFileName) {
            Debug.Log ("テスト用ファイル");
            Debug.Log (Application.persistentDataPath);
        }
        return my_util.get_file_name ();
    }

    private void delete_test_folder () {
        utility my_util = get_util ();

        //ファイルを削除
        FileInfo file = new FileInfo (my_util.get_file_name ());
        file.Delete ();

        //フォルダを削除
    }

    [Test]
    public void test_init () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();

        //処理
        test_obj.init (get_test_file_name (), true);

        //テスト
        Assert.AreEqual ("1", test_obj.my_task_list[0].ID);
        Assert.AreEqual ("test_name1", test_obj.my_task_list[0].name);
        Assert.AreEqual ("test_detail1", test_obj.my_task_list[0].detail);
        Assert.AreEqual ("test_status1", test_obj.my_task_list[0].status);

        Assert.AreEqual ("2", test_obj.my_task_list[1].ID);
        Assert.AreEqual ("test_name2", test_obj.my_task_list[1].name);
        Assert.AreEqual ("test_detail2", test_obj.my_task_list[1].detail);
        Assert.AreEqual ("test_status2", test_obj.my_task_list[1].status);

        Assert.AreEqual ("3", test_obj.my_task_list[2].ID);
        Assert.AreEqual ("test_name3", test_obj.my_task_list[2].name);
        Assert.AreEqual ("test_detail3", test_obj.my_task_list[2].detail);
        Assert.AreEqual ("test_status3", test_obj.my_task_list[2].status);

        Assert.AreEqual ("4", test_obj.my_task_list[3].ID);
        Assert.AreEqual ("test_name4", test_obj.my_task_list[3].name);
        Assert.AreEqual ("test_detail4", test_obj.my_task_list[3].detail);
        Assert.AreEqual ("test_status4", test_obj.my_task_list[3].status);

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_get_item_count () {
        //初期化
        task_list test_obj;
        test_obj = new task_list ();
        test_obj.init (get_test_file_name (), true);

        //処理
        int num = test_obj.get_item_count ();

        //テスト
        Assert.AreEqual (4, num);

        //ファイルを削除
        delete_test_folder ();
    }

}