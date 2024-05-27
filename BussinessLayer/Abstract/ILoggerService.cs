﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface ILoggerService
    {
        void Info(string message);
        void Error(string message);
        void Success(string message);
    }
}
