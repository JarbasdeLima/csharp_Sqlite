using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_Sqlite.Models
{
    public class Membro
    {
        public long?  Id                { get; set; }
        public string Nome              { get; set; }
        public string datanascimento    { get; set; }
        public string nmpai             { get; set; }
        public string nmmae             { get; set; }
        public string estadocivil       { get; set; }
        public string idade             { get; set; }
        public string profissao         { get; set; }
        public string endereco          { get; set; }
        public string numero            { get; set; }
        public string bairro            { get; set; }
        public string cidade            { get; set; }
        public string referencia        { get; set; }
        public string cep               { get; set; }
        public string telefone1         { get; set; }
        public string telefone2         { get; set; }
        public string databatismo       { get; set; }
        public string nmigreja          { get; set; }
        public string nmpastor          { get; set; }
        public string tempofrequencia   { get; set; }
        public string cargo             { get; set; }
        public string funcao            { get; set; }
        public string grupo             { get; set; }
        public string sexo              { get; set; }
        public string tpcadastro        { get; set; }
        public string status { get; set; } = "S";
        public string log               { get; set; }
        public static string nm;
    }
}
