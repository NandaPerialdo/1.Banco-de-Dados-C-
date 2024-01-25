using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using MySql.Data;//novos imports p usar o my sql
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto.Digests;

namespace Cadastro
{
    class DAO
    {
        public MySqlConnection conexao;// conectar ao banco de dados
        public string dados;
        public string sql;
        public string resultado;
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=Pessoa;Uid=root;Password=");
            try// se a conexao for bem suceddisa trata excessoes
            {
                conexao.Open();//abrindo a conexao com o banco de dados
                Console.WriteLine("Conectado com sucesso");
            }
            catch (Exception erro)// se nao fo bem sucedida
            {
                Console.WriteLine("Algo deu errado! Verifique os dados de conexao!\n\n" + erro);
                conexao.Close();//frechar a conexao com o BD p poder realizar outras operaçoes
            }//fim do try catch
        }//fim do metodo DAO

        //metodo inserir

        public void Inserir(string nome, string telefone, string cidade, string endereco)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + cidade + "','" + endereco + "')";
                sql = "insert into pessoa(codigo, nome, telefone, cidade, endereco) values" + dados;

                MySqlCommand conn = new MySqlCommand(sql, conexao);// prepara a execuçao no banco
                resultado = "" + conn.ExecuteNonQuery();//ctrl + enter -> executando o comando no banco de dados, colocar as aspas transforma em texto
                Console.WriteLine(resultado + "Linha afetada");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro!!Algo deu errado\n\n\n" + erro);
            }

        }//fim do metodo inserir
    }//fim da classe
}//fim do projeto
