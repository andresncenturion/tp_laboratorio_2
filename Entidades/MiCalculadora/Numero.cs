using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;        

        public Numero() 
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
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

        public static string DecimalBinario(double numero)
        {
            string binario = "";
            double resto = -1;

            while (numero >= 1)
            {
                resto = numero % 2;
                numero = Math.Truncate(numero/2);

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

        public static string DecimalBinario(string numero)
        {
            string retorno = "";
            Numero aux = new Numero();
            double validado = -1;

            validado = aux.ValidarNumero(numero);
            if (validado != 0)
            {
                retorno = DecimalBinario(validado);
            }
            else
            {
                Console.WriteLine("Valor invalido...");
                Console.Read();
            }
            return retorno;
        }

        public static string BinarioDecimal(string binario)
        {
            double retorno = 0;
            int j = binario.Length - 1;

            for (int i = 0; i < binario.Length; i++)
            {
                retorno += double.Parse(binario[j].ToString()) * Math.Pow(2, i);
                j--;
            }            

            return retorno.ToString();
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
