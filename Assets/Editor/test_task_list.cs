using System.Collections;
using NUnit.Framework;
using task_data_namespace;
using task_list_namespace;
using utility_namespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class test_task_list {

    [Test]
    public void test_init () {
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());
    }

    [Test]
    public void test_init_data_source () {

    }

    [Test]
    public void test_load_task_list () {
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());

        int num = test_obj.get_item_count ();

        test_obj.load_task_list (num);

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
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());

        //test_obj.save_task_list ("D:\\Unity\\Android_Sample\\Assets\\resource\\output_text.txt");
    }

    [Test]
    public void test_get_item_count () {
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());

        int num = test_obj.get_item_count ();

        Assert.AreEqual (4, num);
    }

    [Test]
    public void test_delete_item () {
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());

        test_obj.delete_item ("1");
        test_obj.get_item_count ();
        Assert.AreEqual (3, test_obj.get_item_count ());
    }

    [Test]
    public void test_add_item () {
        task_list test_obj;
        test_obj = new task_list ();

        utility my_util = new utility ();
        my_util.set_file_name (Application.persistentDataPath + "\\test\\");

        test_obj.init (my_util.get_file_name ());

        test_obj.add_item ("5", "new_item", "new_detail", "new_status");
        Assert.AreEqual (5, test_obj.get_item_count ());
    }
}