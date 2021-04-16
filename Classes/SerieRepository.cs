using Series.interfaces;
using System.Collections.Generic;
using System;
namespace Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Delete(int id)
        {
            listaSerie[id].Excluir();
        }

        public Serie getId(int id)
        {
            return listaSerie[id];
        }

        public void insert(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int nextId()
        {
            return listaSerie.Count;
        }

        public void Update(int id, Serie objeto)
        {
           listaSerie[id] = objeto; 
        }
    }
}