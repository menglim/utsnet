
namespace ERPClientTools.Forms
{
    partial class frmServer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv = new Components.MDataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.mButton1 = new Components.MButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mButton2 = new Components.MButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mButton3 = new Components.MButton();
            this.panel58 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 172);
            this.panel3.TabIndex = 91;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoRefreshInterval = 0;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv.BorderColor = System.Drawing.SystemColors.Control;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeight = 30;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.ColumnKeyIndex = 0;
            this.dgv.CustomContextMenuRow = null;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.DuplicateColumn = 0;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.EnableRandomColor = false;
            this.dgv.GridColor = System.Drawing.SystemColors.Control;
            this.dgv.HighLightDuplication = false;
            this.dgv.KeepOldColor = false;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowTemplate.Height = 25;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowEditingIcon = false;
            this.dgv.ShowGroup = false;
            this.dgv.Size = new System.Drawing.Size(395, 172);
            this.dgv.TabIndex = 90;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel17);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 32);
            this.panel2.TabIndex = 93;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.mButton1);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(155, 0);
            this.panel17.Name = "panel17";
            this.panel17.Padding = new System.Windows.Forms.Padding(1);
            this.panel17.Size = new System.Drawing.Size(80, 32);
            this.panel17.TabIndex = 97;
            // 
            // mButton1
            // 
            this.mButton1.AllowEditDisplayText = true;
            this.mButton1.BackColor = System.Drawing.Color.SteelBlue;
            this.mButton1.ButtonAction = Components.ButtonAction.ADD;
            this.mButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mButton1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton1.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton1.ForeColor = System.Drawing.SystemColors.Window;
            this.mButton1.Location = new System.Drawing.Point(1, 1);
            this.mButton1.Name = "mButton1";
            this.mButton1.PermissionCode = null;
            this.mButton1.Size = new System.Drawing.Size(78, 30);
            this.mButton1.TabIndex = 94;
            this.mButton1.Text = "ADD";
            this.mButton1.UseVisualStyleBackColor = false;
            this.mButton1.Click += new System.EventHandler(this.mButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(235, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(80, 32);
            this.panel1.TabIndex = 98;
            // 
            // mButton2
            // 
            this.mButton2.AllowEditDisplayText = true;
            this.mButton2.BackColor = System.Drawing.Color.SteelBlue;
            this.mButton2.ButtonAction = Components.ButtonAction.ADD;
            this.mButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mButton2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton2.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton2.ForeColor = System.Drawing.SystemColors.Window;
            this.mButton2.Location = new System.Drawing.Point(1, 1);
            this.mButton2.Name = "mButton2";
            this.mButton2.PermissionCode = null;
            this.mButton2.Size = new System.Drawing.Size(78, 30);
            this.mButton2.TabIndex = 95;
            this.mButton2.Text = "UPDATE";
            this.mButton2.UseVisualStyleBackColor = false;
            this.mButton2.Click += new System.EventHandler(this.mButton2_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.mButton3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(315, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(80, 32);
            this.panel4.TabIndex = 99;
            // 
            // mButton3
            // 
            this.mButton3.AllowEditDisplayText = true;
            this.mButton3.BackColor = System.Drawing.Color.SteelBlue;
            this.mButton3.ButtonAction = Components.ButtonAction.ADD;
            this.mButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mButton3.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mButton3.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mButton3.ForeColor = System.Drawing.SystemColors.Window;
            this.mButton3.Location = new System.Drawing.Point(1, 1);
            this.mButton3.Name = "mButton3";
            this.mButton3.PermissionCode = null;
            this.mButton3.Size = new System.Drawing.Size(78, 30);
            this.mButton3.TabIndex = 96;
            this.mButton3.Text = "DELETE";
            this.mButton3.UseVisualStyleBackColor = false;
            this.mButton3.Click += new System.EventHandler(this.mButton3_Click);
            // 
            // panel58
            // 
            this.panel58.BackColor = System.Drawing.Color.Gainsboro;
            this.panel58.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel58.Location = new System.Drawing.Point(0, 172);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(395, 1);
            this.panel58.TabIndex = 92;
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 205);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel58);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Kh MPS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Servers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServer_FormClosing);
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private Components.MButton mButton3;
        private System.Windows.Forms.Panel panel1;
        private Components.MButton mButton2;
        private System.Windows.Forms.Panel panel17;
        private Components.MButton mButton1;
        private Components.MDataGridView dgv;
        private System.Windows.Forms.Panel panel58;
    }
}