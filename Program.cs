﻿using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();
           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                      ListarSerie();
                       break;
                    case "2":
                      InserirSerie();
                       break;
                    case "3":
                     // AtualizarSerie();
                       break;
                    case "4":
                      //ExcluirSerie();
                       break;
                    case "5":
                      //VisualizarSerie();
                       break;   
                    case "C":
                      Console.Clear();
                       break;   

                   default:
                       throw new ArgumentOutOfRangeException();
               }
               
               opcaoUsuario = ObterOpcaoUsuario();
           }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
            
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries, Seja bem vindo!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;  

        }
    }


}
