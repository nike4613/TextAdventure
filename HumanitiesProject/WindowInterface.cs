﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanitiesProject
{
    public class WindowInterface
    {
        private MainWindow window;

        public WindowInterface(MainWindow win)
        {
            window = win;

            Console.WriteLine("WindowInterface has been initialized");
        }



    }
}