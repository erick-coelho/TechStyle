using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TechStyle.dominio.Modelo
{
    public class Segmento : IEntity
    {
        public int Id { get; private set; }
        public string Categoria { get; private set; }
        public string Subcategoria { get; private set; }
        [JsonIgnore]
        public List<Produto> Produtos { get; private set; }

        public Segmento Cadastrar(string categoria, string subCategoria)
        {
            Categoria = categoria;
            Subcategoria = subCategoria;
            return this;
        }

        internal void Alterar(Segmento segmento)
        {
            Categoria = segmento.Categoria;
            Subcategoria = segmento.Subcategoria;
        }
    }
}