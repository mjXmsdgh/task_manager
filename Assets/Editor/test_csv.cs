using System;
using System.Collections;
using System.IO;
using csv_file_namespace;
using NUnit.Framework;
using utility_namespace;
using UnityEngine;
using UnityEngine.TestTools;

public class csv_test {

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
        csv_file test_obj = new csv_file ();

        //処理
        test_obj.init (get_test_file_name (), true);

        //テスト
        Assert.AreEqual (4, test_obj.get_task_number ());
        Assert.AreEqual ("1", test_obj.get_data (0, 0));
        Assert.AreEqual ("test_name1", test_obj.get_data (0, 1));
        Assert.AreEqual ("test_detail1", test_obj.get_data (0, 2));
        Assert.AreEqual ("test_status1", test_obj.get_data (0, 3));

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_save_to_file () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //テスト
        Assert.AreEqual (true, System.IO.File.Exists (get_test_file_name ()));

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_get_data () {
        test_init ();
    }

    [Test]
    public void test_set_data () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //処理前テスト
        Assert.AreEqual ("1", test_obj.get_data (0, 0));
        Assert.AreEqual ("test_name1", test_obj.get_data (0, 1));
        Assert.AreEqual ("test_detail1", test_obj.get_data (0, 2));
        Assert.AreEqual ("test_status1", test_obj.get_data (0, 3));

        //処理
        test_obj.set_data (0, 0, "test_string");

        //処理後テスト
        Assert.AreEqual ("test_string", test_obj.get_data (0, 0));

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_get_task_number () {
        test_init ();
    }

    [Test]
    public void test_add_new_task () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //処理
        test_obj.add_new_task ("new_task_name", "new_task_detail", "new_status");

        //テスト
        Assert.AreEqual (5, test_obj.get_task_number ());
        Assert.AreEqual ("5", test_obj.get_data (4, 0));
        Assert.AreEqual ("new_task_name", test_obj.get_data (4, 1));
        Assert.AreEqual ("new_task_detail", test_obj.get_data (4, 2));
        Assert.AreEqual ("new_status", test_obj.get_data (4, 3));

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_delete_task () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //処理
        test_obj.delete_task ("1");
        //テスト
        Assert.AreEqual (3, test_obj.get_task_number ());
        Assert.AreEqual ("2", test_obj.get_data (0, 0));
        Assert.AreEqual ("3", test_obj.get_data (1, 0));
        Assert.AreEqual ("4", test_obj.get_data (2, 0));

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_delete_all () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //処理
        test_obj.delete_all ();

        //テスト
        Assert.AreEqual (0, test_obj.get_task_number ());

        //ファイルを削除
        delete_test_folder ();
    }

    [Test]
    public void test_delete_file () {
        //初期化
        csv_file test_obj = new csv_file ();
        test_obj.init (get_test_file_name (), true);

        //処理
        test_obj.delete_file ();

        //確認
        Assert.AreEqual (false, System.IO.File.Exists (get_test_file_name ()));
    }
}