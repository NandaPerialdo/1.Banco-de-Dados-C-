using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlPessoa pessoa = new ControlPessoa();//conectando a contro com a model
            pessoa.Operacao();
            Console.ReadLine();//manter o prompt aberto
        }//fim do metoto
    }//fim da classe
}//fim do projeto
