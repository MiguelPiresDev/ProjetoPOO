using Dados;
using TratamentoErros;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Autor: José Miguel Pires - 27968
/// Data: 2024-12-18
/// Instituto: IPCA
/// </summary>

namespace Dados
{
    public static class Categorias
    {
        #region Atributos
        /// <summary>
        /// Lista estatica para armazenar todas as categorias
        /// </summary>
        static List<Categoria> todasCategoria = new List<Categoria>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para aceder a lista de todas as categorias
        /// </summary>
        public static List<Categoria> TodasCategoria { get { return todasCategoria; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Adiciona uma nova categoria a lista de categorias.
        /// </summary>
        /// <param name="categoria">Categoria a ser adicionada.</param>
        /// <returns>True se a categoria foi adicionada com sucesso, caso contrario False.</returns>
        /// <exception cref="Exception">Lanca excecao em caso de erro na adicao.</exception>
        public static bool AdicionarCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                try
                {
                    todasCategoria.Add(categoria);
                    return true;
                }
                catch(Exception) 
                {
                    throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Remove uma categoria da lista pelo nome.
        /// </summary>
        /// <param name="nome">Nome da categoria a ser removida.</param>
        /// <returns>True se a categoria foi removida com sucesso, caso contrario False.</returns>
        /// <exception cref="Exception">Lanca excecao em caso de erro na remocao.</exception>
        public static bool RemoverCategoria(string nome)
        {
            Categoria categoria = EncontrarCategoria(nome);

            if (categoria != null && nome != null)
            {
                try
                {
                    todasCategoria.Remove(categoria);
                    return true;
                }
                catch(Exception)
                {
                    throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica se uma categoria existe na lista pelo nome
        /// </summary>
        /// <param name="nome">Nome da categoria</param>
        /// <returns>True se a categoria existir, caso contrario False</returns>
        public static bool ExisteCategoria(string nome)
        {
            foreach (Categoria categoria in TodasCategoria)
            {
                if (categoria.Nome == nome)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Encontra uma categoria na lista pelo nome
        /// </summary>
        /// <param name="nome">Nome da categoria</param>
        /// <returns>A categoria encontrada ou null</returns>
        public static Categoria EncontrarCategoria(string nome)
        {
            foreach (Categoria categoria in TodasCategoria)
            {
                if (categoria.Nome == nome)
                {
                    return categoria;
                }
            }
            return null;
        }

        /// <summary>
        /// Retorna o stock total de todas as categorias
        /// </summary>
        /// <returns>Soma das quantidades de todas as categorias</returns>
        public static int Stock()
        {
            int soma = 0;

            foreach (Categoria cat in TodasCategoria)
            {
                soma += cat.Quantidade;
            }
            return soma;
        }
        #endregion
    }
}