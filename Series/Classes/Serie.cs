using System;

namespace Series
{
    public class Serie : EntidadeBase
    {

        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }
        private bool excluido {get; set;}
        private bool jaAssistiu {get; set;}
        private float nota {get; set;}
        

        public Serie(int id, Genero genero, string titulo, string descricao, int ano, bool jaAssistiu, float nota)
        {   
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
            this.jaAssistiu = jaAssistiu;
            this.nota = nota;
        }

        public override string ToString()
        {   
            string retorno = "";
            retorno += "Gênero: " + this.genero + Environment.NewLine;
            retorno += "Título: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.ano + Environment.NewLine;
            retorno += "Já assisti?: " + this.jaAssistiu + Environment.NewLine;
            if(this.jaAssistiu){
                retorno += "Nota: " + this.nota + Environment.NewLine;
            }
            retorno += "Excluído: " + this.excluido;

            return retorno;
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public bool retornaExcluido(){
            return this.excluido;
        }

        public int retornaId(){
            return this.id;
        }

        public void excluir(){
            this.excluido = true;
        }

    }
}