using ObjetosNegocio;
using TratamentoErros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Autor: José Miguel Pires - 27968
/// Data: 2024-12-18
/// Instituto: IPCA
/// </summary>

namespace ObjetosNegocio
{
    /// <summary>
    /// Classe que representa um produto
    /// </summary>
    public class Produto
    {
        #region Atributos
        int idProduto;
        string nome;
        static int contadorProduto = 0;
        string marca; 
        string modelo; 
        string categoria; 
        double preco; 
        int quantidade;
        int elemento; 
        #endregion

        #region Propriedades
        public int IdProduto { private set { idProduto = value; } get { return idProduto; } }
        public string Nome { set { nome = value; } get { return nome; } }
        public string Marca { set { marca = value; } get { return marca; } }
        public string Modelo { set { modelo = value; } get { return modelo; } }
        public string CategoriaP { set { categoria = value; } get { return categoria; } }
        public double Preco { set { preco = value; } get { return preco; } }
        public int Quantidade { private set { quantidade = value; } get { return quantidade; } }
        public int Elemento { set { elemento = value; } get { return elemento; } }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor que inicializa um novo produto com os parametros fornecidos.
        /// </summary>
        /// <param name="n">Nome do produto.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="mod">Modelo do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="quant">Quantidade disponivel.</param>
        /// <param name="preco">Preco do produto.</param>
        public Produto(string n, string marca, string mod, string cat, int quant, double preco)
        {
            Nome = n;
            IdProduto = ++contadorProduto;
            Marca = marca;
            Modelo = mod;
            CategoriaP = cat;
            Quantidade = quant;
            Preco = preco;
            Elemento = 1;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que cria e retorna um novo produto com os parametros fornecidos.
        /// </summary>
        /// <param name="n">Nome do produto.</param>
        /// <param name="marca">Marca do produto.</param>
        /// <param name="mod">Modelo do produto.</param>
        /// <param name="cat">Categoria do produto.</param>
        /// <param name="quant">Quantidade disponivel.</param>
        /// <param name="preco">Preco do produto.</param>
        /// <returns>Objeto Produto criado.</returns>
        /// <exception cref="ArgumentException">Lancada se algum argumento for invalido.</exception>
        /// <exception cref="Exception">Lancada em caso de erro durante a criacao do produto.</exception>
        public static Produto CriaProduto(string n, string marca, string mod, string cat, int quant, double preco)
        {
            try
            {
                Produto produto = new Produto(n, marca, mod, cat, quant, preco);
                return produto;
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
        #endregion
    }
}