using ObjetosNegocio;
using TratamentoErros;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Autor: José Miguel Pires - 27968
/// Data: 2024-12-18
/// Instituto: IPCA
/// </summary>

namespace RegrasNegocio
{
    /// <summary>
    /// Classe com regras para gerir produtos.
    /// </summary>
    public static class RegrasProduto
    {
        /// <summary>
        /// Tenta criar um produto com os dados fornecidos.
        /// </summary>
        /// <param name="nome">Nome do produto.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="modelo">Modelo do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="quant">Quantidade do produto.</param>
        /// <param name="preco">Preco do produto.</param>
        /// <returns>Objeto Produto se criado com sucesso; caso contrario, null.</returns>
        /// <exception cref="ArgumentException">Lancada se algum argumento invalido for fornecido.</exception>
        /// <exception cref="Exception">Lancada para erros genericos durante a criacao do produto.</exception>
        public static Produto TentaCriarProduto(string nome, string marca, string modelo, string cat, int quant, double preco)
        {
            if (preco <= 0) return null;
            try
            {
                Produto novoProduto = Produto.CriaProduto(nome, marca, modelo, cat, quant, preco);
                return novoProduto;
            }
            catch(ArgumentException e)
            {
                throw e;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Tenta inserir um produto na lista de produtos.
        /// </summary>
        /// <param name="produto">Objeto Produto a ser inserido.</param>
        /// <returns>True se o produto foi inserido com sucesso; caso contrario, false.</returns>
        /// <exception cref="Exception">Lancada em caso de erro ao inserir o produto na lista.</exception>
        public static bool TentaInserirLista(Produto produto)
        {
            if (produto == null) return false;
            try
            {
                bool verifica = Produtos.AdicionarProduto(produto);
                return verifica;
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Tenta remover um produto da lista de produtos.
        /// </summary>
        /// <param name="id">ID do produto a ser removido.</param>
        /// <returns>True se o produto foi removido com sucesso; caso contrario, false.</returns>
        /// <exception cref="Exception">Lancada em caso de erro durante a remocao do produto.</exception>
        public static bool TentaRemoverProduto(int id)
        {
            if(id <= 0) return false;

            if (!Produtos.ExisteProduto(id)) return false;
            try
            {
                bool verifica = Produtos.RemoverProduto(id);
                return verifica;
            }
            catch (Exception)
            {
                throw new Exception();
            }   
        }
    }
}