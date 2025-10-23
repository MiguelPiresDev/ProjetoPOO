using ObjetosNegocio;
using TratamentoErros;
using Dados;
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

namespace RegrasNegocio
{
    /// <summary>
    /// Classe que define as regras relacionadas às compras, incluindo criação e manipulação de carrinhos de compras.
    /// </summary>
    public class RegrasCompra
    {
        #region Métodos
        /// <summary>
        /// Tenta executar uma compra associada a um cliente.
        /// Lança uma exceção se ocorrer um erro durante a criação da compra ou do carrinho, ou ao adicionar os produtos.
        /// </summary>
        /// <param name="idCliente">ID do cliente.</param>
        /// <param name="contrib">Indica se o cliente possui contribuinte.</param>
        /// <param name="produtos">Lista de IDs de produtos a serem comprados.</param>
        /// <returns>True se a compra for realizada com sucesso; caso contrário, False.</returns>
        /// <exception cref="ArgumentException">Lançada quando um argumento inválido é passado.</exception>
        /// <exception cref="Exception">Lançada para outros erros gerais.</exception>
        public static bool TentarExecutarCompra(int idCliente, bool contrib, List<int> produtos)
        {
            if (idCliente > 0)
            {
                try
                {
                    Compra compra = Compra.CriaCompra(idCliente, contrib);
                    Compras.AdicionarCompra(compra);

                    Carrinhos.CriaCarrinho(compra.IdCompra);
                    Carrinhos.InsereDadosNoCarrinho(compra.IdCompra, produtos);
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
            return false;
        }

        /// <summary>
        /// Tenta modificar todos os produtos de um carrinho associado a uma compra.
        /// Lança uma exceção se ocorrer um erro durante a modificação dos produtos no carrinho.
        /// </summary>
        /// <param name="idCompra">ID da compra.</param>
        /// <param name="produtos">Nova lista de IDs de produtos a substituir a anterior.</param>
        /// <returns>True se a modificação for bem-sucedida; caso contrário, False.</returns>
        /// <exception cref="ArgumentException">Lançada quando ocorre um erro ao modificar o carrinho.</exception>
        /// <exception cref="Exception">Lançada para outros erros gerais.</exception>
        public static bool TentarModificarTodoCarrinho(int idCompra, List<int> produtos)
        {
            if (produtos.Count > 0)
            {
                try
                {
                    Carrinhos.ModificaCarrinho(idCompra, produtos);
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
            return false;
        }

        /// <summary>
        /// Tenta adicionar um produto específico ao carrinho de uma compra.
        /// Lança uma exceção se ocorrer um erro durante a adição do produto ao carrinho.
        /// </summary>
        /// <param name="idCompra">ID da compra.</param>
        /// <param name="idProduto">ID do produto a ser adicionado.</param>
        /// <returns>True se o produto for adicionado com sucesso; caso contrário, False.</returns>
        /// <exception cref="Exception">Lançada quando ocorre um erro ao adicionar a unidade.</exception>
        public static bool TentarAdicionarProduto(int idCompra, int idProduto)
        {
            if (idProduto > 0)
            {
                try
                {
                    Carrinhos.AdicionaUnidade(idCompra, idProduto);
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Tenta remover um produto específico do carrinho de uma compra.
        /// Lança uma exceção se ocorrer um erro durante a remoção do produto do carrinho.
        /// </summary>
        /// <param name="idCompra">ID da compra.</param>
        /// <param name="idProduto">ID do produto a ser removido.</param>
        /// <returns>True se o produto for removido com sucesso; caso contrário, False.</returns>
        /// <exception cref="Exception">Lançada quando ocorre um erro ao remover a unidade.</exception>
        public static bool TentarRemoverProduto(int idCompra, int idProduto)
        {
            if (idProduto > 0)
            {
                try
                {
                    Carrinhos.RemoveUnidade(idCompra, idProduto);
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return false;
        }


        /// <summary>
        /// Calcula o valor total a pagar pelo carrinho de um cliente
        /// </summary>
        /// <param name="idProduto">Lista do tipo Produto</param>
        /// <returns>Valor total a pagar</returns>
        public static double ValorPagar(int idCompra)
        {
            if (!Compras.ExisteCompra(idCompra)) return 0;

            List<Produto> prod = Carrinhos.EncontraProdutosCompra(idCompra);

            double valorPagar = 0;
            foreach (Produto produto in prod)
            {
                valorPagar += produto.Preco * produto.Elemento; // Preco * quantidade de cada produto
            }
            return valorPagar;
        }
        #endregion
    }
    

}