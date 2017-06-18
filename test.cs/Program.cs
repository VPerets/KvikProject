using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class TimerExample
{
    delegate void deleg();
    static void Main()
    {
        string s = "";
        Task t = Task.Run( ()
            =>
        {
            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
                s += i.ToString();
           
        }
        );
        Console.WriteLine(t.IsCompleted.ToString());
      //  Console.WriteLine(s);
        for (int i = 0; i < 1000000000; i++)
        {
            i++;
        }
      

        Console.WriteLine(t.IsCompleted.ToString());  
        Console.WriteLine(s);
      //  var list = new ConcurrentBag<string>();
      //  String[] dirnames = { ".", ".." };
      //  List<Task> tasks = new List<Task>();
      //  list.Add("sds");
      //  foreach (var item in dirnames)
      //  {
      //      Task t = new Task(
      //          () =>
      //      {
      //          foreach (var path in Directory.GetFiles(item))
      //              list.Add(path);

      //      }    );
      //      tasks.Add(t);
      //      t.Start();
      //  }
      //  //    Task.WaitAll(tasks.ToArray());
      ////  Thread.Sleep(1000);
      //  foreach (var item in list)
      //  {
      //      Console.WriteLine(item);
      //  }

      //  foreach (var t in tasks)
      //  Console.WriteLine("Task {0} status {1}", t.Id, t.Status);
      //  //foreach (var item in list)
      //  //{
      //  //    Console.WriteLine(item);
      //  //}
    }
}