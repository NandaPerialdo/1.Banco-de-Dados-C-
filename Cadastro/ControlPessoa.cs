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
        public int codigo;
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
                              "3.Consultar individual\n" +
                              "4.Atualizar\n" +
                              "5.Excluir\n" +
                              "6.Sair");
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
                        ConsultarTudo();
                        break;
                    case 3:
                        ConsultarIndividual();
                        break;
                    case 4:
                        MenuAtualizar();
                        break;
                    case 5:
                        Deletar();
                        break;
                    case 6:
                        Console.WriteLine("Obrigado");
                        break;
                    default://o default é o caso onde o usuario insere um caso que nao existe
                        Console.WriteLine("informe um codigo valido");
                        break;
                }//fim do escolha caso
            } while (ConsultarOpcao != 6);
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

        public void ConsultarTudo()
        {
            Console.WriteLine(conectar.ConsultarTudo());
        }//fim do consultar tudo

        public void ConsultarIndividual()
        {
            Console.WriteLine("Informe o codigo que deseja consultar: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            //mostrar na tela
            Console.WriteLine(conectar.ConsultarTudo(codigo));
        }//fim do consultar

        public void MostrarMenuAtualizar()
        {
            Console.WriteLine("Escolha uma das opcoes abaixo: " +
                "\n1.Nome " +
                "\n2.Telefone " +
                "\n3.Cidade " +
                "\n3.Endereço ");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//fim do metodo

        public void MenuAtualizar()
        {
            MostrarMenuAtualizar();
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Informe o codigo  do dado que deseja atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo nome: ");
                    string nome = Console .ReadLine();
                    //metodo que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "nome", nome));
                    break;
                case 2:
                    Console.WriteLine("Informe o codigo  do dado que deseja atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo telefone: ");
                    string telefone = Console.ReadLine();
                    //metodo que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "telefone", telefone));
                    break;
                case 3:
                    Console.WriteLine("Informe o codigo  do dado que deseja atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe a nova cidade: ");
                    string cidade = Console.ReadLine();
                    //metodo que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "cidade", cidade));
                    break;
                case 4:
                    Console.WriteLine("Informe o codigo  do dado que deseja atualizar");
                    codigo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Informe o novo endereco: ");
                    string endereco = Console.ReadLine();
                    //metodo que deseja atualizar
                    Console.WriteLine("\n\n" + conectar.Atualizar(codigo, "endereco", endereco));
                    break;
                default:
                    Console.WriteLine("Opcao escolhinda nao é valida");
                    break;
            }//fim do escolha
        }//fim do metodo

        public void Deletar()
        {
            Console.WriteLine("Informe um codigo: ");
            codigo = Convert.ToInt32(Console.ReadLine());
            //utilizar o metodo excluir
            Console.WriteLine("\n\n" + conectar.Excluir(codigo));
        }//fim do metodo

    }//fim da classe
}//fim do projeto
