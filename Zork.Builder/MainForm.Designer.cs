namespace Zork.Builder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRooms = new System.Windows.Forms.TabPage();
            this.removeRoomButton = new System.Windows.Forms.Button();
            this.roomNameWarningLabel = new System.Windows.Forms.Label();
            this.addRoomButton = new System.Windows.Forms.Button();
            this.startingRoomCheckBox = new System.Windows.Forms.CheckBox();
            this.roomDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.roomDescriptionLabel = new System.Windows.Forms.Label();
            this.roomNameLabel = new System.Windows.Forms.Label();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.menuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "&Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "World Files (*.json)|*.json";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "World Files (*.json)|*.json";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRooms);
            this.tabControl.Controls.Add(this.tabPageItems);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 425);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageRooms
            // 
            this.tabPageRooms.AutoScroll = true;
            this.tabPageRooms.Controls.Add(this.removeRoomButton);
            this.tabPageRooms.Controls.Add(this.roomNameWarningLabel);
            this.tabPageRooms.Controls.Add(this.addRoomButton);
            this.tabPageRooms.Controls.Add(this.startingRoomCheckBox);
            this.tabPageRooms.Controls.Add(this.roomDescriptionTextBox);
            this.tabPageRooms.Controls.Add(this.roomNameTextBox);
            this.tabPageRooms.Controls.Add(this.roomDescriptionLabel);
            this.tabPageRooms.Controls.Add(this.roomNameLabel);
            this.tabPageRooms.Controls.Add(this.roomsListBox);
            this.tabPageRooms.Location = new System.Drawing.Point(4, 22);
            this.tabPageRooms.Name = "tabPageRooms";
            this.tabPageRooms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRooms.Size = new System.Drawing.Size(792, 399);
            this.tabPageRooms.TabIndex = 1;
            this.tabPageRooms.Text = "Rooms";
            this.tabPageRooms.UseVisualStyleBackColor = true;
            // 
            // removeRoomButton
            // 
            this.removeRoomButton.Enabled = false;
            this.removeRoomButton.Location = new System.Drawing.Point(76, 373);
            this.removeRoomButton.Name = "removeRoomButton";
            this.removeRoomButton.Size = new System.Drawing.Size(65, 23);
            this.removeRoomButton.TabIndex = 8;
            this.removeRoomButton.Text = "Remove";
            this.removeRoomButton.UseVisualStyleBackColor = true;
            this.removeRoomButton.Click += new System.EventHandler(this.RemoveRoomButton_Click);
            // 
            // roomNameWarningLabel
            // 
            this.roomNameWarningLabel.AutoSize = true;
            this.roomNameWarningLabel.ForeColor = System.Drawing.Color.Brown;
            this.roomNameWarningLabel.Location = new System.Drawing.Point(658, 44);
            this.roomNameWarningLabel.Name = "roomNameWarningLabel";
            this.roomNameWarningLabel.Size = new System.Drawing.Size(117, 13);
            this.roomNameWarningLabel.TabIndex = 7;
            this.roomNameWarningLabel.Text = "*Name must be unique.";
            this.roomNameWarningLabel.Visible = false;
            // 
            // addRoomButton
            // 
            this.addRoomButton.Location = new System.Drawing.Point(3, 373);
            this.addRoomButton.Name = "addRoomButton";
            this.addRoomButton.Size = new System.Drawing.Size(65, 23);
            this.addRoomButton.TabIndex = 6;
            this.addRoomButton.Text = "Add";
            this.addRoomButton.UseVisualStyleBackColor = true;
            this.addRoomButton.Click += new System.EventHandler(this.AddRoomButton_Click);
            // 
            // startingRoomCheckBox
            // 
            this.startingRoomCheckBox.AutoSize = true;
            this.startingRoomCheckBox.Location = new System.Drawing.Point(255, 18);
            this.startingRoomCheckBox.Name = "startingRoomCheckBox";
            this.startingRoomCheckBox.Size = new System.Drawing.Size(93, 17);
            this.startingRoomCheckBox.TabIndex = 5;
            this.startingRoomCheckBox.Text = "Starting Room";
            this.startingRoomCheckBox.UseVisualStyleBackColor = true;
            this.startingRoomCheckBox.VisibleChanged += new System.EventHandler(this.StartingRoomCheckBox_VisibleChanged);
            this.startingRoomCheckBox.Click += new System.EventHandler(this.StartingRoomCheckBox_CheckedChanged);
            // 
            // roomDescriptionTextBox
            // 
            this.roomDescriptionTextBox.AcceptsReturn = true;
            this.roomDescriptionTextBox.AcceptsTab = true;
            this.roomDescriptionTextBox.AllowDrop = true;
            this.roomDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Description", true));
            this.roomDescriptionTextBox.Location = new System.Drawing.Point(255, 80);
            this.roomDescriptionTextBox.Multiline = true;
            this.roomDescriptionTextBox.Name = "roomDescriptionTextBox";
            this.roomDescriptionTextBox.Size = new System.Drawing.Size(397, 90);
            this.roomDescriptionTextBox.TabIndex = 4;
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.gameViewModelBindingSource;
            this.roomsBindingSource.CurrentChanged += new System.EventHandler(this.StartingRoomCheckBox_VisibleChanged);
            // 
            // gameViewModelBindingSource
            // 
            this.gameViewModelBindingSource.DataSource = typeof(Zork.Builder.ViewModels.GameViewModel);
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.AllowDrop = true;
            this.roomNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Name", true));
            this.roomNameTextBox.Location = new System.Drawing.Point(297, 41);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(355, 20);
            this.roomNameTextBox.TabIndex = 3;
            this.roomNameTextBox.TextChanged += new System.EventHandler(this.RoomNameTextBox_TextChanged);
            // 
            // roomDescriptionLabel
            // 
            this.roomDescriptionLabel.AutoSize = true;
            this.roomDescriptionLabel.Location = new System.Drawing.Point(252, 64);
            this.roomDescriptionLabel.Name = "roomDescriptionLabel";
            this.roomDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.roomDescriptionLabel.TabIndex = 2;
            this.roomDescriptionLabel.Text = "Description:";
            // 
            // roomNameLabel
            // 
            this.roomNameLabel.AutoSize = true;
            this.roomNameLabel.Location = new System.Drawing.Point(252, 41);
            this.roomNameLabel.Name = "roomNameLabel";
            this.roomNameLabel.Size = new System.Drawing.Size(38, 13);
            this.roomNameLabel.TabIndex = 1;
            this.roomNameLabel.Text = "Name:";
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsBindingSource;
            this.roomsListBox.DisplayMember = "Name";
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(3, 3);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(138, 368);
            this.roomsListBox.TabIndex = 0;
            this.roomsListBox.ValueMember = "Description";
            this.roomsListBox.SelectedIndexChanged += new System.EventHandler(this.RoomsListBox_SelectedIndexChanged);
            // 
            // tabPageItems
            // 
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Size = new System.Drawing.Size(792, 399);
            this.tabPageItems.TabIndex = 2;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Zork Builder";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageRooms.ResumeLayout(false);
            this.tabPageRooms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRooms;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.BindingSource gameViewModelBindingSource;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private System.Windows.Forms.TextBox roomDescriptionTextBox;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Label roomDescriptionLabel;
        private System.Windows.Forms.Label roomNameLabel;
        private System.Windows.Forms.CheckBox startingRoomCheckBox;
        private System.Windows.Forms.Button addRoomButton;
        private System.Windows.Forms.Label roomNameWarningLabel;
        private System.Windows.Forms.Button removeRoomButton;
    }
}

