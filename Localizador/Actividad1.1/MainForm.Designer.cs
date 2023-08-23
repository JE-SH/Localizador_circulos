/*
 * Created by SharpDevelop.
 * User: JESH
 * Date: 31/01/2020
 * Time: 05:51 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad1._
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button agregarImagen;
		private System.Windows.Forms.Button analizarImagen;
		private System.Windows.Forms.OpenFileDialog OpenFD;
		private System.Windows.Forms.TextBox textBox1;

		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.agregarImagen = new System.Windows.Forms.Button();
			this.analizarImagen = new System.Windows.Forms.Button();
			this.OpenFD = new System.Windows.Forms.OpenFileDialog();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(13, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(507, 464);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// agregarImagen
			// 
			this.agregarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.agregarImagen.Location = new System.Drawing.Point(664, 64);
			this.agregarImagen.Name = "agregarImagen";
			this.agregarImagen.Size = new System.Drawing.Size(172, 46);
			this.agregarImagen.TabIndex = 1;
			this.agregarImagen.Text = "Agregar Imagen";
			this.agregarImagen.UseVisualStyleBackColor = true;
			this.agregarImagen.Click += new System.EventHandler(this.AgregarImagenClick);
			// 
			// analizarImagen
			// 
			this.analizarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.analizarImagen.Location = new System.Drawing.Point(664, 160);
			this.analizarImagen.Name = "analizarImagen";
			this.analizarImagen.Size = new System.Drawing.Size(156, 55);
			this.analizarImagen.TabIndex = 2;
			this.analizarImagen.Text = "Analizar";
			this.analizarImagen.UseVisualStyleBackColor = true;
			this.analizarImagen.Click += new System.EventHandler(this.AnalizarImagenClick);
			// 
			// OpenFD
			// 
			this.OpenFD.FileName = "OpenFD";
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.textBox1.Location = new System.Drawing.Point(528, 232);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(360, 248);
			this.textBox1.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(896, 480);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.analizarImagen);
			this.Controls.Add(this.agregarImagen);
			this.Controls.Add(this.pictureBox1);
			this.Name = "MainForm";
			this.Text = "Actividad1.1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}//this.ResumeLayout(false);
			//this.PerformLayout();

		}
	}
//}
