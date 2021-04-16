using System.Runtime.Serialization;
using System;

namespace Series
{
    class Program
    {
        static SerieRepository repositorio = new SerieRepository();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObteropcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
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

                opcaoUsuario = ObteropcaoUsuario();
            }
            Console.WriteLine("obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        public static void ListarSeries(){
            Console.WriteLine("Lista de Series");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma Serie cadastrada.");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.getExcluido();
                
                if(!excluido){
                    Console.WriteLine("#ID {0}: - {1}", serie.getId(), serie.getTitulo());
                }
                
            }
        }

        public static void InserirSerie(){
            Console.WriteLine("inserir Serie");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a sinopse da serie");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.nextId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
            );

            repositorio.insert(novaSerie);
        }

        public static void AtualizarSerie(){
            Console.WriteLine("Digite o Id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1} ", i,  Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Digite o gênero entre as opções acima");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a sinopse da serie");
            string entradaDescricao = Console.ReadLine();

            Serie serieAtualizada = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
            );

            repositorio.Update(indiceSerie, serieAtualizada);
        }

        public static void ExcluirSerie(){
            Console.WriteLine("Digite o Id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Delete(indiceSerie);
        }

        public static void VisualizarSerie(){
            Console.WriteLine("Digite o Id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.getId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static string ObteropcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("ConsoleFlix a seu dispor");
            Console.WriteLine("Informe uma das opções abaixo");

            Console.WriteLine("1 - Listar Series ");
            Console.WriteLine("2 - Inseriri nova Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Vizualizar Serie ");
            Console.WriteLine("C - limpar tela");
            Console.WriteLine("X - Sair ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
