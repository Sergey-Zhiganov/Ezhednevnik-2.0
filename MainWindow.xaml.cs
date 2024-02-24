using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ежедневник_2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            chosendate.Text = DateTime.Now.ToString();
            chosendate_SelectedDateChanged(null, null);
        }
        private void chosendate_SelectedDateChanged(object? sender, SelectionChangedEventArgs? e)
        {
            list_events.ItemsSource = CRUD.Read(DateOnly.Parse(chosendate.Text));
            list_events.Items.Refresh();
            name_event.Text = "";
            description_event.Text = "";
        }

        private void list_events_Selected(object sender, RoutedEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int current = lb.SelectedIndex;
            int index = 0;
            List<Event> events = CRUD.Read(DateOnly.Parse(chosendate.Text));
            foreach (var item in events)
            {
                if (item.EventDate == chosendate.Text)
                {
                    if (index++ == current)
                    {
                        name_event.Text = item.Name;
                        description_event.Text = item.Description;
                        return;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (name_event.Text != "" || description_event.Text != "")
            {
                Event new_event = new Event();
                new_event.Name = name_event.Text;
                new_event.Description = description_event.Text;
                new_event.EventDate = chosendate.Text;
                CRUD.Create(new_event);
                chosendate_SelectedDateChanged(null, null);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int current = list_events.SelectedIndex;
            string text = chosendate.Text;
            CRUD.Update(current, text, name_event.Text, description_event.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int current = list_events.SelectedIndex;
            string text = chosendate.Text;
            CRUD.Delete(current, text);
            chosendate_SelectedDateChanged(null, null);
        }
    }
}
