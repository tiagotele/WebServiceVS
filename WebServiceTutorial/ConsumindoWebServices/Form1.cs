using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConsumindoWebServices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal valorA, valorB;
            localhost.OperacoesBasicas operacao = localhost.OperacoesBasicas.Adicao;
            decimal resultado;

            decimal.TryParse(textBox1.Text, out valorA);
            decimal.TryParse(textBox2.Text, out valorB);

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    operacao = localhost.OperacoesBasicas.Adicao;
                    break;
                case 1:
                    operacao = localhost.OperacoesBasicas.Divisao;
                    break;
                case 2:
                    operacao = localhost.OperacoesBasicas.Multiplicacao;
                    break;
                case 3:
                    operacao = localhost.OperacoesBasicas.Subtracao;
                    break;
            }

            localhost.Service MeuWebService = new localhost.Service();
            try
            {
                resultado = MeuWebService.Calculadora(valorA, valorB, operacao);
                textBox4.Text = resultado.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceção ao se realizar operação matemática"+ex.Message);
                textBox4.Text = "0";
            }
        }
    }
}
