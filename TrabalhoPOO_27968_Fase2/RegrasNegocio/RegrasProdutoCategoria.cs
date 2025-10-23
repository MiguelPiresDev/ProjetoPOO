using ObjetosNegocio;
using TratamentoErros;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
    /// Classe com regras para gerir a integracao entre produtos e categorias.
    /// </summary>
    public static class RegrasProdutoCategoria
    {
        #region Metodos
        /// <summary>
        /// Tenta criar um produto e associa-lo a uma categoria existente ou cria uma nova categoria.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="modelo">Modelo do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="quant">Quantidade do produto.</param>
        /// <param name="preco">Preco do produto.</param>
        /// <returns>True se o produto foi criado e associado com sucesso; caso contrario, false.</returns>
        /// <exception cref="ArgumentException">Lanca excecao se os parametros do produto ou categoria forem invalidos.</exception>
        /// <exception cref="Exception">Lanca excecao para erros inesperados durante a criacao ou associacao.</exception>
        public static bool TentarCriarProdutoCategoria(string nome, string marca, string modelo, string cat, int quant, double preco)
        {
            try
            {
                Produto p = RegrasProduto.TentaCriarProduto(nome, marca, modelo, cat, quant, preco);
                RegrasProduto.TentaInserirLista(p);
            }
            catch(ArgumentException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new Exception();
            }

            if (Categorias.ExisteCategoria(cat))
            {
                Categoria categoria = Categorias.EncontrarCategoria(cat);
                categoria.Quantidade = +quant;
            }
            else if (char.IsUpper(cat[0]))
            {
                try
                {
                    Categoria categoria = RegrasCategoria.TentarCriarCategoria(cat, quant);
                    RegrasCategoria.TentaInserirLista(categoria);
                    return true;
                }
                catch (ArgumentException )
                {
                    throw new ArgumentException();
                }
                catch(Exception)
                {
                    throw new Exception();
                }
            }
            return false;
        }

        /// <summary>
        /// Tenta remover um produto e atualizar a quantidade da categoria associada.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>True se o produto foi removido com sucesso; caso contrario, false.</returns>
        /// <exception cref="Exception">Lanca excecao para erros durante a remocao do produto ou atualizacao da categoria.</exception>
        public static bool TentarRemoverProdutoCategoria(int id)
        {
            if (!Produtos.ExisteProduto(id)) return false;

            // Identifica qual o Produto e a Categoria associada
            Produto produto = Produtos.EncontrarProduto(id);
            Categoria categoriaExistente = Categorias.EncontrarCategoria(produto.CategoriaP);

            if (produto == null || categoriaExistente == null) return false;

            // Atualiza a quantidade em categoria e remove o Produto em questao 
            categoriaExistente.Quantidade = -(produto.Quantidade);

            try
            {
                Produtos.RemoverProduto(produto.IdProduto);
                return true;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}