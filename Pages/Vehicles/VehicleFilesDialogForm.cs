using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using smpc_admin.Models;
using smpc_admin.Services;
using smpc_admin.Properties;

namespace smpc_admin.Pages.Vehicles
{
    public partial class VehicleFilesDialogForm : Form
    {
        private VehicleModel _vehicle;
        private ImageList _fileIcons;

        private List<VehicleFileModel> _files = new List<VehicleFileModel>();
        public VehicleFilesDialogForm(VehicleModel vehicle)
        {
            InitializeComponent();
            _vehicle = vehicle;
            _files = vehicle.Files.ToList();

            FilesListView.AllowDrop = true;
            FilesListView.DragEnter += MyListView_DragEnter;
            FilesListView.DragDrop += MyListView_DragDrop;
            FilesListView.MouseClick += FilesListView_Click;


        }

        private void VehicleFilesDialogForm_Load(object sender, EventArgs e)
        {
            InitializeFilesListView();
            SetupFilesListView();
        }

        private void InitializeFilesListView()
        {
            _fileIcons = new ImageList
            {
                ImageSize = new Size(32, 32),
                ColorDepth = ColorDepth.Depth32Bit
            };

            FilesListView.View = View.LargeIcon;
            FilesListView.LargeImageList = _fileIcons;
            FilesListView.MultiSelect = false;
            FilesListView.Items.Clear();
        }

        private void SetupFilesListView()
        {
            FilesListView.Items.Clear();
            _fileIcons.Images.Clear();

            int iconIndex = 0;

            foreach (var file in _files)
            {
                Image iconImage = GetIconForMimeType(file.Type);

                _fileIcons.Images.Add(iconImage);

                var item = new ListViewItem
                {
                    Text = file.OriginalName ?? file.FileName,
                    ImageIndex = iconIndex++,
                    Tag = file
                };

                FilesListView.Items.Add(item);
            }
        }

        private void FilesListView_Click(object sender, MouseEventArgs e)
        {
            if (FilesListView.SelectedItems.Count > 0)
            {
                var item = FilesListView.SelectedItems[0];
                var file = item.Tag as VehicleFileModel;

                if (file == null)
                {
                    MessageBox.Show("Invalid file selected.");
                    return;
                }

               if (e.Button == MouseButtons.Left)
                {
                    ViewFile(file); 
                }

                if(e.Button == MouseButtons.Right)
                {
                   DeleteFile(file);
                }
            }
        }

        private async void UploadFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Multiselect = true;
                    dialog.Filter = "All files (*.*)|*.*";
                    dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        UploadFileBtn.Enabled = false;
                        foreach (var filePath in dialog.FileNames)
                        {
                            var res = await VehicleFileService.UploadVehicleFileAsync(filePath, _vehicle.Id);

                            if (res != null && res.Success && res.Data is VehicleFileModel uploadedFile)
                            {
                                _files.Add(uploadedFile);
                            }
                            else
                            {
                                MessageBox.Show($"Failed to upload file: {Path.GetFileName(filePath)}");
                            }
                        }

                        // Refresh ListView after all uploads
                        SetupFilesListView();
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                this.Cursor = Cursors.Default;
                UploadFileBtn.Enabled = true;
            }
        }


        private async void ViewFile(VehicleFileModel file)
        {
            try
            {
                if (!File.Exists(file.FilePath))
                {
            
                    var res = await VehicleFileService.DownloadVehicleFileAsync(file.FilePath);

                    if (!res.Success)
                    {
                        MessageBox.Show("Failed to download file: " + res.Message);
                        return;
                    }

                    // Update file path to downloaded location
                    file.FilePath = res.Data.FilePath;
                }

                // Open the file with default associated app
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = file.FilePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open file: " + ex.Message);
            }
        }


        private async void DeleteFile(VehicleFileModel file)
        {
            var confirm = MessageBox.Show(
                $"Are you sure you want to delete this file?\n\n{file.OriginalName ?? file.FileName}",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Delete from disk
                    if (File.Exists(file.FilePath))
                    {
                        File.Delete(file.FilePath);
                    }

                    var res = await VehicleFileService.RemoveVehicleFileAsync(file.Id);

                    if(res != null && res.Success)
                    {
                         _files.Remove(file);
                         SetupFilesListView();
                    }
           
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting file: " + ex.Message);
                }
            }
        }

        
        private Image GetIconForMimeType(string mimeType)
        {
            
            if (string.IsNullOrEmpty(mimeType))
                return Properties.Resources.folder_unknown;

            if (mimeType.StartsWith("image/"))
                return Properties.Resources.icon_iamge;

            switch (mimeType)
            {
                case "application/pdf":
                    return Properties.Resources.icon_pdf;
                case "application/msword":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                    return Properties.Resources.icon_doc;
                case "application/vnd.ms-excel":
                case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                    return Properties.Resources.icon_excel;
                case "application/zip":
                case "application/x-zip-compressed":
                    return Properties.Resources.icon_zip;
                default:
                    return Properties.Resources.folder_unknown;
            }
        }

        private void MyListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        private async void MyListView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                 {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (var filePath in files)
                {
                    var res = await VehicleFileService.UploadVehicleFileAsync(filePath, _vehicle.Id);

                    if (res != null && res.Success && res.Data is VehicleFileModel uploadedFile)
                    {
                        _files.Add(uploadedFile);
                        SetupFilesListView();
                    }
                    else
                    {
                        MessageBox.Show($"Failed to upload file: {Path.GetFileName(filePath)}");
                    }
                }
            }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Access denied to selected folder.\n" + ex.Message);
            }
           
        }


    }
}
