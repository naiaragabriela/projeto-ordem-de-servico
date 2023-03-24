
using System;
using System.ComponentModel.Design;
using System.Globalization;

namespace ManipulacaoListas
{
    public class Program
    {
        private void Main(string[] args)
        {
            List<OrdemServico> orcamento = new List<OrdemServico>();
            List<string> pecas = new List<string>();

            int opc = Menu();
            CarregarDados(orcamento);
            do
            {
                opc = Menu();
                switch (opc)
                {
                    case 0:
                        GravarOrcamentos(orcamento);
                        GravarPecas(pecas);
                        break;
                    case 1:
                        orcamento.Add(CadastrarOrcamento(pecas));
                        break;
                    case 2:
                        ImprimirOrcamentos(orcamento);
                        break;
                }
            } while (opc != 0);
        }
        private static int Menu()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Criar novo orçamento");
            Console.WriteLine("2- Mostrar Orçamento");
            Console.WriteLine("0- Sair");

            int opc = int.Parse(Console.ReadLine());
            return opc;
        }

        private static OrdemServico CadastrarOrcamento(List<string>pecas)
        {
            Console.WriteLine("Criando novo Orçamento ");
            Console.WriteLine("Informe o numero da OS");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a descricao da OS");
            string description = Console.ReadLine();
            char c = '\0';
            do
            {
                Console.WriteLine("Informe a peça a ser usada");
                string p = Console.ReadLine();
                pecas.Add(p);
                Console.WriteLine("Deseja incluir outra peça?");
                c = char.Parse(Console.ReadLine());
            } while (c!= 'n');

            Console.WriteLine("Informe o valor da OS");
            double value = double.Parse(Console.ReadLine());

            return new OrdemServico(id, description, value, pecas);
        }

        public void ImprimirOrcamentos(List<OrdemServico> orcamento)
        {
            Console.WriteLine("Os orçamentos que estão aguardando autorização são: ");
            for (int i = 0; i < orcamento.Count; i++)
            {
                Console.WriteLine(orcamento[i].ToUser());
            }

        }

        private static void GravarOrcamentos(List<OrdemServico> orcamento)
        {
            string arquivo = @"orcamentos.csv";
            StreamWriter sw = new StreamWriter(arquivo);
            for (int i = 0; i < orcamento.Count; i++)
            {
                sw.WriteLine(orcamento[i].ToString());
            }
            sw.Close();


        }
        void CarregarDados(List<OrdemServico> orcamento)
        {
            string arquivo = @"orcamento.csv";
            StreamReader sr = new StreamReader(arquivo);
            do
            {
                List<string> pecas = sr.ReadLine().Split(";").ToList();
                int id = int.Parse(pecas[0]);
                string description = pecas[1];
                double value = double.Parse(pecas[2]);

                orcamento.Add(new OrdemServico(id, description, value, pecas));

            } while (!sr.EndOfStream);
            sr.Close();
        }

        void GravarPecas(List<string> pecas, List<OrdemServico> orcamento)
        {
            string arquivo = @"pecas.csv";
            StreamWriter sw = new StreamWriter(arquivo);

            for (int i = 0; i < pecas.Count; i++)
            {
                sw.WriteLine(orcamento[i].ID + ";" + pecas[i].ToString());
            }
            sw.Close();

        }
    }

}
