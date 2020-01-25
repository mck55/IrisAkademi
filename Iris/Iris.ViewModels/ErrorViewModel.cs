using System;
using System.Collections.Generic;
using System.Text;

namespace Iris.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {

        }
        public ErrorViewModel(string errorMessage, string path, string qs)
        {
            ErrorMessage = errorMessage;
            Path = path;
            QS = qs;
        }
        public string ErrorMessage { get; set; }
        public string Path { get; set; }
        public string QS { get; set; }

    }
}
