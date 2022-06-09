
using System.Windows.Forms;

namespace Deeplay.Teplov.TestWork.Presenter
{

    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowExclimition(string exclimition);
        void ShowError(string error);
    }

    public class MessageService : IMessageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExclimition(string exclimition)
        {
            MessageBox.Show(exclimition, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
}
