namespace TestNN
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.drawingBox = new System.Windows.Forms.PictureBox();
			this.clearButton = new System.Windows.Forms.Button();
			this.enterButton = new System.Windows.Forms.Button();
			this.statesListBox = new System.Windows.Forms.ListBox();
			this.getMNISTButton = new System.Windows.Forms.Button();
			this.nextImage = new System.Windows.Forms.Button();
			this.getNeuralNetworkButton = new System.Windows.Forms.Button();
			this.learnButton = new System.Windows.Forms.Button();
			this.loadNeuronNetworkButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.croppedImageBox = new System.Windows.Forms.PictureBox();
			this.compressedImageBox = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.drawingBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.croppedImageBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.compressedImageBox)).BeginInit();
			this.SuspendLayout();
			// 
			// drawingBox
			// 
			this.drawingBox.BackColor = System.Drawing.SystemColors.ControlLight;
			this.drawingBox.Location = new System.Drawing.Point(48, 38);
			this.drawingBox.Name = "drawingBox";
			this.drawingBox.Size = new System.Drawing.Size(280, 280);
			this.drawingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.drawingBox.TabIndex = 0;
			this.drawingBox.TabStop = false;
			this.drawingBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingBox_MouseMove);
			// 
			// clearButton
			// 
			this.clearButton.Enabled = false;
			this.clearButton.Location = new System.Drawing.Point(253, 338);
			this.clearButton.Name = "clearButton";
			this.clearButton.Size = new System.Drawing.Size(75, 23);
			this.clearButton.TabIndex = 1;
			this.clearButton.Text = "Очистить";
			this.clearButton.UseVisualStyleBackColor = true;
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// enterButton
			// 
			this.enterButton.Enabled = false;
			this.enterButton.Location = new System.Drawing.Point(48, 338);
			this.enterButton.Name = "enterButton";
			this.enterButton.Size = new System.Drawing.Size(75, 23);
			this.enterButton.TabIndex = 2;
			this.enterButton.Text = "Ввести";
			this.enterButton.UseVisualStyleBackColor = true;
			this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
			// 
			// statesListBox
			// 
			this.statesListBox.FormattingEnabled = true;
			this.statesListBox.Location = new System.Drawing.Point(486, 38);
			this.statesListBox.Name = "statesListBox";
			this.statesListBox.Size = new System.Drawing.Size(240, 277);
			this.statesListBox.TabIndex = 3;
			// 
			// getMNISTButton
			// 
			this.getMNISTButton.Location = new System.Drawing.Point(352, 38);
			this.getMNISTButton.Name = "getMNISTButton";
			this.getMNISTButton.Size = new System.Drawing.Size(110, 45);
			this.getMNISTButton.TabIndex = 4;
			this.getMNISTButton.Text = "Загрузить выборку";
			this.getMNISTButton.UseVisualStyleBackColor = true;
			this.getMNISTButton.Click += new System.EventHandler(this.GetMNIST_Click);
			// 
			// nextImage
			// 
			this.nextImage.Enabled = false;
			this.nextImage.Location = new System.Drawing.Point(352, 238);
			this.nextImage.Name = "nextImage";
			this.nextImage.Size = new System.Drawing.Size(110, 41);
			this.nextImage.TabIndex = 7;
			this.nextImage.Text = "Следующее изображение";
			this.nextImage.UseVisualStyleBackColor = true;
			this.nextImage.Click += new System.EventHandler(this.nextImage_Click);
			// 
			// getNeuralNetworkButton
			// 
			this.getNeuralNetworkButton.Location = new System.Drawing.Point(352, 89);
			this.getNeuralNetworkButton.Name = "getNeuralNetworkButton";
			this.getNeuralNetworkButton.Size = new System.Drawing.Size(110, 41);
			this.getNeuralNetworkButton.TabIndex = 8;
			this.getNeuralNetworkButton.Text = "Создать нейронную сеть";
			this.getNeuralNetworkButton.UseVisualStyleBackColor = true;
			this.getNeuralNetworkButton.Click += new System.EventHandler(this.getNeuralNetworkButton_Click);
			// 
			// learnButton
			// 
			this.learnButton.Enabled = false;
			this.learnButton.Location = new System.Drawing.Point(352, 136);
			this.learnButton.Name = "learnButton";
			this.learnButton.Size = new System.Drawing.Size(110, 23);
			this.learnButton.TabIndex = 10;
			this.learnButton.Text = "Обучить";
			this.learnButton.UseVisualStyleBackColor = true;
			this.learnButton.Click += new System.EventHandler(this.learnButton_Click);
			// 
			// loadNeuronNetworkButton
			// 
			this.loadNeuronNetworkButton.Enabled = false;
			this.loadNeuronNetworkButton.Location = new System.Drawing.Point(352, 165);
			this.loadNeuronNetworkButton.Name = "loadNeuronNetworkButton";
			this.loadNeuronNetworkButton.Size = new System.Drawing.Size(110, 38);
			this.loadNeuronNetworkButton.TabIndex = 11;
			this.loadNeuronNetworkButton.Text = "Загрузить обученную сеть";
			this.loadNeuronNetworkButton.UseVisualStyleBackColor = true;
			this.loadNeuronNetworkButton.Click += new System.EventHandler(this.loadNeuronNetworkButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Поле для рисования";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(483, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(207, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Состояния нейронов в последнем слое";
			// 
			// saveButton
			// 
			this.saveButton.Enabled = false;
			this.saveButton.Location = new System.Drawing.Point(352, 209);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(110, 23);
			this.saveButton.TabIndex = 15;
			this.saveButton.Text = "Сохранить сеть";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// croppedImageBox
			// 
			this.croppedImageBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.croppedImageBox.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.croppedImageBox.Location = new System.Drawing.Point(764, 59);
			this.croppedImageBox.Name = "croppedImageBox";
			this.croppedImageBox.Size = new System.Drawing.Size(100, 100);
			this.croppedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.croppedImageBox.TabIndex = 16;
			this.croppedImageBox.TabStop = false;
			// 
			// compressedImageBox
			// 
			this.compressedImageBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.compressedImageBox.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.compressedImageBox.Location = new System.Drawing.Point(764, 215);
			this.compressedImageBox.Name = "compressedImageBox";
			this.compressedImageBox.Size = new System.Drawing.Size(100, 100);
			this.compressedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.compressedImageBox.TabIndex = 17;
			this.compressedImageBox.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(761, 195);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "разрешения";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(761, 182);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(126, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "После преобразования";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(761, 43);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(122, 13);
			this.label5.TabIndex = 19;
			this.label5.Text = "пустого пространства:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(761, 29);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 18;
			this.label4.Text = "После отсечения";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(902, 373);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.compressedImageBox);
			this.Controls.Add(this.croppedImageBox);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.loadNeuronNetworkButton);
			this.Controls.Add(this.learnButton);
			this.Controls.Add(this.getNeuralNetworkButton);
			this.Controls.Add(this.nextImage);
			this.Controls.Add(this.getMNISTButton);
			this.Controls.Add(this.statesListBox);
			this.Controls.Add(this.enterButton);
			this.Controls.Add(this.clearButton);
			this.Controls.Add(this.drawingBox);
			this.Cursor = System.Windows.Forms.Cursors.AppStarting;
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.drawingBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.croppedImageBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.compressedImageBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox drawingBox;
		private System.Windows.Forms.Button clearButton;
		private System.Windows.Forms.Button enterButton;
		private System.Windows.Forms.ListBox statesListBox;
		private System.Windows.Forms.Button getMNISTButton;
		private System.Windows.Forms.Button nextImage;
		private System.Windows.Forms.Button getNeuralNetworkButton;
		private System.Windows.Forms.Button learnButton;
		private System.Windows.Forms.Button loadNeuronNetworkButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.PictureBox croppedImageBox;
		private System.Windows.Forms.PictureBox compressedImageBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
	}
}

