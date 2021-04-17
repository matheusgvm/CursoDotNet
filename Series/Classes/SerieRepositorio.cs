using System;
using System.Collections.Generic;
using Series.Interfaces;
namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSeries = new List<Serie>();

        public void atualiza(int id, Serie entidade)
        {
            listaSeries[id] = entidade;
        }

        public void exclui(int id)
        {
            listaSeries[id].excluir();
        }

        public void insere(Serie entidade)
        {
            listaSeries.Add(entidade);
        }

        public List<Serie> lista()
        {
            return listaSeries;
        }

        public int proximoId()
        {
            return listaSeries.Count;
        }

        public Serie retornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}