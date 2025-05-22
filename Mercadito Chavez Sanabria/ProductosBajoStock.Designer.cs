namespace Mercadito_Chavez_Sanabria
{
    partial class ProductosBajoStock
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
            this.Reporte_ProductosBajoStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6local = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6local();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.reporteProductosBajoStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_ProductosBajoStockTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_ProductosBajoStockTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ProductosBajoStockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProductosBajoStockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_ProductosBajoStockBindingSource
            // 
            this.Reporte_ProductosBajoStockBindingSource.DataMember = "Reporte_ProductosBajoStock";
            this.Reporte_ProductosBajoStockBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // mercado_Chavez_SanabriaDataSet6local
            // 
            this.mercado_Chavez_SanabriaDataSet6local.DataSetName = "Mercado_Chavez_SanabriaDataSet6local";
            this.mercado_Chavez_SanabriaDataSet6local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Reporte_ProductosBajoStockBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.ProductosBajoStock.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 43);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 323);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(226, 6);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(151, 32);
            this.btnRegresar.TabIndex = 51;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // reporteProductosBajoStockBindingSource
            // 
            this.reporteProductosBajoStockBindingSource.DataMember = "Reporte_ProductosBajoStock";
            this.reporteProductosBajoStockBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // reporte_ProductosBajoStockTableAdapter
            // 
            this.reporte_ProductosBajoStockTableAdapter.ClearBeforeFill = true;
            // 
            // ProductosBajoStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductosBajoStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductosBajoStock";
            this.Load += new System.EventHandler(this.ProductosBajoStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_ProductosBajoStockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteProductosBajoStockBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.BindingSource reporteProductosBajoStockBindingSource;
        private Mercado_Chavez_SanabriaDataSet6local mercado_Chavez_SanabriaDataSet6local;
        private Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_ProductosBajoStockTableAdapter reporte_ProductosBajoStockTableAdapter;
        private System.Windows.Forms.BindingSource Reporte_ProductosBajoStockBindingSource;
    }
}