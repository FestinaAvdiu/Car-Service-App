using System;
using System.Drawing;
using System.Windows.Forms;

namespace IDNF6R_Homework
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Load += AboutForm_Load;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            // Create Neptun code label
            Label neptunLabel = new Label();
            neptunLabel.Text = "IDNF6R";
            neptunLabel.AutoSize = true;
            neptunLabel.Location = new Point(75, 50); 
            neptunLabel.Font = new Font(neptunLabel.Font.FontFamily, 10, FontStyle.Regular);
            panelAbout.Controls.Add(neptunLabel);

            // Create current date label
            Label dateLabel = new Label();
            dateLabel.Text = DateTime.Now.ToString("yyyy.MM.dd");
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(65, 80); 
            dateLabel.Font = new Font(dateLabel.Font.FontFamily, 10, FontStyle.Regular);
            panelAbout.Controls.Add(dateLabel);

            // Create OK button
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Size = new Size(90, 30);
            okButton.Location = new Point(60, 132); 
            okButton.Click += OkButton_Click;
            panelAbout.Controls.Add(okButton);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

