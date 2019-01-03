using System.Windows;

namespace QulixTestWork
{
    public partial class MainWindow : Window
    {
        WorkForm workForm;
        ImplementerForm implementerForm;
        public MainWindow()
        {
            InitializeComponent();
            workForm = new WorkForm();
            implementerForm = new ImplementerForm();
        }



        private void Works_Click(object sender, RoutedEventArgs e)
        {
            if (!workForm.IsLoaded)
            {
                workForm = new WorkForm();
                workForm.Show();
            }
        }


        private void Implementers_Click(object sender, RoutedEventArgs e)
        {
            if (!implementerForm.IsLoaded)
            {
                implementerForm = new ImplementerForm();
                implementerForm.Show();
            }
        }
    }
}
