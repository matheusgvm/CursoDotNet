using System;

namespace Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){

                    case "1":
                        listarSeries();
                        break;

                    case "2":
                        inserirSerie();
                        break;

                    case "3":
                        atualizarSerie();
                        break;

                    case "4":
                        excluirSerie();
                        break;   

                    case "5":
                        visualizarSerie();
                        break; 

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();        
                }

                opcaoUsuario = obterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.WriteLine();    
        }

        private static void listarSeries(){
            Console.WriteLine("Listar séries");
            var lista = repositorio.lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluído*" : "");
            }
        }

        private static void inserirSerie(){
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao= Console.ReadLine();

            Serie novaSerie;
            Console.WriteLine("Você já assistiu a série? Digite s/n");
            string entradaJaAssistiu = Console.ReadLine();
            if(entradaJaAssistiu.Equals("s")){
                Console.Write("Qual nota você dá para a série? ");
                float entradaNota = float.Parse(Console.ReadLine());

                novaSerie = new Serie(id: repositorio.proximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        jaAssistiu: true,
                                        nota: entradaNota);
            }

            else{ 
                novaSerie = new Serie(id: repositorio.proximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        jaAssistiu: false,
                                        nota: 0);
            }                            

            repositorio.insere(novaSerie);                            
        }

        private static void atualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genêro entre as opções: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao= Console.ReadLine();
            
            Serie atualizaSerie;
            Console.WriteLine("Você já assistiu a série? Digite s/n");
            string entradaJaAssistiu = Console.ReadLine();
            if(entradaJaAssistiu.Equals('s')){
                Console.Write("Qual nota você dá para a série?" );
                float entradaNota = float.Parse(Console.ReadLine());

                atualizaSerie = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        jaAssistiu: true,
                                        nota: entradaNota);
            }

            else{ 
                atualizaSerie = new Serie(id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao,
                                        jaAssistiu: false,
                                        nota: 0);
            }                            

            repositorio.atualiza(idSerie, atualizaSerie);    
        }

        private static void excluirSerie(){
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repositorio.exclui(idSerie);
        }

        private static void visualizarSerie(){
            Console.WriteLine("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(idSerie);
            Console.WriteLine(serie);
        }

        private static string obterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
