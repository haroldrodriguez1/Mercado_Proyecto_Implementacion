namespace Mercadito_Chavez_Sanabria
{
    partial class VentasPorFechaReporte
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
            this.Reporte_VentasPorFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ventasPorFechaDataSet = new Mercadito_Chavez_Sanabria.VentasPorFechaDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.reporteVentasPorFechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_VentasPorFechaTableAdapter = new Mercadito_Chavez_Sanabria.VentasPorFechaDataSetTableAdapters.Reporte_VentasPorFechaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_VentasPorFechaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasPorFechaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasPorFechaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Reporte_VentasPorFechaBindingSource
            // 
            this.Reporte_VentasPorFechaBindingSource.DataMember = "Reporte_VentasPorFecha";
            this.Reporte_VentasPorFechaBindingSource.DataSource = this.ventasPorFechaDataSet;
            // 
            // ventasPorFechaDataSet
            // 
            this.ventasPorFechaDataSet.DataSetName = "VentasPorFechaDataSet";
            this.ventasPorFechaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "ReporteVentasPorFecha";
            reportDataSource1.Value = this.Reporte_VentasPorFechaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.VentasPorFecha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(30, 80);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(746, 346);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(108, 43);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(404, 43);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFin.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(697, 43);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(12, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 25);
            this.btnRegresar.TabIndex = 47;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // reporteVentasPorFechaBindingSource
            // 
            this.reporteVentasPorFechaBindingSource.DataMember = "Reporte_VentasPorFecha";
            this.reporteVentasPorFechaBindingSource.DataSource = this.ventasPorFechaDataSet;
            // 
            // reporte_VentasPorFechaTableAdapter
            // 
            this.reporte_VentasPorFechaTableAdapter.ClearBeforeFill = true;
            // 
            // VentasPorFechaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.reportViewer1);
            this.Name = "VentasPorFechaReporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentasPorFechaReporte";
            this.Load += new System.EventHandler(this.VentasPorFechaReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Reporte_VentasPorFechaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventasPorFechaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasPorFechaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.BindingSource Reporte_VentasPorFechaBindingSource;
        private VentasPorFechaDataSet ventasPorFechaDataSet;
        private System.Windows.Forms.BindingSource reporteVentasPorFechaBindingSource;
        private VentasPorFechaDataSetTableAdapters.Reporte_VentasPorFechaTableAdapter reporte_VentasPorFechaTableAdapter;
    }
}