using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] cidade;
        public string[] endereco;
        public int i;
        public int contador;
        public string msg;
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

        //metodo consultar// precisa usar vetores para nao o programa nao precisar acessar o bd muitas vezes
        public void PreencherVetor()
        {
            string query = "select * from pessoa";

            //instanciar valores
            codigo = new int[100];
            nome = new string[100];
            telefone = new string[100];
            cidade = new string[100];
            endereco = new string[100];

            //preencher com valores genericos
            for(i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                cidade[i] = "";
                endereco[i] = "";
            }//fim do for

            //prepaprando o comando para o banco
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;

            while(leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = "" + leitura["nome"];
                telefone[i] = "" + leitura["telefone"];
                cidade[i] = "" + leitura["cidade"];
                endereco[i] = "" + leitura["endereco"];
                i++;
                contador++;
            }//preenchendo o vetor com os dados do banco

            leitura.Close();//encerrar o acesso ao banco de dados
        }//fim do preencher

        //metodo para consultar TODOS os dados do banco de dados
        public string ConsultarTudo()
        {
            //preencher o vetor
            PreencherVetor();
            msg = "";
            for(i=0; i < contador; i++)
            {
                msg += "\n\nCódigo: " + codigo[i] +
                        " , Nome: " + nome[i] +
                        " ,Telefone: " + telefone[i] +
                        " ,Cidade: " + cidade[i] +
                        " ,Endereço: " + endereco[i];
            }//fim do for

            return msg;//mostrar em tela o resultado da consulta
        }//fim do metodo consultar tudo

        public string ConsultarTudo(int cod)
        {
            PreencherVetor();

            for(i=0; i < contador; i++)
            {
                if (codigo[i] == cod)
                {
                    msg = "\n\nCódigo: " + codigo[i] +
                        ", Nome: " + nome[i] +
                        ", Telefone: " + telefone[i] +
                        ", Cidade: " + cidade[i] +
                        ", Endereço: " + endereco[i];
                    return msg;
                }//fim do if
            }//fim do for
            return "Código informado não encontrado!";
        }//fim do metodo

        public string Atualizar(int cod, string campo, string dado)
        {
            try
            {
                string query = "update pessoa set " + campo + " = '" + dado + "' where codigo = '" + cod + "'";
            //preparar o comando do bd
            MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + "linha afetada";
            }catch(Exception erro)
            {
                return "Algo deu errado\n\n" + erro;
            }
        }//fim do metodo

        public string Excluir(int cod)
        {
            string query = "delete from pessoa where codigo = ' " + cod + "'";
            //preparar o comando
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = "" + sql.ExecuteNonQuery();
            //mostrar resultado
            return resultado + " Linha Afetada";
        }//fim do metodo

    }//fim da classe
}//fim do projeto
