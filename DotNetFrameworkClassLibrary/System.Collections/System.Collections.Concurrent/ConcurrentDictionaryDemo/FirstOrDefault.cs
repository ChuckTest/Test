using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConcurrentDictionaryDemo
{
    class Student
    {
        internal int ID;
        internal string Name;
        internal int Score;
    }

    class FirstOrDefault
    {
        static ConcurrentDictionary<int, Student> cd = new ConcurrentDictionary<int, Student>();

        internal static void Test()
        {
            try
            {
                Console.WriteLine("FirstOrDefault测试开始");
                Student stu1 = new Student() { ID = 1, Name = "ChuckLu", Score = 99 };
                cd.AddOrUpdate(1, stu1, (key, value) =>
                {
                    value.ID = 2;
                    value.Name = "LuJuntao";
                    value.Score = 100;
                    return value;
                });

                //尝试获取不存在的学生的信息
                Student stu2 = GetStudentByID(2);
                if (stu2 == null)
                {
                    Console.WriteLine(string.Format("学号为2的学生不存在"));
                }
                else
                {
                    Console.WriteLine(string.Format("学号为2的学生的名字是{0},成绩是{1}", stu2.Name, stu2.Score));
                }

                Console.WriteLine("FirstOrDefault测试结束");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取学号为id的学生实例
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns>实例</returns>
        private static Student GetStudentByID(int id)
        {
            try
            {
                //因为cd不存在item的id为2的元素，所以返回的是default(KeyValuePair<int, Student>)
                KeyValuePair<int, Student> item = cd.FirstOrDefault(student => student.Value.ID == id);
                //item的key是0,value是null
                return item.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
