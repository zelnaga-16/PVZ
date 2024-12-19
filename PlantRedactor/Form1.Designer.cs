namespace PlantRedactor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PlantSelector = new ComboBox();
            ButtonBox = new GroupBox();
            UserKey = new TextBox();
            GameKey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // PlantSelector
            // 
            PlantSelector.FormattingEnabled = true;
            PlantSelector.Location = new Point(8, 53);
            PlantSelector.Name = "PlantSelector";
            PlantSelector.Size = new Size(380, 49);
            PlantSelector.TabIndex = 0;
            PlantSelector.SelectedIndexChanged += PlantSelector_SelectedIndexChanged;
            // 
            // ButtonBox
            // 
            ButtonBox.Enabled = false;
            ButtonBox.Location = new Point(178, 221);
            ButtonBox.Name = "ButtonBox";
            ButtonBox.Size = new Size(1000, 400);
            ButtonBox.TabIndex = 41;
            ButtonBox.TabStop = false;
            // 
            // UserKey
            // 
            UserKey.Location = new Point(394, 55);
            UserKey.Name = "UserKey";
            UserKey.Size = new Size(250, 47);
            UserKey.TabIndex = 42;
            // 
            // GameKey
            // 
            GameKey.Location = new Point(650, 55);
            GameKey.Name = "GameKey";
            GameKey.Size = new Size(250, 47);
            GameKey.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 41);
            label1.TabIndex = 44;
            label1.Text = "Plant";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(394, 9);
            label2.Name = "label2";
            label2.Size = new Size(186, 41);
            label2.TabIndex = 45;
            label2.Text = "User API Key";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(650, 9);
            label3.Name = "label3";
            label3.Size = new Size(204, 41);
            label3.TabIndex = 46;
            label3.Text = "Game API Key";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2502, 965);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GameKey);
            Controls.Add(UserKey);
            Controls.Add(ButtonBox);
            Controls.Add(PlantSelector);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox PlantSelector;
        private GroupBox ButtonBox;
        private TextBox UserKey;
        private TextBox GameKey;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
