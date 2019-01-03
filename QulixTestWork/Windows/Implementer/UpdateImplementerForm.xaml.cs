using System.Windows;

namespace QulixTestWork
{
    public partial class UpdateImplementerForm : Window
    {
        IService<Implementer> implementerService;
        Implementer implementer;
        bool IsModelValid;



        public UpdateImplementerForm(int id, IService<Implementer> implementerService)
        {
            IsModelValid = true;
            InitializeComponent();
            this.implementerService = implementerService;
            implementer = implementerService.getById(id);
            IdTextBlock.Text = implementer.Id.ToString();
            FirstNameTextBox.Text = implementer.FirstName;
            LastNameTextBox.Text = implementer.LastName;
            PatronymicTextBox.Text = implementer.Patronymic;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstNameTextBox.Text == "" || LastNameTextBox.Text == "" || PatronymicTextBox.Text == "")
            {
                IsModelValid = false;
            }
            if (IsModelValid)
            {
                implementer.FirstName = FirstNameTextBox.Text;
                implementer.LastName = LastNameTextBox.Text;
                implementer.Patronymic = PatronymicTextBox.Text;
                implementerService.Edit(implementer);
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

