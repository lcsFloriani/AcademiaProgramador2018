namespace Pizzaria.WinApp.Features.Pedidos
{
    partial class PedidoStatusDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxStatusPedido = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataPedidoEnviado = new System.Windows.Forms.TextBox();
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.btnSalvarStatus = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.lblAguardandoMontagem = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmMontagem = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAguardandoEntrega = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblEmEntrega = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblEntregue = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status do pedido:";
            // 
            // cbxStatusPedido
            // 
            this.cbxStatusPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStatusPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxStatusPedido.FormattingEnabled = true;
            this.cbxStatusPedido.Location = new System.Drawing.Point(120, 148);
            this.cbxStatusPedido.Name = "cbxStatusPedido";
            this.cbxStatusPedido.Size = new System.Drawing.Size(532, 23);
            this.cbxStatusPedido.TabIndex = 3;
            this.cbxStatusPedido.SelectedIndexChanged += new System.EventHandler(this.cbxStatusPedido_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pedido foi enviado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(313, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tempo que se decorreu:";
            // 
            // txtDataPedidoEnviado
            // 
            this.txtDataPedidoEnviado.Enabled = false;
            this.txtDataPedidoEnviado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataPedidoEnviado.ForeColor = System.Drawing.Color.Red;
            this.txtDataPedidoEnviado.Location = new System.Drawing.Point(129, 10);
            this.txtDataPedidoEnviado.Name = "txtDataPedidoEnviado";
            this.txtDataPedidoEnviado.Size = new System.Drawing.Size(178, 21);
            this.txtDataPedidoEnviado.TabIndex = 1;
            // 
            // txtTempo
            // 
            this.txtTempo.Enabled = false;
            this.txtTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempo.ForeColor = System.Drawing.Color.Red;
            this.txtTempo.Location = new System.Drawing.Point(482, 10);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(170, 21);
            this.txtTempo.TabIndex = 2;
            // 
            // btnSalvarStatus
            // 
            this.btnSalvarStatus.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarStatus.Location = new System.Drawing.Point(557, 422);
            this.btnSalvarStatus.Name = "btnSalvarStatus";
            this.btnSalvarStatus.Size = new System.Drawing.Size(105, 28);
            this.btnSalvarStatus.TabIndex = 5;
            this.btnSalvarStatus.Text = "Atualizar";
            this.btnSalvarStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 177);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(647, 239);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens do Pedido";
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(9, 19);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(628, 199);
            this.listBox.TabIndex = 4;
            // 
            // lblAguardandoMontagem
            // 
            this.lblAguardandoMontagem.AutoSize = true;
            this.lblAguardandoMontagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguardandoMontagem.ForeColor = System.Drawing.Color.Red;
            this.lblAguardandoMontagem.Location = new System.Drawing.Point(72, 50);
            this.lblAguardandoMontagem.Name = "lblAguardandoMontagem";
            this.lblAguardandoMontagem.Size = new System.Drawing.Size(64, 55);
            this.lblAguardandoMontagem.TabIndex = 9;
            this.lblAguardandoMontagem.Text = "🍕";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Em Aguardo de Montagem";
            // 
            // lblEmMontagem
            // 
            this.lblEmMontagem.AutoSize = true;
            this.lblEmMontagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmMontagem.ForeColor = System.Drawing.Color.Red;
            this.lblEmMontagem.Location = new System.Drawing.Point(197, 50);
            this.lblEmMontagem.Name = "lblEmMontagem";
            this.lblEmMontagem.Size = new System.Drawing.Size(64, 55);
            this.lblEmMontagem.TabIndex = 11;
            this.lblEmMontagem.Text = "🍕";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Em Montagem";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "___________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Aguardando Entrega";
            // 
            // lblAguardandoEntrega
            // 
            this.lblAguardandoEntrega.AutoSize = true;
            this.lblAguardandoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguardandoEntrega.ForeColor = System.Drawing.Color.Red;
            this.lblAguardandoEntrega.Location = new System.Drawing.Point(318, 50);
            this.lblAguardandoEntrega.Name = "lblAguardandoEntrega";
            this.lblAguardandoEntrega.Size = new System.Drawing.Size(64, 55);
            this.lblAguardandoEntrega.TabIndex = 15;
            this.lblAguardandoEntrega.Text = "🍕";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(251, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "___________";
            // 
            // lblEmEntrega
            // 
            this.lblEmEntrega.AutoSize = true;
            this.lblEmEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmEntrega.ForeColor = System.Drawing.Color.Red;
            this.lblEmEntrega.Location = new System.Drawing.Point(431, 50);
            this.lblEmEntrega.Name = "lblEmEntrega";
            this.lblEmEntrega.Size = new System.Drawing.Size(64, 55);
            this.lblEmEntrega.TabIndex = 17;
            this.lblEmEntrega.Text = "🍕";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(369, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "___________";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(423, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "Em Entrega";
            // 
            // lblEntregue
            // 
            this.lblEntregue.AutoSize = true;
            this.lblEntregue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregue.ForeColor = System.Drawing.Color.Red;
            this.lblEntregue.Location = new System.Drawing.Point(547, 50);
            this.lblEntregue.Name = "lblEntregue";
            this.lblEntregue.Size = new System.Drawing.Size(64, 55);
            this.lblEntregue.TabIndex = 21;
            this.lblEntregue.Text = "🍕";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(486, 67);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "___________";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(554, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Entregue";
            // 
            // PedidoStatusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 462);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblEntregue);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblEmEntrega);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblAguardandoEntrega);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblEmMontagem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblAguardandoMontagem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalvarStatus);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.txtDataPedidoEnviado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxStatusPedido);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PedidoStatusDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Andamento do Pedido";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxStatusPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataPedidoEnviado;
        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.Button btnSalvarStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label lblAguardandoMontagem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmMontagem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAguardandoEntrega;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblEmEntrega;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblEntregue;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
    }
}