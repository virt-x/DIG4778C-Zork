using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Zork.Builder.ViewModels;
using Zork.Common;
using Newtonsoft.Json;

namespace Zork.Builder
{
    public partial class MainForm : Form
    {
        private GameViewModel _viewModel;
        private GameViewModel ViewModel
        {
            get { return _viewModel; } 
            set
            {
                _viewModel = value;
            }
        }

        public MainForm()
        {
            ViewModel = new GameViewModel();
            InitializeComponent();
            gameViewModelBindingSource.DataSource = _viewModel;
        }

        private bool CheckRoomsByName(string name)
        {
            foreach (Room r in ViewModel.Rooms)
            {
                if (name == r.Name)
                {
                    return true;
                }
            }
            return false;
        }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(openFileDialog.FileName));
                ViewModel.Filename = openFileDialog.FileName;
                StartingRoomCheckBox_VisibleChanged(sender, e);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ViewModel.Filename = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(ViewModel.Filename))
                {
                    throw new InvalidProgramException("Filename expected");
                }
            }
            ViewModel.Save();
        }

        private void StartingRoomCheckBox_VisibleChanged(object sender, EventArgs e)
        {
            if (startingRoomCheckBox.Visible)
            {
                Room room = (Room)roomsBindingSource.Current;
                if (room.Name == ViewModel.StartingLocation)
                {
                    startingRoomCheckBox.Checked = true;
                }
                else
                {
                    startingRoomCheckBox.Checked = false;
                }
                roomNameWarningLabel.Visible = false;
            }
        }
        private void StartingRoomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (startingRoomCheckBox.Checked)
            {
                Room room = (Room)roomsBindingSource.Current;
                ViewModel.StartingLocation = room.Name;
            }
            else
            {
                ViewModel.StartingLocation = null;
            }
        }

        private void RoomNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Room room = (Room)roomsBindingSource.Current;
            if (CheckRoomsByName(roomNameTextBox.Text))
            {
                roomNameWarningLabel.Visible = true;
            }
            else
            {
                roomNameWarningLabel.Visible = false;
                room.RenameRoom(roomNameTextBox.Text);
                StartingRoomCheckBox_CheckedChanged(sender, e);
            }
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            string newRoomName = "New Room";
            bool invalidName = true;
            for (int i = 1; invalidName; i++)
            {
                if (CheckRoomsByName(newRoomName))
                {
                    newRoomName = $"New Room {i}";
                }
                else
                {
                    invalidName= false;
                }
            }
            Room newRoom = new Room(newRoomName, "Description goes here.", new Dictionary<Directions, string>(), new List<string>());
            ViewModel.Rooms.Add(newRoom);
        }
        private void RoomsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeRoomButton.Enabled = roomsListBox.SelectedItem != null;
        }
        private void RemoveRoomButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove this room?", "Remove Room", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ViewModel.Rooms.Count == 1)
                {
                    MessageBox.Show("You must have at least 1 room.", "Error");
                    return;
                }
                ViewModel.Rooms.Remove((Room)roomsListBox.SelectedItem);
                roomsListBox.SelectedIndex = 0;
            }
        }
    }
}
