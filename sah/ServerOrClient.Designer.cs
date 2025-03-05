namespace sah
{
	partial class ServerOrClient
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
			this.btnServer = new System.Windows.Forms.Button();
			this.btnClient = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnServer
			// 
			this.btnServer.Location = new System.Drawing.Point(232, 193);
			this.btnServer.Name = "btnServer";
			this.btnServer.Size = new System.Drawing.Size(92, 45);
			this.btnServer.TabIndex = 0;
			this.btnServer.Text = "SERVER";
			this.btnServer.UseVisualStyleBackColor = true;
			this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
			// 
			// btnClient
			// 
			this.btnClient.Location = new System.Drawing.Point(415, 193);
			this.btnClient.Name = "btnClient";
			this.btnClient.Size = new System.Drawing.Size(96, 45);
			this.btnClient.TabIndex = 1;
			this.btnClient.Text = "CLIENT";
			this.btnClient.UseVisualStyleBackColor = true;
			this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
			// 
			// ServerOrClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnClient);
			this.Controls.Add(this.btnServer);
			this.Name = "ServerOrClient";
			this.Text = "ServerOrClient";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnServer;
		private System.Windows.Forms.Button btnClient;
	}
}