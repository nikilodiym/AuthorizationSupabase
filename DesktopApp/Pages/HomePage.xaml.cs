using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DesktopApp.Pages
{
    public partial class HomePage : UserControl
    {
        private readonly List<SubjectMark> _subjectMarks;

        public HomePage()
        {
            InitializeComponent();
            _subjectMarks = new List<SubjectMark>();
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(tbSubject.Text) || string.IsNullOrWhiteSpace(tbMark.Text))
                {
                    MessageBox.Show("Please fill in both Subject and Mark fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!int.TryParse(tbMark.Text, out int mark) || mark < 0 || mark > 100)
                {
                    MessageBox.Show("Mark must be a valid number between 0 and 100.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Add new entry to the list
                var newEntry = new SubjectMark
                {
                    SubjectId = _subjectMarks.Count + 1,
                    SubjectName = tbSubject.Text,
                    Mark = mark
                };
                _subjectMarks.Add(newEntry);

                // Refresh DataGrid
                dgMarkAndSubject.ItemsSource = null;
                dgMarkAndSubject.ItemsSource = _subjectMarks;

                // Clear input fields
                tbSubject.Clear();
                tbMark.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class SubjectMark
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Mark { get; set; }
    }
}