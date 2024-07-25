namespace EkpaideutikoLogismiko2024
{
    partial class Func_AdvFunc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Func_AdvFunc));
            this.buttonBack = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRecursion = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonReturnVals = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonPassList = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOnlyArgs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Location = new System.Drawing.Point(1060, 634);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(87, 41);
            this.buttonBack.TabIndex = 45;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(373, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(435, 34);
            this.label3.TabIndex = 46;
            this.label3.Text = "4.4 Advanced Function Concepts";
            // 
            // buttonRecursion
            // 
            this.buttonRecursion.BackColor = System.Drawing.Color.White;
            this.buttonRecursion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRecursion.Location = new System.Drawing.Point(192, 341);
            this.buttonRecursion.Name = "buttonRecursion";
            this.buttonRecursion.Size = new System.Drawing.Size(88, 34);
            this.buttonRecursion.TabIndex = 128;
            this.buttonRecursion.Text = "See Output";
            this.buttonRecursion.UseVisualStyleBackColor = false;
            this.buttonRecursion.Click += new System.EventHandler(this.buttonRecursion_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(89, 414);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(313, 200);
            this.label8.TabIndex = 127;
            this.label8.Text = resources.GetString("label8.Text");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(89, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 21);
            this.label9.TabIndex = 126;
            this.label9.Text = "Recursion";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(89, 384);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(240, 20);
            this.label11.TabIndex = 125;
            this.label11.Text = "Functions can call themselves:";
            // 
            // buttonReturnVals
            // 
            this.buttonReturnVals.BackColor = System.Drawing.Color.White;
            this.buttonReturnVals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReturnVals.Location = new System.Drawing.Point(747, 95);
            this.buttonReturnVals.Name = "buttonReturnVals";
            this.buttonReturnVals.Size = new System.Drawing.Size(88, 34);
            this.buttonReturnVals.TabIndex = 124;
            this.buttonReturnVals.Text = "See Output";
            this.buttonReturnVals.UseVisualStyleBackColor = false;
            this.buttonReturnVals.Click += new System.EventHandler(this.buttonReturnVals_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(606, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 120);
            this.label5.TabIndex = 123;
            this.label5.Text = "def my_function(x):\r\n    return 5 * x\r\n\r\nprint(my_function(3))\r\nprint(my_function" +
    "(5))\r\nprint(my_function(9))";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(606, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 21);
            this.label6.TabIndex = 122;
            this.label6.Text = "Return Values";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(606, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(450, 20);
            this.label7.TabIndex = 121;
            this.label7.Text = "Use the \'return\' statement to return values from a function:";
            // 
            // buttonPassList
            // 
            this.buttonPassList.BackColor = System.Drawing.Color.White;
            this.buttonPassList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPassList.Location = new System.Drawing.Point(370, 95);
            this.buttonPassList.Name = "buttonPassList";
            this.buttonPassList.Size = new System.Drawing.Size(88, 34);
            this.buttonPassList.TabIndex = 120;
            this.buttonPassList.Text = "See Output";
            this.buttonPassList.UseVisualStyleBackColor = false;
            this.buttonPassList.Click += new System.EventHandler(this.buttonPassList_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(89, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(292, 120);
            this.label12.TabIndex = 119;
            this.label12.Text = "def my_function(food):\r\n    for x in food:\r\n        print(x)\r\n\r\nfruits = [\"apple\"" +
    ", \"banana\", \"cherry\"]\r\nmy_function(fruits)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 21);
            this.label2.TabIndex = 118;
            this.label2.Text = "Passing a List as an Argument";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(89, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(358, 20);
            this.label4.TabIndex = 117;
            this.label4.Text = "Lists can be passed and used inside functions:";
            // 
            // buttonOnlyArgs
            // 
            this.buttonOnlyArgs.BackColor = System.Drawing.Color.White;
            this.buttonOnlyArgs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOnlyArgs.Location = new System.Drawing.Point(1024, 341);
            this.buttonOnlyArgs.Name = "buttonOnlyArgs";
            this.buttonOnlyArgs.Size = new System.Drawing.Size(88, 34);
            this.buttonOnlyArgs.TabIndex = 132;
            this.buttonOnlyArgs.Text = "See Output";
            this.buttonOnlyArgs.UseVisualStyleBackColor = false;
            this.buttonOnlyArgs.Click += new System.EventHandler(this.buttonOnlyArgs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(606, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 180);
            this.label1.TabIndex = 131;
            this.label1.Text = "def my_function(x, /):\r\n    print(x)\r\n\r\nmy_function(3)\r\n\r\ndef my_function(*, x):\r" +
    "\n    print(x)\r\n\r\nmy_function(x=3)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(606, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(412, 21);
            this.label10.TabIndex = 130;
            this.label10.Text = "Positional-Only and Keyword-Only Arguments";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(606, 384);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(314, 20);
            this.label13.TabIndex = 129;
            this.label13.Text = "Use \'/\' and \'*\' to specify argument types:";
            // 
            // Func_AdvFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1159, 687);
            this.Controls.Add(this.buttonOnlyArgs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonRecursion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonReturnVals);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonPassList);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonBack);
            this.Name = "Func_AdvFunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Function Concepts";
            this.Load += new System.EventHandler(this.Func_AdvFunc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRecursion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonReturnVals;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonPassList;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOnlyArgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
    }
}