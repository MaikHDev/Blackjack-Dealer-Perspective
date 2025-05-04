namespace Blackjack_Dealer_Perspective
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
            flipcard = new Button();
            label1 = new Label();
            dealersCardValue = new Label();
            SuspendLayout();
            // 
            // flipcard
            // 
            flipcard.Location = new Point(855, 402);
            flipcard.Name = "flipcard";
            flipcard.Size = new Size(86, 35);
            flipcard.TabIndex = 0;
            flipcard.Text = "Flip card";
            flipcard.UseVisualStyleBackColor = true;
            flipcard.Click += flipcard_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(802, 106);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 1;
            label1.Text = "Dealers card value:";
            // 
            // dealersCardValue
            // 
            dealersCardValue.AutoSize = true;
            dealersCardValue.Location = new Point(939, 106);
            dealersCardValue.Name = "dealersCardValue";
            dealersCardValue.Size = new Size(0, 15);
            dealersCardValue.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 552);
            Controls.Add(dealersCardValue);
            Controls.Add(label1);
            Controls.Add(flipcard);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button flipcard;
        private Label label1;
        private Label dealersCardValue;
    }
}
