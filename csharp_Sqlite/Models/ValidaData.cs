using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_Sqlite.Models
{
    public class ValidaData
    {
        public static bool isDate(string data1, string data2)
        {
            DateTime atual = DateTime.Today;

            string dtaux = Convert.ToString(atual);
            int dtano = Convert.ToInt32(dtaux.Substring(6, 4)); // ano atual

            // Valida data de nascimento
            if (data1 != "")
            {
                int dia = Convert.ToInt32(data1.Substring(0, 2)); // dia
                int mes = Convert.ToInt32(data1.Substring(3, 2)); // mes
                int ano = Convert.ToInt32(data1.Substring(6, 4)); // ano

                if (mes > 12)
                {
                    return true;
                }
                if (dia > 30)
                {
                    if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                        return false;
                    else
                    {
                        return true;
                    }
                }

                    if (dia >= 30 && mes == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                if (ano > dtano)
                {
                    return true;
                }
            }
            // para validar data de batismo (desconsidera a validação do ano)
            if (data2 != "")
            {
                int dia = Convert.ToInt32(data2.Substring(0, 2)); // dia
                int mes = Convert.ToInt32(data2.Substring(3, 2)); // mes
                int ano = Convert.ToInt32(data2.Substring(6, 4)); // ano

                if (mes > 12)
                {
                    return true;
                }
                if (dia > 30)
                {
                    if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12)
                        return false;
                    else
                    {
                        return true;
                    }
                }

                if (dia >= 30 && mes == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

    }
}
