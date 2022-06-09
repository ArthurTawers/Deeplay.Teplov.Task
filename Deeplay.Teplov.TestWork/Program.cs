using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deeplay.Teplov.TestWork
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            BL.IDBConnection db = new BL.DataBaseСonnaction();
            BL.Model model = new BL.Model(db);
            View.MainForm form = new View.MainForm();
            Presenter.IMessageService messageService = new Presenter.MessageService();
            Presenter.Presenter presenter = new Presenter.Presenter(form,model,messageService);

            Application.Run(form);

            
        }
    }
}
