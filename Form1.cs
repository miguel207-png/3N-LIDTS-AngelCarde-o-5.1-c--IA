using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3N_LIDTS_AngelCardeño_5._1_c__IA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Conecta los botones con sus métodos.
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }
        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor.Trim(), @"^[\p{L}\s]+$");
        }

        private bool EsTelefonoValido(string valor)
        {
            return Regex.IsMatch(valor.Trim(), @"^\d{10}$");
        }

        private bool EsEdadValida(string valor)
        {
            return int.TryParse(valor, out int edad) && edad > 0 && edad <= 120;
        }

        private bool EsEstaturaValida(string valor)
        {
            // Acepta punto o coma como separador decimal.
            valor = valor.Trim().Replace(',', '.');

            return decimal.TryParse(
                valor,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal estatura
            ) && estatura > 0 && estatura < 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text.Trim();
            string apellido = tbApellidos.Text.Trim();
            string telefono = tbTelefono.Text.Trim();
            string edad = tbEdad.Text.Trim();
            string estatura = tbEstatura.Text.Trim();

            if (!EsTextoValido(nombre))
            {
                MessageBox.Show("Escribe un nombre válido.", "Revisa el nombre",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombre.Focus();
                return;
            }

            if (!EsTextoValido(apellido))
            {
                MessageBox.Show("Escribe un apellido válido.", "Revisa el apellido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbApellidos.Focus();
                return;
            }

            if (!EsTelefonoValido(telefono))
            {
                MessageBox.Show("El teléfono debe contener exactamente 10 dígitos.",
                    "Revisa el teléfono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTelefono.Focus();
                return;
            }

            if (!EsEdadValida(edad))
            {
                MessageBox.Show("Escribe una edad válida entre 1 y 120.",
                    "Revisa la edad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEdad.Focus();
                return;
            }

            if (!EsEstaturaValida(estatura))
            {
                MessageBox.Show("Escribe una estatura válida en metros, por ejemplo 1.62.",
                    "Revisa la estatura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEstatura.Focus();
                return;
            }

            string genero = rbFemenino.Checked ? "Femenino"
                          : rbMasculino.Checked ? "Masculino"
                          : rbOtros.Checked ? "Otro"
                          : "Sin especificar";

            string mensaje =
                $"Nombre: {nombre}\n" +
                $"Apellido: {apellido}\n" +
                $"Teléfono: {telefono}\n" +
                $"Edad: {edad}\n" +
                $"Estatura: {estatura}\n" +
                $"Género: {genero}";

            MessageBox.Show(mensaje, "Confirmación de registro",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbTelefono.Clear();
            tbEdad.Clear();
            tbEstatura.Clear();

            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            rbOtros.Checked = false;

            tbNombre.Focus();
        }
    }
}
