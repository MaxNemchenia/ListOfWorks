using System;
using System.Windows;
using System.Windows.Input;


namespace QulixTestWork
{
    public partial class ImplementerForm : Window
    {
        IService<Implementer> implementerService;
        int? currentId;



        public ImplementerForm()
        {
            InitializeComponent();
            implementerService = new ImplementerService();
            workDataGrid.ItemsSource = implementerService.getAll();
        }



        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            InsertImplementerForm insertImplementerForm = new InsertImplementerForm(implementerService);
            insertImplementerForm.Closed += new EventHandler(FormClosedEvent);
            insertImplementerForm.ShowDialog();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentId != null)
            {
                implementerService.Delete((int)currentId);
                workDataGrid.ItemsSource = implementerService.getAll();
                currentId = null;
            }
            else
            {
                MessageBox.Show("Choose element");
            }
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentId != null)
            {
                UpdateImplementerForm updateImplementerForm = new UpdateImplementerForm((int)currentId, implementerService);
                updateImplementerForm.Closed += new EventHandler(FormClosedEvent);
                updateImplementerForm.ShowDialog();
                currentId = null;
            }
            else
            {
                MessageBox.Show("Choose element");
            }
        }


        private void workDataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var v = workDataGrid.SelectedItems;
            if (v.Count > 0 && v[0] is Implementer)
            {
                currentId = ((Implementer)v[0]).Id;
            }
            else
            {
                currentId = null;
            }
        }



        void FormClosedEvent(object sender, EventArgs e)
        {
            workDataGrid.ItemsSource = implementerService.getAll();
        }
    }
}
