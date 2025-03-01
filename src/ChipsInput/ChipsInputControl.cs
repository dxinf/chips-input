using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class ChipsInputControl : UserControl
    {
        private TextBox txtInput;
        public List<string> Chips { get; private set; } = new List<string>();

        // Define a custom event for when chips change
        public event EventHandler ChipsChanged;

        public ChipsInputControl()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            // Overall textbox-style control
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.LightBlue;
            this.Padding = new Padding(0);
            this.AutoSize = false;
            this.Height = 30;
            this.MinimumSize = new Size(200, 30);

            // FlowLayoutPanel to hold chips + input
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.Height = 53;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.BorderStyle = BorderStyle.None;

            // Initialize the input TextBox
            txtInput = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Width = 150,
                Height = 30,
                //Padding = new Padding(3, 3, 0, 3),
                //Margin = new Padding(3, 3, 0, 3),
                Padding = new Padding(0),
                Margin = new Padding(3, 7, 3, 5),
                ForeColor = Color.Black,
                BackColor = Color.White
                
            };

            txtInput.KeyDown += TxtInput_KeyDown;
            flowLayoutPanel1.Controls.Add(txtInput);
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtInput.Text))
            {
                e.SuppressKeyPress = true; // Prevent beep sound
                AddChip(txtInput.Text.Trim());
                txtInput.Clear();
            }
        }

        public void AddChip(string text)
        {
            if (Chips.Contains(text)) return; // Prevent duplicates

            Chips.Add(text);

            // Measure text width dynamically
            int textWidth = TextRenderer.MeasureText(text, new Font("Arial", 9)).Width;

            // Create chip panel with dynamic width
            Panel chipPanel = new Panel
            {
                BackColor = Color.LightGray,
                AutoSize = false,
                Padding = new Padding(3, 2, 5, 2),
                Margin = new Padding(3, 3, 0, 0),
                Height = 22,
                BorderStyle = BorderStyle.None,
                Size = new Size(textWidth + 30, 22), // Dynamic width based on text
                MinimumSize = new Size(textWidth + 30, 22) // Dynamic width based on text
            };

            // Chip text label
            Label chipLabel = new Label
            {
                Text = text,
                AutoSize = true,
                ForeColor = Color.Black,
                Font = new Font("Arial", 9, FontStyle.Regular),
                Padding = new Padding(3, 3, 0, 3)
            };

            // Remove button (small "X" inside the chip)
            Button removeButton = new Button
            {
                Text = "×",
                Font = new Font("Arial", 8, FontStyle.Bold),
                Size = new Size(20, 20),
                Margin = new Padding(3, 0, 0, 0),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.LightSalmon
            };
            removeButton.FlatAppearance.BorderSize = 0; // Remove button border
            removeButton.Click += (s, e) => RemoveChip(chipPanel, text);

            // Horizontally stack chip content
            FlowLayoutPanel chipContent = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight
            };

            chipContent.Controls.Add(chipLabel);
            chipContent.Controls.Add(removeButton);
            chipPanel.Controls.Add(chipContent);

            // Add chip before the input box
            flowLayoutPanel1.Controls.Add(chipPanel);
            flowLayoutPanel1.Controls.SetChildIndex(txtInput, flowLayoutPanel1.Controls.Count - 1);

            AdjustInputSize();
            OnChipsChanged(); // fire event when chips are added
        }

        private void RemoveChip(Panel chipPanel, string text)
        {
            Chips.Remove(text);
            flowLayoutPanel1.Controls.Remove(chipPanel);
            AdjustInputSize();
            OnChipsChanged(); // fire event when chips are removed
        }

        private void AdjustInputSize()
        {
            // Adjust textbox width based on remaining space
            int totalChipWidth = flowLayoutPanel1.Controls.Cast<Control>().Where(c => c != txtInput).Sum(c => c.Width + 5);
            txtInput.Width = Math.Max(50, this.Width - totalChipWidth - 20);
        }

        public void ClearChips()
        {
            Chips.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(txtInput);
            OnChipsChanged(); // fire event when all chips are cleared
        }

        protected virtual void OnChipsChanged()
        {
            ChipsChanged?.Invoke(this, EventArgs.Empty);
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Focus();
                }
            }
        }
    }
}