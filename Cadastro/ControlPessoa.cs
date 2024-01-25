using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class ControlPessoa
    {
        private int opcao;
        DAO conectar;
        public ControlPessoa()
        {
            //instanciar uma variavel= determinar o valor inicial
            ConsultarOpcao = 0; //instanciando o metodo consultar opcao em 0. esse metodo representa a variavel opcao. ela nao é usada diretamente por segurança
            conectar = new DAO();//conectando ao banco de dados
        }//fim do construtor

        public int ConsultarOpcao
        {
            get { return this.opcao; }
            set { this.opcao = value; }
        }//fim do metodo get set
        public void Menu()
        {
            Console.WriteLine("Escolha uma das opçoes abaixo: \n" +
                              "1.Cadastrar\n" +
                              "2.Consultar\n" +
                              "3.Atualizar\n" +
                              "4.Excluir\n" +
                              "5.Sair");
            ConsultarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do metodo menu

        public void Operacao()
        {
            do
            {
                Menu();//mostrar o menu para o usuario
                switch (ConsultarOpcao)//consultar opcao de acordo com o que esta dentro de ConsultaOpcao
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        //Consultar
                        break;
                    case 3:
                        //Atualizar
                        break;
                    case 4:
                        //excluir
                        break;
                    case 5:
                        Console.WriteLine("Obrigado");
                        break;
                    default://o default é o caso onde o usuario insere um caso que nao existe
                        Console.WriteLine("informe um codigo valido");
                        break;
                }//fim do escolha caso
            } while (ConsultarOpcao != 5);
        }
        public void Cadastrar()
        {
            Console.WriteLine("Informe o nome da pessoa: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe o numero da pessoa: ");
            string telefone = Console.ReadLine();
            Console.WriteLine("Informe a cidade da pessoa: ");
            string cidade = Console.ReadLine();
            Console.WriteLine("Informe o endereco da pessoa: ");
            string endereco = Console.ReadLine();
            //inserir no banco de dados
            conectar.Inserir(nome, telefone, cidade, endereco);
        }//fim do metodo cadastrar

    }//fim da classe
}//fim do projeto
