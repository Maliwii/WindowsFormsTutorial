using System;
using System.Windows.Forms;

namespace PatternDoodle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PictureViewer());
            //Application.Run(new MathQuiz());
            //Application.Run(new MatchingGame());
        }
    }
}
