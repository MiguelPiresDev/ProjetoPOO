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
    /// <summary>
    /// Classe que representa uma Lista de Produtos
    /// </summary>
    public class Produtos
    {
        #region Atributos
        /// <summary>
        /// Lista estatica para armazenar todos os produtos
        /// </summary>
        static List<Produto> todosProduto = new List<Produto>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para aceder a lista de todos os produtos
        /// </summary>
        public static List<Produto> TodosProduto { get { return todosProduto; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Adiciona um novo produto a lista de produtos.
        /// </summary>
        /// <param name="produto">Produto a ser adicionado.</param>
        /// <returns>True se o produto foi adicionado com sucesso; caso contrario, false.</returns>
        /// <exception cref="Exception">Lancada em caso de erro durante a adicao do produto.</exception>
        public static bool AdicionarProduto(Produto produto)
        {
            if (produto == null) return false;
            try
            {
                todosProduto.Add(produto);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Remove um produto da lista pelo ID.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>True se o produto foi removido com sucesso; caso contrario, false.</returns>
        /// <exception cref="Exception">Lancada em caso de erro durante a remocao do produto.</exception>
        public static bool RemoverProduto(int id)
        {
            Produto produto = EncontrarProduto(id);

            if (produto == null) return false;
            try
            {
                todosProduto.Remove(produto);
                return true;
            }
            catch (Exception)
            { 
                throw new Exception();
            }
        }

        /// <summary>
        /// Verifica se um produto existe na lista pelo ID
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>True se o produto existir, caso contrário False</returns>
        public static bool ExisteProduto(int id)
        {
            foreach (Produto produto in TodosProduto)
            {
                if (produto.IdProduto == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Encontra um produto na lista pelo ID
        /// </summary>
        /// <param name="id">ID do produto</param>
        /// <returns>O produto encontrado ou null</returns>
        public static Produto EncontrarProduto(int id)
        {
            foreach (Produto produto in TodosProduto)
            {
                if (produto.IdProduto == id)
                {
                    return produto;
                }
            }
            return null;
        }
        #endregion
    }
}