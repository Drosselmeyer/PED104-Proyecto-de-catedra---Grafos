
namespace PED104_Proyecto_de_catedra___Grafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Conexion = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.ConsultarCadena = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Conexion
            // 
            this.Conexion.Location = new System.Drawing.Point(194, 140);
            this.Conexion.Name = "Conexion";
            this.Conexion.Size = new System.Drawing.Size(115, 29);
            this.Conexion.TabIndex = 0;
            this.Conexion.Text = "Conectar";
            this.Conexion.UseVisualStyleBackColor = true;
            this.Conexion.Click += new System.EventHandler(this.Conexion_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(194, 203);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(115, 26);
            this.Desconectar.TabIndex = 1;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // ConsultarCadena
            // 
            this.ConsultarCadena.Location = new System.Drawing.Point(194, 268);
            this.ConsultarCadena.Name = "ConsultarCadena";
            this.ConsultarCadena.Size = new System.Drawing.Size(115, 30);
            this.ConsultarCadena.TabIndex = 2;
            this.ConsultarCadena.Text = "Consultar Cadena";
            this.ConsultarCadena.UseVisualStyleBackColor = true;
            this.ConsultarCadena.Click += new System.EventHandler(this.Consultar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConsultarCadena);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.Conexion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Conexion;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button ConsultarCadena;
    }
}

