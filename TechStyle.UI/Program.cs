using System;
using System.Collections.Generic;
using TechStyle.dominio.Modelo;
using TechStyle.dominio.repositorio;

namespace TechStyle.UI
{
    class Program
    {
        public static SegmentoRepositorio repoSeg;
        static void Main(string[] args)
        {
            //MENU
            repoSeg = new SegmentoRepositorio();
            OpcoesMenu();
        }

        private static void OpcoesMenu()
        {
            Console.WriteLine("1- Cadastrar Segmento:");
            Console.WriteLine("2- Listar Segmentos:");
            Console.WriteLine("3- Alterar Segmento:");
            Console.WriteLine("Escolha a Operação:");

            Resposta();
        }

        private static void Resposta()
        {
            string resposta = Console.ReadLine();

            switch (resposta)
            {
                case "1":
                    CadastrarSegmento();
                    Console.WriteLine();
                    OpcoesMenu();
                    break;
                case "2":
                    ListarSegmentos();
                    Console.WriteLine();
                    OpcoesMenu();
                    break;
                case "3":
                    AlterarSegmento();
                    Console.WriteLine();
                    OpcoesMenu();
                    break;
                default:
                    Console.WriteLine("insira um valor válido");
                    OpcoesMenu();
                    break;
            }
        }

        private static void AlterarSegmento()
        {
            Console.WriteLine("Digite o Id: ");
            int idSegmento = int.Parse( Console.ReadLine());

            Console.WriteLine("Digite a categoria: ");
            string categoriaSegmento = Console.ReadLine();
            Console.WriteLine("Digite o subcategoria: ");
            string subcategoriaSegmento = Console.ReadLine();
            bool status = repoSeg.Alterar(idSegmento, categoriaSegmento, subcategoriaSegmento);
            if (status) Console.WriteLine("Segmento atualizado com sucesso!"); else Console.WriteLine("ocorreu um erro.");
        }

        private static void ListarSegmentos()
        {
            List<Segmento> listaDeSegmentos = repoSeg.BuscarTudo();
            foreach (var segmento in listaDeSegmentos)
            {
                Console.WriteLine($"{segmento.Id} - {segmento.Categoria} / {segmento.Subcategoria}");

            }
        }

        private static void CadastrarSegmento()
        {
            Console.WriteLine("Digite a categoria:");
            string categoria = Console.ReadLine();
            Console.WriteLine("Digite a subcategoria:");
            string subCategoria = Console.ReadLine();

            bool status = repoSeg.Incluir(categoria, subCategoria);
            if(status)
                Console.WriteLine("Segmento adicionado com sucesso!");
            else
                Console.WriteLine("Ocorreu um erro ao cadastrar segmento.");
        }
    }
}
