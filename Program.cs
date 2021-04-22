using System;

namespace PlaySeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();           

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();                        
                        break;
                    case "2":
                        InserirSerie();                        
                        break;
                    case "3":
                        AtualizaSerie();                        
                        break;
                    case "4":
                        ExcluirSerie();                        
                        break;
                    case "5":
                        VisualizarSerie();                        
                        break;
                    case "C":
                        Console.Clear();                        
                        break;                    

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }  
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var Serie in lista)
            {
                var excluido = Serie.retornaExcluido();
               
                Console.WriteLine("#ID {0}: - {1} {2}", Serie.RetornaId(), Serie.RetornaTitulo(), (excluido ? "*Excluido*" : ""));              
                
            }
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizaSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie,atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            string opcaoExclusao = ObterOpcaoExclusao();

            while (opcaoExclusao.ToUpper() != "S" || opcaoExclusao.ToUpper() != "N")
            {

                if(opcaoExclusao == "S")
                {
                    repositorio.Exclui(indiceSerie);
                    return;
                }
                else if (opcaoExclusao == "N")
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Opção Invalida: ");
                    opcaoExclusao = ObterOpcaoExclusao();
                }
            }         
            
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }        

        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("Bem vindo ao PlaySeries");
                Console.WriteLine();
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine();
                Console.WriteLine("1 - Lista séries");
                Console.WriteLine("2 - Inserir nova série");
                Console.WriteLine("3 - Atualizar série");
                Console.WriteLine("4 - Excluir série");
                Console.WriteLine("5 - Visualizar série");
                Console.WriteLine("C - Limpar Tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }

        private static string ObterOpcaoExclusao()
        {
            Console.WriteLine();
            Console.WriteLine("Tem certeza de que deseja excluir a série S/N: ");
            Console.Write("Digite S para Sim e N para Não: ");
            string opcaoExclusao = Console.ReadLine().ToUpper();
            return opcaoExclusao;
        }
    }
}
