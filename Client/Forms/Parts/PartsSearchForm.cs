﻿using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Parts
{
    public partial class PartsSearchForm : Window
    {
        public Part Result;

        public PartsSearchForm(string number = "")
        {
            InitializeComponent();

            MakesSearchResponse response = new MakesSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Make> make in response.Makes)
            {
                boxMakes.Items.Add(make.Value.Name);
            }

            ListParts.Columns[2].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - 5;

            this.labelMake.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelPartNumber.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelDescription.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textPartNumber.Text = number;

            if (number != "")
                Search();
        }

        private void Search()
        {
            PartsSearchResponse response = new PartsSearch(this.boxMakes.Text, this.textPartNumber.Text, this.textDescription.Text).PerformRequestAsync().Result;

            ListParts.Items.Clear();

            foreach (KeyValuePair<string, Part> part in response.Parts)
            {
                ListViewItem partItem = ListParts.Items.Add(part.Value.Number);
                partItem.Name = part.Key;
                partItem.SubItems.Add(part.Value.Make);
                partItem.SubItems.Add(part.Value.Description);
            };

            ListParts.Columns[2].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ListParts_Resize(object sender, EventArgs e)
        {
            if (ListParts.Columns.Count > 0)
            {
                ListParts.Columns[2].Width = ListParts.Width - ListParts.Columns[0].Width - ListParts.Columns[1].Width - 5;
            }
        }

        private void ListParts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string id = ListParts.SelectedItems[0].Name;
            string number = ListParts.SelectedItems[0].Text;
            string make = ListParts.SelectedItems[0].SubItems[1].Text;
            string description = ListParts.SelectedItems[0].SubItems[2].Text;

            PartsSearchResponse response = new PartsSearch(make, number, description).PerformRequestAsync().Result;
            Result = response.Parts[id];
            Client.MainWindow.CloseForm(this);
        }
    }
}