namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
			this.buttonDb = new System.Windows.Forms.Button();
			this.buttonService = new System.Windows.Forms.Button();
			this.labelResponse = new System.Windows.Forms.Label();
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonDb
			// 
			this.buttonDb.Dock = System.Windows.Forms.DockStyle.Left;
			this.buttonDb.Location = new System.Drawing.Point(0, 0);
			this.buttonDb.Name = "buttonDb";
			this.buttonDb.Size = new System.Drawing.Size(75, 176);
			this.buttonDb.TabIndex = 0;
			this.buttonDb.Text = "Appeler la db";
			this.buttonDb.UseVisualStyleBackColor = true;
			this.buttonDb.Click += new System.EventHandler(this.buttonDb_Click);
			// 
			// buttonService
			// 
			this.buttonService.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonService.Location = new System.Drawing.Point(351, 0);
			this.buttonService.Name = "buttonService";
			this.buttonService.Size = new System.Drawing.Size(75, 176);
			this.buttonService.TabIndex = 1;
			this.buttonService.Text = "Appeler le service";
			this.buttonService.UseVisualStyleBackColor = true;
			this.buttonService.Click += new System.EventHandler(this.buttonService_Click);
			// 
			// labelResponse
			// 
			this.labelResponse.AutoSize = true;
			this.labelResponse.Location = new System.Drawing.Point(26, 35);
			this.labelResponse.Name = "labelResponse";
			this.labelResponse.Size = new System.Drawing.Size(0, 13);
			this.labelResponse.TabIndex = 2;
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.labelResponse);
			this.groupBox.Location = new System.Drawing.Point(81, 12);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(264, 152);
			this.groupBox.TabIndex = 3;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Réponse du serveur";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 176);
			this.Controls.Add(this.groupBox);
			this.Controls.Add(this.buttonService);
			this.Controls.Add(this.buttonDb);
			this.Name = "Form1";
			this.Text = "Form1";
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDb;
        private System.Windows.Forms.Button buttonService;
		private System.Windows.Forms.Label labelResponse;
		private System.Windows.Forms.GroupBox groupBox;
	}
}

