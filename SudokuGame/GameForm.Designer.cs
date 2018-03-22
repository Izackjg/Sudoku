namespace SudokuGame
{
    partial class GameForm
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
            this.btnDisplayAnswers = new System.Windows.Forms.Button();
            this.btnReshuffle = new System.Windows.Forms.Button();
            this.lblHiddenCount = new System.Windows.Forms.Label();
            this.board = new System.Windows.Forms.PictureBox();
            this.cmbDifficulties = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisplayAnswers
            // 
            this.btnDisplayAnswers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDisplayAnswers.Location = new System.Drawing.Point(8, 12);
            this.btnDisplayAnswers.Name = "btnDisplayAnswers";
            this.btnDisplayAnswers.Size = new System.Drawing.Size(155, 30);
            this.btnDisplayAnswers.TabIndex = 0;
            this.btnDisplayAnswers.Text = "Display";
            this.btnDisplayAnswers.UseVisualStyleBackColor = true;
            this.btnDisplayAnswers.Click += new System.EventHandler(this.btnDisplayAnswers_Click);
            // 
            // btnReshuffle
            // 
            this.btnReshuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnReshuffle.Location = new System.Drawing.Point(8, 50);
            this.btnReshuffle.Name = "btnReshuffle";
            this.btnReshuffle.Size = new System.Drawing.Size(155, 30);
            this.btnReshuffle.TabIndex = 1;
            this.btnReshuffle.Text = "New Game";
            this.btnReshuffle.UseVisualStyleBackColor = true;
            // 
            // lblHiddenCount
            // 
            this.lblHiddenCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHiddenCount.Location = new System.Drawing.Point(8, 403);
            this.lblHiddenCount.Name = "lblHiddenCount";
            this.lblHiddenCount.Size = new System.Drawing.Size(155, 30);
            this.lblHiddenCount.TabIndex = 2;
            this.lblHiddenCount.Text = "Hidden: ";
            this.lblHiddenCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.board.Location = new System.Drawing.Point(171, 12);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(444, 421);
            this.board.TabIndex = 3;
            this.board.TabStop = false;
            // 
            // cmbDifficulties
            // 
            this.cmbDifficulties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDifficulties.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cmbDifficulties.FormattingEnabled = true;
            this.cmbDifficulties.Location = new System.Drawing.Point(8, 86);
            this.cmbDifficulties.Name = "cmbDifficulties";
            this.cmbDifficulties.Size = new System.Drawing.Size(155, 32);
            this.cmbDifficulties.TabIndex = 5;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 446);
            this.Controls.Add(this.cmbDifficulties);
            this.Controls.Add(this.board);
            this.Controls.Add(this.lblHiddenCount);
            this.Controls.Add(this.btnReshuffle);
            this.Controls.Add(this.btnDisplayAnswers);
            this.Name = "GameForm";
            this.Text = "Game Form";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDisplayAnswers;
        private System.Windows.Forms.Button btnReshuffle;
        private System.Windows.Forms.Label lblHiddenCount;
        private System.Windows.Forms.PictureBox board;
        private System.Windows.Forms.ComboBox cmbDifficulties;
    }
}

