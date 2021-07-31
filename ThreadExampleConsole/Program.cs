using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExampleConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region IO
            // string currentDir = Directory.GetCurrentDirectory();
            // Console.WriteLine(currentDir);
            // string dir = "images";
            // if(!Directory.Exists(dir))
            // {
            //     Directory.CreateDirectory(dir);
            // }
            // string path = Path.Combine(currentDir, dir);
            //// string fileName = "alisa.txt";
            // string fileName = "bob.txt";
            // Console.WriteLine(path);
            // string filePath = Path.Combine(path, fileName);



            //using(FileStream fs = File.Create(filePath))
            //{
            //    string str = "Hello";
            //    var bytes = Encoding.Unicode.GetBytes(str);
            //    fs.Write(bytes);
            //}

            ////Pass the filepath and filename to the StreamWriter Constructor
            //StreamWriter sw = new StreamWriter(filePath, true);
            ////Write a line of text
            //sw.WriteLine("Hello World!!");
            ////Write a second line of text
            //sw.WriteLine("From the StreamWriter class");
            ////Close the file
            //sw.Close();

            //String line;
            //StreamReader sr = new StreamReader(filePath);
            //line = sr.ReadLine();
            //while (line!=null)
            //{
            //    Console.WriteLine(line);
            //    line = sr.ReadLine();
            //}
            //sr.Close();

            #endregion

            #region Thread
            //Thread addUsersThread = new Thread(ThreadWriteFiles); 
            //var threadId = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine("Головний потік "+ threadId);

            //addUsersThread.Start();
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread.Sleep(200);
            //    Console.WriteLine("--------------");
            //}
            //Console.ReadKey();
            //Console.WriteLine("Маin завершив роботу.");
            #endregion

            Console.WriteLine("Головний потік " + Thread.CurrentThread.ManagedThreadId);
            Task<string> task = new Task<string>(ThreadWriteFiles);
            task.Start();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("--------------------");
            }

            var data = await task;// task.Wait();
            Console.WriteLine(data);
            
        }

        static string ThreadWriteFiles()
        {
            Console.WriteLine("Наш новий потік " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.WriteLine("++++++++++++++++");
            }
            return "ok";
        }


    }
}
