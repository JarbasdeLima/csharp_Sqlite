using csharp_Sqlite.Models;
using System;
using System.Data;
using System.Data.SQLite;

namespace csharp_Sqlite
{
    public class DalHelper
    {
        private static SQLiteConnection sqliteConnection;
        private static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=C:\\Program IBNFU\\Dados\\Cadastro.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }
        public static void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(@"C:\Program IBNFU\Dados\Cadastro.sqlite");
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Membro(Id int, Nome Varchar(50), Dt_Nascimento smalldatetime, Nm_pai varchar(50), Nm_mae varchar(50), Estado_civil varchar(50), Sexo char(1),Idade varchar(10), Profissao varchar(50), Endereco varchar(500), Numero varchar(10),Bairro varchar(200), Cidade varchar(200),Referencia varchar(200),Cep varchar(10),Telefone1 varchar(15), Telefone2 varchar(15),Dt_batismo varchar(10), Nm_igreja varchar(100),Nm_pastor varchar(50),Tempo_freq_Igreja_local varchar(20), Tp_cadastro varchar(50), Grupo varchar(50), Funcao varchar(50), Cargo varchar(50), Ativo char(1),Dt_alteracao varchar(10), Dt_inclusao varchar(10), Usuario varchar(50))";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void CriarTabelaEventoSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS Eventos(Id int, [Descrição] Varchar(50), [Data Evento] varchar(10)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMembro(bool pesq, string strId, string strNm)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            string sql = "SELECT Id as Matrícula, " +
                "upper(Nome) as Nome , " +
                "Dt_Nascimento as [Data Nascimento], " +
                "upper(Nm_pai) as [Nome Pai] , " +
                "upper(Nm_mae) as [Nome Mãe], " +
                "upper(Estado_civil) as [Estado Civil]," +
                "Sexo ," +
                "Idade , " +
                "upper(Profissao)  as Profissao , " +
                "upper(Endereco  ) as Endereco   , " +
                "upper(Numero    ) as Numero     ," +
                "upper(Bairro    ) as Bairro     ," +
                "upper(Cidade    ) as Cidade     ," +
                "upper(Referencia) as Referencia ," +
                "Cep," +
                "Telefone1, " +
                "Telefone2," +
                "Dt_batismo as [Data Batismo], " +
                "upper(Nm_igreja) as [Igreja de Batismo] ," +
                "upper(Nm_pastor) as [Pastor Batistério]," +
                "Tempo_freq_Igreja_local as [Tempo de Frêquencia], " +
                "upper(Tp_cadastro) as [Tipo de Cadastro] , " +
                "upper(Grupo) as Grupo , " +
                "upper(Funcao) as [Função] , " +
                "upper(Cargo)  as [Cargo]   ";
                   sql += " FROM Membro where 1=1 ";

            if(pesq == true)
            {
                if (strId != "")
                {
                    sql += " and  Id = '" + strId + "'";
                }
                if (strNm != "")
                {
                    sql += " and Nome like '%" + strNm + "%' order by 2";
                }
            }
            else
            {
                sql += " and Ativo = 'S' order by 2";
            }
            
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetQtdTpCadastro()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select count(1) as Total,Tp_cadastro from membro group by Tp_cadastro";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAniversariantes()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select upper(Nome) as Nome, substr(dt_Nascimento,0,6) ||'/'||strftime('%Y',Date()) as Data from membro   where substr(dt_Nascimento,4,2)= strftime('%m',Date()) order by 2;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetEventos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select data_evento as Data,upper(descricao) as Descrição from eventos_tb where substr(data_evento,4,2) >= substr(Date(),6,2) order by id;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetQtdNascimento()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "select count(1) as Total, Membro_local from RegistroNascimento_tb group by Membro_local;";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AddNascimento(clsRegistros reg)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "insert into RegistroNascimento_tb (ID, Data_apresentacao,Nm_pai, Nm_mae,Membro_local,dt_inclusao,dt_Alteracao,nm_crianca,Nm_pastor,Dt_nascimento) VALUES ((select max(id)+1 from RegistroNascimento_tb),'" +
                        reg.dtapresentacao + "','" +
                        reg.Nomepai + "','" +
                        reg.Nomemae + "','" +
                        reg.membrolocal + "'," +
                        "Date(), Null, '" +
                        reg.Nomecrianca + "','" +
                        reg.Nomepastor + "','" +
                        reg.dtnascimento + "');";
                        

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void Add(Membro cliente)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Membro(Id , Nome , Dt_Nascimento, Nm_pai , Nm_mae, Estado_civil , Sexo ,Idade , Profissao , Endereco , Numero ,Bairro ,Cidade ,Referencia ,Cep,Telefone1, Telefone2,Dt_batismo , Nm_igreja ,Nm_pastor,Tempo_freq_Igreja_local, Tp_cadastro , Grupo , Funcao, Cargo, Ativo, Dt_alteracao, Dt_inclusao,Usuario) " +
                        "values ('" + cliente.Id + "', " +
                                "'" + cliente.Nome + "', " +
                                "'" + cliente.datanascimento + "', " +
                                "'" + cliente.nmpai + "', " +
                                "'" + cliente.nmmae + "', " +
                                "'" + cliente.estadocivil + "', " +
                                "'" + cliente.sexo + "', " +
                                "'" + cliente.idade + "', " +
                                "'" + cliente.profissao + "', " +
                                "'" + cliente.endereco + "', " +
                                "'" + cliente.numero + "', " +
                                "'" + cliente.bairro + "', " +
                                "'" + cliente.cidade + "', " +
                                "'" + cliente.referencia + "', " +
                                "'" + cliente.cep + "', " +
                                "'" + cliente.telefone1 + "', " +
                                "'" + cliente.telefone2 + "', " +
                                "'" + cliente.databatismo + "', " +
                                "'" + cliente.nmigreja + "', " +
                                "'" + cliente.nmpastor + "', " +
                                "'" + cliente.tempofrequencia + "', " +
                                "'" + cliente.tpcadastro + "', " +
                                "'" + cliente.grupo + "', " +
                                "'" + cliente.funcao + "', " +
                                "'" + cliente.cargo + "', " +
                                "'" + cliente.status + "', " +
                                " Date(), " +
                                "'', " +
                                "'Sistema')";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Membro cliente)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (cliente.Id != null )
                    {
                        cmd.CommandText = "UPDATE Membro SET Nome                    = '" + cliente.Nome           +"'" + 
                                                          ", Dt_Nascimento           = '" + cliente.datanascimento +"'" + 
                                                          ", Nm_pai                  = '" + cliente.nmpai          +"'" + 
                                                          ", Nm_mae                  = '" + cliente.nmmae          +"'" + 
                                                          ", Estado_civil            = '" + cliente.estadocivil    +"'" + 
                                                          ", Sexo                    = '" + cliente.sexo           +"'" + 
                                                          ", Idade                   = '" + cliente.idade          +"'" + 
                                                          ", Profissao               = '" + cliente.profissao      +"'" + 
                                                          ", Endereco                = '" + cliente.endereco       +"'" + 
                                                          ", Numero                  = '" + cliente.numero         +"'" + 
                                                          ", Bairro                  = '" + cliente.bairro         +"'" + 
                                                          ", Cidade                  = '" + cliente.cidade         +"'" + 
                                                          ", Referencia              = '" + cliente.referencia     +"'" + 
                                                          ", Cep                     = '" + cliente.cep            +"'" + 
                                                          ", Telefone1               = '" + cliente.telefone1      +"'" + 
                                                          ", Telefone2               = '" + cliente.telefone2      +"'" + 
                                                          ", Dt_batismo              = '" + cliente.databatismo    +"'" + 
                                                          ", Nm_igreja               = '" + cliente.nmigreja       +"'" + 
                                                          ", Nm_pastor               = '" + cliente.nmpastor       +"'" + 
                                                          ", Tempo_freq_Igreja_local = '" + cliente.tempofrequencia+"'" + 
                                                          ", Tp_cadastro             = '" + cliente.tpcadastro +"'" + 
                                                          ", Grupo                   = '" + cliente.grupo          +"'" +
                                                          ", Funcao                  = '" + cliente.funcao         +"'" +
                                                          ", Cargo                   = '" + cliente.cargo         + "'" +
                                                          ", Dt_inclusao             = Date()" +
                                                          ", Dt_alteracao            = ''    " +
                                                          ", Usuario                 = ''    " +
                                                          " WHERE Id                 =  " + cliente.Id +" ;";
                       
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int Id, string tp)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "update Membro set Ativo = '"+ tp + "' Where Id= '" + Id + "'";
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetRelatorio(string tp, string dt_ini, string dt_fim)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            string sql = "";
            string sqlaux = "";
            string dtini = dt_ini.Substring(1,4) + dt_ini.Substring(4, 2)  + dt_ini.Substring(1, 4);

            //string dtfim = String.Format(@"YYYY-MM-DD", dt_fim);


            if ((dt_ini != "" && dt_ini != "  /  /") && (dt_fim != "" && dt_fim != "  /  /"))
            {
                dt_ini = dt_ini.Substring(6,4) +'-'+ dt_ini.Substring(3,2) + '-' + dt_ini.Substring(0, 2);
                dt_fim = dt_fim.Substring(6, 4) + '-' + dt_fim.Substring(3, 2) + '-' + dt_fim.Substring(0, 2);

                sqlaux += " and dt_inclusao between '" + dt_ini + "' and '" + dt_fim + "'";
            }else
            if (dt_ini != "" && dt_ini != "  /  /")
            {
                dt_ini = dt_ini.Substring(6, 4) + '-' + dt_ini.Substring(3, 2) + '-' + dt_ini.Substring(0, 2);

                sqlaux += " and dt_inclusao >= '" + dt_ini + "'";
            }else if(dt_fim != "" && dt_fim != "  /  /")
            {
                dt_fim = dt_fim.Substring(6, 4) + '-' + dt_fim.Substring(3, 2) + '-' + dt_fim.Substring(0, 2);

                sqlaux += " and dt_inclusao <= '" + dt_fim + "'";
            }
            else
            {
                sqlaux = "Order by 2;";
            }


            if (tp == "Membro")
            {
                sql = "SELECT Id as Matrícula, upper(Nome) as Nome, Dt_Nascimento, upper(Nm_pai) as Nm_pai, upper(Nm_mae) as Nm_mae, Estado_civil , Sexo ,Idade , upper(Profissao) as Profissao, upper(Endereco) as Endereco , Numero ,upper(Bairro) as Bairro ,upper(Cidade) as Cidade ,Referencia ,Cep,Telefone1, Telefone2,Dt_batismo , upper(Nm_igreja) as Nm_igreja ,upper(Nm_pastor) as Nm_pastor,Tempo_freq_Igreja_local, upper(Tp_cadastro) as Tp_cadastro , upper(Grupo) as Grupo , upper(Funcao) as Funcao, upper(Cargo) as Cargo, Dt_inclusao";
                sql += " FROM Membro where 1=1 and Ativo = 'S' " + sqlaux;
            }
            else  
            if (tp == "Rg_Nascimento"){
                sql = "Select * from RegistroNascimento_tb where 1=1 " + sqlaux;

            }
            else if (tp == "Rg_Casamento")
            {
                sql = "Select * from rg_casamento_tb where 1=1 " + sqlaux;
            }
            else
            {
                sql = "";
            }


            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCombos(string Tp)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            string sql = "";
            // Grupo / Funcao/Sexo/ Tp_cadastro
            if (Tp != "")
            {

                if (Tp == "Grupo")
                {
                    sql = "select 'Todos' as Grupo union all Select Grupo from Membro group by Grupo;";
                }
                if (Tp == "Funcao")
                {
                    sql = " select 'Todos' as Funcao union all  Select case when Funcao = '' then 'Todos' else Funcao end as Funcao from Membro group by Funcao;";
                }
                if (Tp == "Sexo")
                {
                    sql = " select 'Todos' as Sexo union all  Select case when Sexo = 'F' then 'Feminino' when sexo = 'M' then 'Masculino' else Sexo end as Sexo from Membro group by Sexo;";
                }
                if (Tp == "Cargo")
                {
                    sql = " select 'Todos' as Cargo union all  Select Cargo from Membro where Cargo not in ('') group by Cargo;";
                }
                if (Tp == "TpCadastro")
                {
                    sql = " select 'Todos' as Tp_Cadastro union all  Select Tp_Cadastro from Membro where Tp_Cadastro not in ('') group by Tp_Cadastro;";
                }
                if (Tp == "Estadocivil")
                {
                    sql = " select 'Todos' as Estado_civil union all  Select Estado_civil from Membro where Estado_civil not in ('') group by Estado_civil;";
                }
            }
            else
            {
                sql = "Select ''";
            }
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDadosFiltro(CarregaDadosBD bd)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            string sql = "SELECT Id as Matrícula, " +
                "upper (Nome) as Nome , " +
                "Dt_Nascimento as [Data Nascimento]," +
                "upper(Nm_pai) as [Nome Pai] , " +
                "upper(Nm_mae) as [Nome Mãe], " +
                "upper(Estado_civil) as [Estado Civil] , " +
                "upper(Sexo) as Sexo ," +
                "Idade , " +
                "upper(Profissao) as [Profissão]," +
                "upper(Endereco) as [Endereço]  ," +
                "upper(Numero    ) as [Número]  ," +
                "upper(Bairro    ) as [Bairro]  ," +
                "upper(Cidade    ) as [Cidade]  ," +
                "upper(Referencia) as [Referência] ," +
                "Cep as [CEP]," +
                "Telefone1 as [Telefone 1], " +
                "Telefone2 as [Telefone 2]," +
                "Dt_batismo as [Data Batismo], " +
                "upper(Nm_igreja) as [Igreja Batistério] ," +
                "upper(Nm_pastor) as [Pastor Batistério]," +
                "Tempo_freq_Igreja_local as [Tempo de Frequência], " +
                "upper(Tp_cadastro) as [Tipo Cadastro] , " +
                "upper(Grupo  ) as [Grupo], " +
                "upper(Funcao ) as [Função], " +
                "upper(Cargo  ) as [Cargo]";
            sql += " FROM Membro where 1=1 ";

            if (bd.Cargo != "" && bd.Cargo != "Todos" && bd.Cargo != null)
            {
                sql += " and Cargo = '" + bd.Cargo + "' ";
            }
            if (bd.Grupo != "" && bd.Grupo != "Todos" && bd.Grupo != null)
            {
                sql += " and Grupo = '" + bd.Grupo + "' ";
            }
            if (bd.Funcao != "" && bd.Funcao != "Todos" && bd.Funcao != null)
            {
                sql += " and Funcao = '" + bd.Funcao + "' ";
            }
            if (bd.Sexo != "" && bd.Sexo != "Todos" && bd.Sexo != null)
            {
                if(bd.Sexo == "Feminino")
                {
                    sql += " and Sexo = 'F' ";
                }
                else
                {
                    sql += " and Sexo = 'M' ";
                }

            }
            if (bd.TpCadastro != "" && bd.TpCadastro != "Todos" && bd.TpCadastro != null)
            {
                sql += " and Tp_Cadastro = '" + bd.TpCadastro + "' ";
            }
            if (bd.EstadoCivil != "" && bd.EstadoCivil != "Todos" && bd.EstadoCivil != null)
            {
            //    if (bd.EstadoCivil == "Solteiro(a)")
            //    {
            //        sql += " and Estado_civil in ('Solteiro(a)'";
            //    }else
            //    if (bd.EstadoCivil == "Casado(a)")
            //    {
            //        sql += " and Estado_civil in ('Casado(a)')";
            //    }
            //    else
            //    if (bd.EstadoCivil == "Viúvo(a)")
            //    {
            //        sql += " and Estado_civil in ('Viúvo(a)') ";
            //    }
            //    else
            //    if (bd.EstadoCivil == "Separado(a)")
            //    {
            //        sql += " and Estado_civil in ('Separado(a)') ";
            //    }
            //else
            //    {
                    sql += " and Estado_civil = '" + bd.EstadoCivil + "' ";
             //   }
            }

            sql += "Order by 2";

            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = sql;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
