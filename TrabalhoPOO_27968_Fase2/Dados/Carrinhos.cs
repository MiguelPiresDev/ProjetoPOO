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
    /// Lista estática para armazenar todos os Produtos na Compra
    /// </summary>
    public static class Carrinhos
    {
        #region Atributos
        /// <summary>
        /// Dicionario estatico para armazenar os produtos associados a cada carrinho por ID
        /// </summary>
        static Dictionary<int, List<int>> compraProdutos;
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para aceder ao dicionario de carrinhos
        /// </summary>
        public static Dictionary<int, List<int>> CompraProdutos { get { return compraProdutos; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Cria um novo carrinho para um cliente pelo ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>True se o carrinho foi criado com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao criar o carrinho.</exception>
        public static bool CriaCarrinho(int id)
        {
            try
            {
                compraProdutos[id] = new List<int>();
                if (!ExisteCarrinho(id)) return false;

                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Insere produtos no carrinho de um cliente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="idProdutos">Lista de inteiros (IdCliente) a serem inseridos</param>
        /// <returns>True se os produtos foram inseridos com sucesso, caso contrario False</returns>
        /// <exception cref="ArgumentException">Lancada quando ocorre um erro ao inserir os produtos no carrinho.</exception>
        /// <exception cref="Exception">Lancada para outros erros gerais.</exception>
        public static bool InsereDadosNoCarrinho(int id, List<int> idProdutos)
        {
            if (!ExisteCarrinho(id))
                return false;
            try
            {
                compraProdutos[id].AddRange(idProdutos);

                if (compraProdutos[id].Count == 0)
                    return false;

                return true;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Verifica se um carrinho existe pelo ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>True se o carrinho existir, caso contrario False</returns>
        public static bool ExisteCarrinho(int id)
        {
            if (compraProdutos.ContainsKey(id))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Encontra os produtos no carrinho de compra do cliente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>Lista de produtos presentes no carrinho</returns>
        public static List<Produto> EncontraProdutosCompra(int id)
        {
            List<Produto> produtos = new List<Produto>();

            foreach (int idProduto in compraProdutos[id])
            {
                produtos.Add(Produtos.EncontrarProduto(idProduto));
            }
            return produtos;
        }

        /// <summary>
        /// Modifica os produtos de um carrinho existente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="idProdutos">Lista de inteiros (IdCliente)</param>
        /// <returns>True se os produtos foram modificados com sucesso, caso contrario False</returns>
        /// <exception cref="ArgumentException">Lancada quando ocorre um erro ao modificar o carrinho.</exception>
        /// <exception cref="Exception">Lancada para outros erros gerais.</exception>
        public static bool ModificaCarrinho(int id, List<int> idProdutos)
        {
            if (ExisteCarrinho(id))
            {
                compraProdutos[id].Clear();

                try
                {
                    bool verifica = InsereDadosNoCarrinho(id, idProdutos);
                    return verifica;
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Adiciona uma unidade de um produto ao carrinho de um cliente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="idProduto">ID de Produto a ser adicionado</param>
        /// <returns>True se a unidade foi adicionada com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao adicionar a unidade.</exception>
        public static bool AdicionaUnidade(int id, int idProduto)
        {
            if (!ExisteCarrinho(id) && idProduto == null)
                return false;
            try
            {
                compraProdutos[id].Add(idProduto);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Remove uma unidade de um produto do carrinho de um cliente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="idProduto">ID de Produto a ser removido</param>
        /// <returns>True se a unidade foi removida com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao remover a unidade.</exception>
        public static bool RemoveUnidade(int id, int idProduto)
        {
            if (!ExisteCarrinho(id) || idProduto == null)
                return false;

            foreach (int produtoCompra in compraProdutos[id])
            {
                if (produtoCompra == idProduto)
                {
                    try
                    {
                        compraProdutos[id].Remove(produtoCompra);
                        return true;
                    }
                    catch (Exception)
                    {
                        throw new Exception();
                    }
                }
            }
            return false;
        }
        #endregion
    }
}