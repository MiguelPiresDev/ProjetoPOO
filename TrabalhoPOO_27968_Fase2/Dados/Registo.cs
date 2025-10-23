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
    /// Classe que representa o registo dos dados do sistema, incluindo produtos, categorias, clientes, compras e campanhas.
    /// </summary>
    [Serializable]
    public class Registo
    {
        #region Atributos
        // Produtos
        private List<Produto> todosProdutos = new List<Produto>();

        // Categorias
        private List<Categoria> todasCategorias = new List<Categoria>();

        // Clientes
        private List<Cliente> todosClientes = new List<Cliente>();

        // Compras
        private List<Compra> todasCompras = new List<Compra>();

        // Carrinhos
        private Dictionary<int, List<int>> compraProdutos = new Dictionary<int, List<int>>();

        // Campanhas
        private List<Campanha> todasCampanhas = new List<Campanha>();
        #endregion

        #region Propriedades
        // Produtos
        public List<Produto> TodosProduto { get { return todosProdutos; } set {
                                            if (value != null) todosProdutos = value; } }
        // Categorias
        public List<Categoria> TodasCategoria { get { return todasCategorias; } set { 
                                            if (value != null) todasCategorias = value; } }
        // Clientes
        public List<Cliente> TodosCliente { get { return todosClientes; } set {
                                            if (value != null) todosClientes = value; } }
        // Compras
        public List<Compra> TodasCompra { get { return todasCompras; } set {
                                            if (value != null) todasCompras = value; } }
        // Carrinhos
        public Dictionary<int, List<int>> Carrinho { get { return compraProdutos; } set {
                                            if (value != null) compraProdutos = value; } }
        //Campanha
        public List<Campanha> TodasCampanha { get { return todasCampanhas; } set {
                                            if (value != null) todasCampanhas = value; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Cria um objeto Registo com todos os dados atuais do sistema.
        /// </summary>
        /// <returns>Objeto Registo contendo os dados atuais do sistema.</returns>
        public static Registo GuardarDados()
        {
            return new Registo
            {
                TodasCategoria = Categorias.TodasCategoria,
                TodosCliente = Clientes.TodosCliente,
                TodasCompra = Compras.TodasCompra,
                TodosProduto = Produtos.TodosProduto,
                TodasCampanha = Campanhas.TodasCampanha,
                Carrinho = Carrinhos.CompraProdutos //Dictionary
            };
        }

        /// <summary>
        /// Adiciona os dados de um objeto Registo ao sistema.
        /// </summary>
        /// <param name="dados">Objeto Registo contendo os dados a serem adicionados.</param>
        public static bool AdicionarDados(Registo dados)
        {
            if (dados != null)
            {
                Categorias.TodasCategoria.Clear();
                Categorias.TodasCategoria.AddRange(dados.TodasCategoria);

                Clientes.TodosCliente.Clear();
                Clientes.TodosCliente.AddRange(dados.TodosCliente);

                Compras.TodasCompra.Clear();
                Compras.TodasCompra.AddRange(dados.TodasCompra);

                Produtos.TodosProduto.Clear();
                Produtos.TodosProduto.AddRange(dados.TodosProduto);

                Campanhas.TodasCampanha.Clear();
                Campanhas.TodasCampanha = dados.TodasCampanha;

                //Dictionary
                Carrinhos.CompraProdutos.Clear();
                foreach (var item in dados.Carrinho)
                {
                    Carrinhos.CompraProdutos[item.Key] = item.Value;
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
