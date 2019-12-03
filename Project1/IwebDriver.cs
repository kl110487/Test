using System;
using OpenQA.Selenium.Chrome;

namespace Project1
{
    internal class IwebDriver
    {
        public static implicit operator IwebDriver(ChromeDriver v)
        {
            throw new NotImplementedException();
        }

        internal void Quit()
        {
            throw new NotImplementedException();
        }
    }
}