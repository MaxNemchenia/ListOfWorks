using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QulixTestWork
{
    public partial class WorkForm : Window
    {
        IService<Work> workService;
        IService<Implementer> implementerService;
        int? currentId;



        public WorkForm()
        {
            InitializeComponent();
            workService = new WorkService();
            implementerService = new ImplementerService();
            workDataGrid.ItemsSource = workService.getAll();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            InsertWorkForm insertWorkForm = new InsertWorkForm(implementerService, workService);
            insertWorkForm.Closed += new EventHandler(WorkFormClosedEvent);
            insertWorkForm.ShowDialog();
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentId != null)
            {
                workService.Delete((int)currentId);
                workDataGrid.ItemsSource = workService.getAll();
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
                UpdateWorkForm updateWorkForm = new UpdateWorkForm((int)currentId, implementerService, workService);
                updateWorkForm.Closed += new EventHandler(WorkFormClosedEvent);
                updateWorkForm.ShowDialog();
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
            if (v.Count > 0 && v[0] is Work)
            {
                currentId = ((Work)v[0]).Id; 
            }
            else
            {
                currentId = null;
            }
        }



        void WorkFormClosedEvent(object sender, EventArgs e)
        {
            workDataGrid.ItemsSource = workService.getAll();
        }
    }
}
