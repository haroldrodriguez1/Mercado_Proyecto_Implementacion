namespace Mercadito_Chavez_Sanabria
{
    partial class IngresosCategoria
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
            this.reporteIngresosPorCategoriaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6local = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6local();
            this.reporteIngresosPorCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mercado_Chavez_SanabriaDataSet6 = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_IngresosPorCategoriaTableAdapter = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6TableAdapters.Reporte_IngresosPorCategoriaTableAdapter();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.reporteIngresosPorCategoriaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reporte_IngresosPorCategoriaTableAdapter1 = new Mercadito_Chavez_Sanabria.Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_IngresosPorCategoriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteIngresosPorCategoriaBindingSource2
            // 
            this.reporteIngresosPorCategoriaBindingSource2.DataMember = "Reporte_IngresosPorCategoria";
            this.reporteIngresosPorCategoriaBindingSource2.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // mercado_Chavez_SanabriaDataSet6local
            // 
            this.mercado_Chavez_SanabriaDataSet6local.DataSetName = "Mercado_Chavez_SanabriaDataSet6local";
            this.mercado_Chavez_SanabriaDataSet6local.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteIngresosPorCategoriaBindingSource
            // 
            this.reporteIngresosPorCategoriaBindingSource.DataMember = "Reporte_IngresosPorCategoria";
            this.reporteIngresosPorCategoriaBindingSource.DataSource = this.mercado_Chavez_SanabriaDataSet6;
            // 
            // mercado_Chavez_SanabriaDataSet6
            // 
            this.mercado_Chavez_SanabriaDataSet6.DataSetName = "Mercado_Chavez_SanabriaDataSet6";
            this.mercado_Chavez_SanabriaDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetIngresosCategoriaLocal";
            reportDataSource1.Value = this.reporteIngresosPorCategoriaBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Mercadito_Chavez_Sanabria.IngresosCategoria.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 37);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(600, 329);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporte_IngresosPorCategoriaTableAdapter
            // 
            this.reporte_IngresosPorCategoriaTableAdapter.ClearBeforeFill = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Lime;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(211, 7);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(177, 25);
            this.btnRegresar.TabIndex = 48;
            this.btnRegresar.Text = "Regresar al Menu";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // reporteIngresosPorCategoriaBindingSource1
            // 
            this.reporteIngresosPorCategoriaBindingSource1.DataMember = "Reporte_IngresosPorCategoria";
            this.reporteIngresosPorCategoriaBindingSource1.DataSource = this.mercado_Chavez_SanabriaDataSet6local;
            // 
            // reporte_IngresosPorCategoriaTableAdapter1
            // 
            this.reporte_IngresosPorCategoriaTableAdapter1.ClearBeforeFill = true;
            // 
            // IngresosCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IngresosCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngresosCategoria";
            this.Load += new System.EventHandler(this.IngresosCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mercado_Chavez_SanabriaDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteIngresosPorCategoriaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Mercado_Chavez_SanabriaDataSet6 mercado_Chavez_SanabriaDataSet6;
        private System.Windows.Forms.BindingSource reporteIngresosPorCategoriaBindingSource;
        private Mercado_Chavez_SanabriaDataSet6TableAdapters.Reporte_IngresosPorCategoriaTableAdapter reporte_IngresosPorCategoriaTableAdapter;
        private System.Windows.Forms.Button btnRegresar;
        private Mercado_Chavez_SanabriaDataSet6local mercado_Chavez_SanabriaDataSet6local;
        private System.Windows.Forms.BindingSource reporteIngresosPorCategoriaBindingSource1;
        private Mercado_Chavez_SanabriaDataSet6localTableAdapters.Reporte_IngresosPorCategoriaTableAdapter reporte_IngresosPorCategoriaTableAdapter1;
        private System.Windows.Forms.BindingSource reporteIngresosPorCategoriaBindingSource2;
    }
}