using System;
using System.Globalization;

namespace BooksShop.Exeprions
{
    public class ApiExeptions : Exception
    {
        public ApiExeptions() { }
        public ApiExeptions(string message) : base(message) { }
        public ApiExeptions(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
