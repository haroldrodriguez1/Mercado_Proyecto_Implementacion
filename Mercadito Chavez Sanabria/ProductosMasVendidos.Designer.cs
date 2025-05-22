namespace Mercadito_Chavez_Sanabria
{
    partial class ProductosMasVendidos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.obtenerProductosMasVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerProductosMasVendidosTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSetTableAdapters.ObtenerProductosMasVendidosTableAdapter();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosMasVendidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // obtenerProductosMasVendidosBindingSource
            // 
            this.obtenerProductosMasVendidosBindingSource.DataMember = "ObtenerProductosMasVendidos";
            this.obtenerProductosMasVendidosBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet;
            // 
            // mercado_Chavez_SanabriaDataSet
            // 
            this.mercado_Chavez_SanabriaDataSet.DataSetName = "Mercado_Chavez_SanabriaDataSet";
            this.mercado_Chavez_SanabriaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetPMV";
            reportDataSource1.Value = this.obtenerProductosMasVendidosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.PMV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 34);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 332);
            this.reportViewer1.TabIndex = 0;
            // 
            // obtenerProductosMasVendidosTableAdapter
            // 
            this.obtenerProductosMasVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(230, 2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(155, 27);
            this.btnRegresar.TabIndex = 51;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // ProductosMasVendidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductosMasVendidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductosMasVendidos";
            this.Load += new System.EventHandler(this.ProductosMasVendidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerProductosMasVendidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Mercado_Chavez_SanabriaDataSet mercado_Chavez_SanabriaDataSet;
        private System.Windows.Forms.BindingSource obtenerProductosMasVendidosBindingSource;
        private Mercado_Chavez_SanabriaDataSetTableAdapters.ObtenerProductosMasVendidosTableAdapter obtenerProductosMasVendidosTableAdapter;
        private System.Windows.Forms.Button btnRegresar;
    }
}