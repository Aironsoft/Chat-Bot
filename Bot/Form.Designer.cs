namespace Bot
{
    partial class Form
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
            this.pnlDialog = new System.Windows.Forms.Panel();
            this.rtbDialog = new System.Windows.Forms.RichTextBox();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lbF1 = new System.Windows.Forms.Label();
            this.F3 = new System.Windows.Forms.Label();
            this.F2 = new System.Windows.Forms.Label();
            this.predict1 = new System.Windows.Forms.Label();
            this.predict2 = new System.Windows.Forms.Label();
            this.predict3 = new System.Windows.Forms.Label();
            this.chbPrediction = new System.Windows.Forms.CheckBox();
            this.rbDialog = new System.Windows.Forms.RadioButton();
            this.rbTraining = new System.Windows.Forms.RadioButton();
            this.lbWords = new System.Windows.Forms.Label();
            this.lbWordsCount = new System.Windows.Forms.Label();
            this.lbPhrases = new System.Windows.Forms.Label();
            this.lbPhrasesCount = new System.Windows.Forms.Label();
            this.pnlDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialog
            // 
            this.pnlDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDialog.AutoScroll = true;
            this.pnlDialog.BackColor = System.Drawing.Color.Silver;
            this.pnlDialog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlDialog.Controls.Add(this.rtbDialog);
            this.pnlDialog.Location = new System.Drawing.Point(88, 12);
            this.pnlDialog.Name = "pnlDialog";
            this.pnlDialog.Size = new System.Drawing.Size(409, 346);
            this.pnlDialog.TabIndex = 0;
            // 
            // rtbDialog
            // 
            this.rtbDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbDialog.Location = new System.Drawing.Point(3, 3);
            this.rtbDialog.Name = "rtbDialog";
            this.rtbDialog.ReadOnly = true;
            this.rtbDialog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbDialog.Size = new System.Drawing.Size(399, 336);
            this.rtbDialog.TabIndex = 0;
            this.rtbDialog.Text = "";
            // 
            // rtbInput
            // 
            this.rtbInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rtbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbInput.Location = new System.Drawing.Point(88, 395);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(409, 53);
            this.rtbInput.TabIndex = 1;
            this.rtbInput.Text = "";
            this.rtbInput.TextChanged += new System.EventHandler(this.rtbInput_TextChanged);
            this.rtbInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbInput_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSend.Location = new System.Drawing.Point(255, 454);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lbF1
            // 
            this.lbF1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbF1.Location = new System.Drawing.Point(90, 379);
            this.lbF1.Name = "lbF1";
            this.lbF1.Size = new System.Drawing.Size(130, 13);
            this.lbF1.TabIndex = 0;
            this.lbF1.Text = "F1";
            this.lbF1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // F3
            // 
            this.F3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.F3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.F3.Location = new System.Drawing.Point(367, 379);
            this.F3.Name = "F3";
            this.F3.Size = new System.Drawing.Size(130, 13);
            this.F3.TabIndex = 3;
            this.F3.Text = "F3";
            this.F3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // F2
            // 
            this.F2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.F2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.F2.Location = new System.Drawing.Point(226, 379);
            this.F2.Name = "F2";
            this.F2.Size = new System.Drawing.Size(130, 13);
            this.F2.TabIndex = 4;
            this.F2.Text = "F2";
            this.F2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // predict1
            // 
            this.predict1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.predict1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.predict1.Location = new System.Drawing.Point(91, 364);
            this.predict1.Name = "predict1";
            this.predict1.Size = new System.Drawing.Size(130, 13);
            this.predict1.TabIndex = 5;
            this.predict1.Text = "...";
            this.predict1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // predict2
            // 
            this.predict2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.predict2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.predict2.Location = new System.Drawing.Point(226, 364);
            this.predict2.Name = "predict2";
            this.predict2.Size = new System.Drawing.Size(130, 13);
            this.predict2.TabIndex = 8;
            this.predict2.Text = "...";
            this.predict2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // predict3
            // 
            this.predict3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.predict3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.predict3.Location = new System.Drawing.Point(367, 364);
            this.predict3.Name = "predict3";
            this.predict3.Size = new System.Drawing.Size(130, 13);
            this.predict3.TabIndex = 9;
            this.predict3.Text = "...";
            this.predict3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbPrediction
            // 
            this.chbPrediction.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chbPrediction.AutoSize = true;
            this.chbPrediction.Checked = true;
            this.chbPrediction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPrediction.Location = new System.Drawing.Point(88, 459);
            this.chbPrediction.Name = "chbPrediction";
            this.chbPrediction.Size = new System.Drawing.Size(107, 17);
            this.chbPrediction.TabIndex = 10;
            this.chbPrediction.Text = "Предсказывать";
            this.chbPrediction.UseVisualStyleBackColor = true;
            // 
            // rbDialog
            // 
            this.rbDialog.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbDialog.AutoSize = true;
            this.rbDialog.Checked = true;
            this.rbDialog.Location = new System.Drawing.Point(416, 455);
            this.rbDialog.Name = "rbDialog";
            this.rbDialog.Size = new System.Drawing.Size(63, 17);
            this.rbDialog.TabIndex = 11;
            this.rbDialog.TabStop = true;
            this.rbDialog.Text = "Диалог";
            this.rbDialog.UseVisualStyleBackColor = true;
            // 
            // rbTraining
            // 
            this.rbTraining.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbTraining.AutoSize = true;
            this.rbTraining.Location = new System.Drawing.Point(416, 478);
            this.rbTraining.Name = "rbTraining";
            this.rbTraining.Size = new System.Drawing.Size(73, 17);
            this.rbTraining.TabIndex = 12;
            this.rbTraining.Text = "Обучение";
            this.rbTraining.UseVisualStyleBackColor = true;
            // 
            // lbWords
            // 
            this.lbWords.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbWords.AutoSize = true;
            this.lbWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWords.Location = new System.Drawing.Point(12, 483);
            this.lbWords.Name = "lbWords";
            this.lbWords.Size = new System.Drawing.Size(82, 12);
            this.lbWords.TabIndex = 13;
            this.lbWords.Text = "Количество слов:";
            this.lbWords.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbWordsCount
            // 
            this.lbWordsCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbWordsCount.AutoSize = true;
            this.lbWordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWordsCount.Location = new System.Drawing.Point(92, 483);
            this.lbWordsCount.Name = "lbWordsCount";
            this.lbWordsCount.Size = new System.Drawing.Size(14, 12);
            this.lbWordsCount.TabIndex = 14;
            this.lbWordsCount.Text = "...";
            this.lbWordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPhrases
            // 
            this.lbPhrases.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbPhrases.AutoSize = true;
            this.lbPhrases.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPhrases.Location = new System.Drawing.Point(158, 483);
            this.lbPhrases.Name = "lbPhrases";
            this.lbPhrases.Size = new System.Drawing.Size(84, 12);
            this.lbPhrases.TabIndex = 15;
            this.lbPhrases.Text = "Количество фраз:";
            this.lbPhrases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPhrasesCount
            // 
            this.lbPhrasesCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbPhrasesCount.AutoSize = true;
            this.lbPhrasesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPhrasesCount.Location = new System.Drawing.Point(239, 483);
            this.lbPhrasesCount.Name = "lbPhrasesCount";
            this.lbPhrasesCount.Size = new System.Drawing.Size(14, 12);
            this.lbPhrasesCount.TabIndex = 16;
            this.lbPhrasesCount.Text = "...";
            this.lbPhrasesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.lbPhrasesCount);
            this.Controls.Add(this.lbPhrases);
            this.Controls.Add(this.lbWordsCount);
            this.Controls.Add(this.lbWords);
            this.Controls.Add(this.rbTraining);
            this.Controls.Add(this.rbDialog);
            this.Controls.Add(this.chbPrediction);
            this.Controls.Add(this.predict3);
            this.Controls.Add(this.predict2);
            this.Controls.Add(this.predict1);
            this.Controls.Add(this.F2);
            this.Controls.Add(this.F3);
            this.Controls.Add(this.lbF1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.pnlDialog);
            this.MinimumSize = new System.Drawing.Size(600, 540);
            this.Name = "Form";
            this.Text = "Kisa";
            this.pnlDialog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDialog;
        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbDialog;
        private System.Windows.Forms.Label lbF1;
        private System.Windows.Forms.Label F3;
        private System.Windows.Forms.Label F2;
        private System.Windows.Forms.Label predict1;
        private System.Windows.Forms.Label predict2;
        private System.Windows.Forms.Label predict3;
        private System.Windows.Forms.CheckBox chbPrediction;
        private System.Windows.Forms.RadioButton rbDialog;
        private System.Windows.Forms.RadioButton rbTraining;
        private System.Windows.Forms.Label lbWords;
        private System.Windows.Forms.Label lbWordsCount;
        private System.Windows.Forms.Label lbPhrases;
        private System.Windows.Forms.Label lbPhrasesCount;
    }
}

