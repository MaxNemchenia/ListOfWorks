using System.Windows;

namespace QulixTestWork
{
    public partial class InsertImplementerForm : Window
    {
        bool IsModelValid;
        IService<Implementer> implementerService;



        public InsertImplementerForm(IService<Implementer> implementerService)
        {
            IsModelValid = true;
            this.implementerService = implementerService;
            InitializeComponent();
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "" || PatronymicTextBox.Text == "")
            {
                IsModelValid = false;
            }
            if (IsModelValid)
            {
                Implementer implementer = new Implementer();
                implementer.FirstName = FirstNameTextBox.Text;
                implementer.LastName = LastNameTextBox.Text;
                implementer.Patronymic = PatronymicTextBox.Text;
                implementerService.Add(implementer);
                Close();
            }
            else
            {
                MessageBox.Show("All fields are required");
                IsModelValid = true;
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
