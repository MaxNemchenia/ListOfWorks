using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace QulixTestWork
{
    public partial class UpdateWorkForm : Window
    {
        IService<Work> workService;
        IService<Implementer> implementerService;
        Work work;
        bool IsModelValid;
        int? status;
        int? implementerId;



        public UpdateWorkForm(int id, IService<Implementer> implementerService, IService<Work> workService)
        {
            IsModelValid = true;
            InitializeComponent();
            this.workService = workService;
            this.implementerService = implementerService;
            List<Implementer> implementers = implementerService.getAll();
            ImplementerComboBox.ItemsSource = implementers;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(Status)).Cast<Status>();
            work = workService.getById(id);
            IdTextBlock.Text = work.Id.ToString();
            WorkNameTextBox.Text = work.WorkName;
            StartDatePicker.SelectedDate = work.StartDate;
            EndDatePicker.SelectedDate = work.EndDate;
            ImplementerComboBox.SelectedIndex = work.ImplementerId-1;
            StatusComboBox.SelectedIndex = (int)work.Status;
        }



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (WorkNameTextBox.Text == "" || status == null || implementerId == null)
            {
                IsModelValid = false;
            }
            if (IsModelValid)
            {
                work.WorkName = WorkNameTextBox.Text;
                work.StartDate = StartDatePicker.DisplayDate;
                work.EndDate = EndDatePicker.DisplayDate;
                work.Status = (Status)status;
                work.ImplementerId = (int)implementerId;
                workService.Edit(work);
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
