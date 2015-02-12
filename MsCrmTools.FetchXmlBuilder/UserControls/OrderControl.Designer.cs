﻿namespace MsCrmTools.FetchXmlBuilder.UserControls
{
    partial class OrderControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAttribute = new System.Windows.Forms.TextBox();
            this.cbbOrder = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtAttribute
            // 
            this.txtAttribute.Location = new System.Drawing.Point(244, 46);
            this.txtAttribute.Name = "txtAttribute";
            this.txtAttribute.Size = new System.Drawing.Size(100, 20);
            this.txtAttribute.TabIndex = 0;
            // 
            // cbbOrder
            // 
            this.cbbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOrder.FormattingEnabled = true;
            this.cbbOrder.Items.AddRange(new object[] {
            "ascending",
            "descending"});
            this.cbbOrder.Location = new System.Drawing.Point(244, 72);
            this.cbbOrder.Name = "cbbOrder";
            this.cbbOrder.Size = new System.Drawing.Size(121, 21);
            this.cbbOrder.TabIndex = 1;
            // 
            // OrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbbOrder);
            this.Controls.Add(this.txtAttribute);
            this.Name = "OrderControl";
            this.Size = new System.Drawing.Size(559, 398);
            this.Load += new System.EventHandler(this.OrderControlLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAttribute;
        private System.Windows.Forms.ComboBox cbbOrder;
    }
}