using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "";

            if(char.TryParse(operador, out char aux))
            {
                if (aux == '+' || aux == '-' || aux == '*' || aux == '/')
                {
                    retorno = aux.ToString();
                }
                else
                {
                    retorno = "+";
                }
            }
            else
            {
                Console.WriteLine("Error al validar operador.");
                Console.ReadKey();
            }
            return retorno;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = double.MinValue;            

            if(!object.ReferenceEquals(num1, null) && !object.ReferenceEquals(num2, null))
            {                                
                switch (char.Parse(Calculadora.ValidarOperador(operador)))
                {
                    case '+':
                        retorno = num1 + num2;
                        break;
                    case '-':
                        retorno = num1 - num2;
                        break;
                    case '/':
                        retorno = num1 / num2;
                        break;
                    case '*':
                        retorno = num1 * num2;
                        break;
                }
            }
            return retorno;
        }
    }
}
