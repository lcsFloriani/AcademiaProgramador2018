﻿using Banco.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.WindowsApp.Features.ClienteModule
{
    public partial class CadastroClienteDialog : Form
    {
        public CadastroClienteDialog()
        {
            InitializeComponent();
        }
        public Cliente NovoCliente
        {
            get
            {
                var cliente = new Cliente();
                cliente.Nome = txtNome.Text;
                cliente.Email = txtemail.Text;
                return cliente;
            }
        }

    }
}
