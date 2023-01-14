// This is a tutorial video made by Shaun Halverson
// https://www.youtube.com/watch?v=6Lcjeq4NZj4&list=PLPo-AcuZWmjzB6LMK_U4hV1WJK2klLQ_a&index=4

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApplication
{
    public partial class NoteTaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public NoteTaker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Notes");

            PreviousNotes.DataSource = notes;
        }

        private void Loadbutton_Click(object sender, EventArgs e)
        {
            titlebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void Newbutton_Click(object sender, EventArgs e)
        {
            titlebox.Text = "";
            notebox.Text = "";
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = titlebox.Text;
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Notes"] = notebox.Text;
            }
            else
            {
                notes.Rows.Add(titlebox.Text, notebox.Text);
            }
            titlebox.Text = "";
            notebox.Text = "";
            editing = false;
        }

        private void Deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not a valid note");
            }
        }

        private void PreviousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titlebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notebox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
