using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        public Numero() 
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {

        }

        private double ValidarNumero(string strNumero)
        {
            double retorno;

            if (double.TryParse(strNumero, out double aux))
            {
                retorno = aux;
            }
            else
            {
                retorno = 0;
            }
            return retorno;
        }

        public string DecimalBinario(double numero)
        {
            string binario = "";
            double resto = -1;

            while (numero >= 1)
            {
                resto = numero % 2;
                numero /= 2;
                if (resto == 1)
                {
                    binario = "1" + binario;
                }
                else
                {
                    binario = "0" + binario;
                }
            }

            return binario;
        }

        public string DecimalBinario(string numero)
        {
            double retorno = 0;
            int j = 7;

            for (int i = 0; i < b.Length; i++)
            {
                retorno += double.Parse(b[j].ToString()) * Math.Pow(2, i);
                j--;
            }

            return retorno;
        }

        public static double operator - (Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if(!object.ReferenceEquals(n1, null) && !object.ReferenceEquals(n2, null))
            {
                retorno = n1.numero - n2.numero;
            }
            return retorno;
        }

        public static double operator + (Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if (!object.ReferenceEquals(n1, null) && !object.ReferenceEquals(n2, null))
            {
                retorno = n1.numero + n2.numero;
            }
            return retorno;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if(n2.numero != 0)
            {
                if (!object.ReferenceEquals(n1, null) && !object.ReferenceEquals(n2, null))
                {
                    retorno = n1.numero / n2.numero;
                }
            }
            else
            {
                Console.WriteLine("No es posible dividir por cero");
                Console.ReadKey();
            }
            return retorno;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if (!object.ReferenceEquals(n1, null) && !object.ReferenceEquals(n2, null))
            {
                retorno = n1.numero * n2.numero;
            }
            return retorno;
        }


    }
}
