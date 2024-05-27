using BussinessLayer.Abstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class LoggerManager : ILoggerService
    {
        string path;
        public LoggerManager(IHostingEnvironment env)
        {
            try
            {
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                path = $"{env.ContentRootPath}\\Logs\\{date}.txt";
                if(!File.Exists(path))
                {
                    using (File.Create(path)) { };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }


        public void Error(string message)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(path, true, Encoding.UTF8))
                {
                    string time = DateTime.Now.ToString("HH:mm");
                    stream.Write($"#Error# && {time} || message: {message}");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Info(string message)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(path, true, Encoding.UTF8))
                {
                    string time = DateTime.Now.ToString("HH:mm");
                    stream.Write($"#Info# && {time} || message: {message}");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Success(string message)
        {
            try
            {
                using(StreamWriter stream = new StreamWriter(path, true, Encoding.UTF8)) {
                    string time = DateTime.Now.ToString("HH:mm");
                    stream.Write($"#Success# && {time} || message: {message}");
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
