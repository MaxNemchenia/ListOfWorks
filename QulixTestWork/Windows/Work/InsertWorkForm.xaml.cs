using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace QulixTestWork
{
    public partial class InsertWorkForm : Window
    {
        bool IsModelValid;
        int? status;
        int? implementerId;
        IService<Implementer> implementerService;
        IService<Work> workService;



        public InsertWorkForm(IService<Implementer> implementerService, IService<Work> workService)
        {
            IsModelValid = true;
            this.implementerService = implementerService;
            this.workService = workService;
            InitializeComponent();
            List<Implementer> implementers = implementerService.getAll();
            ImplementerComboBox.ItemsSource = implementers;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkNameTextBox.Text == "" || status == null || implementerId == null)
            {
                IsModelValid = false;
            }
            if (IsModelValid)
            {
                Work work = new Work();
                work.WorkName = WorkNameTextBox.Text;
                work.StartDate = StartDatePicker.DisplayDate;
                work.EndDate = EndDatePicker.DisplayDate;
                work.Status = (Status)status;
                work.ImplementerId = (int)implementerId;
                workService.Add(work);
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


        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            status = (int)StatusComboBox.SelectedItem;
        }


        private void ImplementerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            implementerId = ((Implementer)ImplementerComboBox.SelectedItem).Id;
        }
    }
}
