﻿using Projeto_NFe.Domain.Features.Invoices;
using Projeto_NFe.Domain.Features.ItemInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projeto_NFe.Domain.Features.Taxes
{
    public class Tax
    {

        [XmlIgnore]
        public Invoice invoice { get; set; }
        public double ValueFreight { get; set; }

        public double TotalIcmsValue
        {
            get
            {
                return CalculateICMS();
            }
        }

        public double TotalProductValue
        {
            get
            {
                return CalculateTotalProduct();
            }
        }

        public double TotalIpiValue
        {
            get
            {
                return CalculateIPI();
            }
        }

        public double TotalInvoice {
            get
            {
                return CalculateTotalInvoice();
            }
        }

        private double CalculateICMS()
        {
            double total = 0;
            foreach (ItemInvoice i in invoice.Items)
                total += i.ICMSValue;

            return total;
        }

        private double CalculateIPI()
        {
            double total = 0;
            foreach (ItemInvoice i in invoice.Items)
                total += i.IPIValue;
            return total;
        }

        private double CalculateTotalProduct()
        {
            double total = 0;
            foreach (ItemInvoice i in invoice.Items)
                total += i.TotalValue;
            return total;
        }

        private double CalculateTotalInvoice()
        {
            return TotalIcmsValue + ValueFreight + TotalIpiValue + TotalProductValue;
        }
    }
}
