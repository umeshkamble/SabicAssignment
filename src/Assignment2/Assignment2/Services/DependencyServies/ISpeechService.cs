    using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Services.DependencyServies
{
    public interface ISpeechService
    {
        Action<string> FinalResults { get; set; }
        void StartListening();
    }
}
        