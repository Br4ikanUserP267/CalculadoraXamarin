using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void operadores_clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            principal.Text += button.Text;

            string operacion = principal.Text;

            // Remover espacios en blanco de la operación
            operacion = operacion.Replace(" ", "");

            // Obtener los números y los operadores de la operación
            List<double> numeros = new List<double>();
            List<char> operadores = new List<char>();

            string[] elementos = operacion.Split('+', '-', '÷', 'x','%');
            foreach (string elemento in elementos)
            {
                double numero;
                if (double.TryParse(elemento, out numero))
                {
                    numeros.Add(numero);
                }
            }

            foreach (char caracter in operacion)
            {
                if (caracter == '+' || caracter == '÷' || caracter == '-'  || caracter == '%' || caracter == 'x')
                {
                    operadores.Add(caracter);
                }
            }

            // Realizar la operación
            double resultado = numeros[0];

            for (int i = 0; i < operadores.Count; i++)
            {
                if (numeros.Count < i + 2)
                {
                    // Mostrar mensaje de error y salir del ciclo
                    resultadoParcial.Text = " ";
                    return;
                }

                if (operadores[i] == '+')
                {
                    resultado += numeros[i + 1];
                }
                else if (operadores[i] == '-')
                {
                    resultado -= numeros[i + 1];
                }
                else if (operadores[i] == '÷')
                {
                    resultado /= numeros[i + 1];
                }
                else if (operadores[i] == 'x')
                {
                    resultado *= numeros[i + 1];
                }
                else if (operadores[i] == '%')
                {
                    resultado *= numeros[i+1] / 100.0;
                }
            }
            // Mostrar el resultado
            resultadoParcial.Text = resultado.ToString();
           
        }


        private void borrar_Clicked(object sender, EventArgs e)
        {
         

            string operacion = principal.Text;

            // Remover espacios en blanco de la operación
            operacion = operacion.Replace(" ", "");

            // Obtener los números y los operadores de la operación
            List<double> numeros = new List<double>();
            List<char> operadores = new List<char>();

            if (principal.Text.Length > 0)
            {
                principal.Text = principal.Text.Remove(principal.Text.Length - 1);
            }
            else if (principal.Text.Length == 0)
            {
                // Borra todos los elementos del label
                principal.Text = "";
                resultadoParcial.Text = "";
                numeros.Clear();
                operadores.Clear();
                return;
            }

            string[] elementos = operacion.Split('+', '-', '÷', 'x', '%');
            foreach (string elemento in elementos)
            {
                double numero;
                if (double.TryParse(elemento, out numero))
                {
                    numeros.Add(numero);
                }
            }

            foreach (char caracter in operacion)
            {
                if (caracter == '+' || caracter == '÷' || caracter == '-' || caracter == '%' || caracter == 'x')
                {
                    operadores.Add(caracter);
                }
            }

            // Realizar la operación
            double resultado = numeros[0];

            for (int i = 0; i < operadores.Count; i++)
            {
                if (numeros.Count < i + 2)
                {
                    // Mostrar mensaje de error y salir del ciclo
                    resultadoParcial.Text = " ";
                    return;
                }

                if (operadores[i] == '+')
                {
                    resultado += numeros[i + 1];
                }
                else if (operadores[i] == '-')
                {
                    resultado -= numeros[i + 1];
                }
                else if (operadores[i] == '÷')
                {
                    resultado /= numeros[i + 1];
                }
                else if (operadores[i] == 'x')
                {
                    resultado *= numeros[i + 1];
                }
                else if (operadores[i] == '%')
                {
                    resultado *= numeros[i + 1] / 100.0;
                }
            }
            // Mostrar el resultado
            resultadoParcial.Text = resultado.ToString();


            if (principal.Text =="")
            {
                resultadoParcial.Text = string.Empty;
            }

           

        }
        private void limpiar_Clicked(object sender, EventArgs e)
        {
            resultadoParcial.Text = string.Empty;
            principal.Text = string.Empty;


        }
        private void igual_Clicked(object sender, EventArgs e)
        {
           
            string operacion = principal.Text;

            // Remover espacios en blanco de la operación
            operacion = operacion.Replace(" ", "");

            // Obtener los números y los operadores de la operación
            List<double> numeros = new List<double>();
            List<char> operadores = new List<char>();

            string[] elementos = operacion.Split('+', '-', '÷', 'x', '%');
            foreach (string elemento in elementos)
            {
                double numero;
                if (double.TryParse(elemento, out numero))
                {
                    numeros.Add(numero);
                }
            }

            foreach (char caracter in operacion)
            {
                if (caracter == '+' || caracter == '÷' || caracter == '-' || caracter == 'x' || caracter == '%' )
                {
                    operadores.Add(caracter);
                }
            }

            // Realizar la operación
            double resultado = numeros[0];

            for (int i = 0; i < operadores.Count; i++)
            {
                if (numeros.Count < i + 2)
                {
                    // Mostrar mensaje de error y salir del ciclo
                    resultadoParcial.Text = "Error: operación inválida";
                    return;
                }

                if (operadores[i] == '+')
                {
                    resultado += numeros[i + 1];
                }
                else if (operadores[i] == '-')
                {
                    resultado -= numeros[i + 1];
                }
                else if (operadores[i] == '÷')
                {
                    resultado /= numeros[i + 1];
                }
                else if (operadores[i] == 'x')
                {
                    resultado *= numeros[i + 1];
                }
                else if (operadores[i] == '%')
                {
                    resultado *= numeros[i+1] / 100.0;
                }
            }
            // Mostrar el resultado
            principal.Text = resultado.ToString();
            resultadoParcial.Text = string.Empty;
        }
       

    }
}
