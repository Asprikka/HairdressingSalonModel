
namespace HairdressingSalonModel
{
    partial class OptionsForm
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
            this.labelHallCount = new System.Windows.Forms.Label();
            this.textBoxHallCount = new System.Windows.Forms.TextBox();
            this.labelMasterCount1 = new System.Windows.Forms.Label();
            this.textBoxMasterCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTimeBetweenOrders = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCustomerServiceDeviation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelMasterCount2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTimeStep = new System.Windows.Forms.TextBox();
            this.ButtonSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSimulationSpeed = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelHallCount
            // 
            this.labelHallCount.AutoSize = true;
            this.labelHallCount.Location = new System.Drawing.Point(15, 15);
            this.labelHallCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHallCount.Name = "labelHallCount";
            this.labelHallCount.Size = new System.Drawing.Size(157, 15);
            this.labelHallCount.TabIndex = 0;
            this.labelHallCount.Text = "Количество залов (до трёх)";
            // 
            // textBoxHallCount
            // 
            this.textBoxHallCount.Location = new System.Drawing.Point(15, 33);
            this.textBoxHallCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxHallCount.Name = "textBoxHallCount";
            this.textBoxHallCount.Size = new System.Drawing.Size(321, 23);
            this.textBoxHallCount.TabIndex = 1;
            // 
            // labelMasterCount1
            // 
            this.labelMasterCount1.AutoSize = true;
            this.labelMasterCount1.Location = new System.Drawing.Point(15, 72);
            this.labelMasterCount1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMasterCount1.Name = "labelMasterCount1";
            this.labelMasterCount1.Size = new System.Drawing.Size(183, 15);
            this.labelMasterCount1.TabIndex = 2;
            this.labelMasterCount1.Text = "Кол-во мастеров в каждом зале";
            // 
            // textBoxMasterCount
            // 
            this.textBoxMasterCount.Location = new System.Drawing.Point(15, 105);
            this.textBoxMasterCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxMasterCount.Name = "textBoxMasterCount";
            this.textBoxMasterCount.Size = new System.Drawing.Size(321, 23);
            this.textBoxMasterCount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 143);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Время между приходом новых клиентов";
            // 
            // textBoxTimeBetweenOrders
            // 
            this.textBoxTimeBetweenOrders.Location = new System.Drawing.Point(15, 177);
            this.textBoxTimeBetweenOrders.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxTimeBetweenOrders.Name = "textBoxTimeBetweenOrders";
            this.textBoxTimeBetweenOrders.Size = new System.Drawing.Size(321, 23);
            this.textBoxTimeBetweenOrders.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Процент отклонения от сроков выполнения заказа";
            // 
            // textBoxCustomerServiceDeviation
            // 
            this.textBoxCustomerServiceDeviation.Location = new System.Drawing.Point(14, 247);
            this.textBoxCustomerServiceDeviation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxCustomerServiceDeviation.Name = "textBoxCustomerServiceDeviation";
            this.textBoxCustomerServiceDeviation.Size = new System.Drawing.Size(322, 23);
            this.textBoxCustomerServiceDeviation.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 158);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "(целое значение в минутах от 1)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 228);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "(диапазон значений от -50)";
            // 
            // labelMasterCount2
            // 
            this.labelMasterCount2.AutoSize = true;
            this.labelMasterCount2.Location = new System.Drawing.Point(15, 87);
            this.labelMasterCount2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMasterCount2.Name = "labelMasterCount2";
            this.labelMasterCount2.Size = new System.Drawing.Size(124, 15);
            this.labelMasterCount2.TabIndex = 10;
            this.labelMasterCount2.Text = "(3 значения от 0 до 5)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 285);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Шаг моделирования";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 300);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "(целое значение от 1 до 15 минут)";
            // 
            // textBoxTimeStep
            // 
            this.textBoxTimeStep.Location = new System.Drawing.Point(14, 318);
            this.textBoxTimeStep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxTimeStep.Name = "textBoxTimeStep";
            this.textBoxTimeStep.Size = new System.Drawing.Size(322, 23);
            this.textBoxTimeStep.TabIndex = 13;
            // 
            // ButtonSaveChanges
            // 
            this.ButtonSaveChanges.Location = new System.Drawing.Point(236, 455);
            this.ButtonSaveChanges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonSaveChanges.Name = "ButtonSaveChanges";
            this.ButtonSaveChanges.Size = new System.Drawing.Size(141, 33);
            this.ButtonSaveChanges.TabIndex = 14;
            this.ButtonSaveChanges.Text = "Сохранить";
            this.ButtonSaveChanges.UseVisualStyleBackColor = true;
            this.ButtonSaveChanges.Click += new System.EventHandler(this.ButtonSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 358);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Скорость моделирования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 373);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "(значение от 0.1 до 1000 шагов в секунду)";
            // 
            // textBoxSimulationSpeed
            // 
            this.textBoxSimulationSpeed.Location = new System.Drawing.Point(14, 391);
            this.textBoxSimulationSpeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxSimulationSpeed.Name = "textBoxSimulationSpeed";
            this.textBoxSimulationSpeed.Size = new System.Drawing.Size(322, 23);
            this.textBoxSimulationSpeed.TabIndex = 17;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 502);
            this.Controls.Add(this.textBoxSimulationSpeed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonSaveChanges);
            this.Controls.Add(this.textBoxTimeStep);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelMasterCount2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCustomerServiceDeviation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTimeBetweenOrders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMasterCount);
            this.Controls.Add(this.labelMasterCount1);
            this.Controls.Add(this.textBoxHallCount);
            this.Controls.Add(this.labelHallCount);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки симуляции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHallCount;
        private System.Windows.Forms.TextBox textBoxHallCount;
        private System.Windows.Forms.Label labelMasterCount1;
        private System.Windows.Forms.TextBox textBoxMasterCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTimeBetweenOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCustomerServiceDeviation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelMasterCount2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTimeStep;
        private System.Windows.Forms.Button ButtonSaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSimulationSpeed;
    }
}

