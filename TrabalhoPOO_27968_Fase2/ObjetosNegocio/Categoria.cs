using ObjetosNegocio;
using TratamentoErros;
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

namespace ObjetosNegocio
{

    /// <summary>
    /// Classe que representa uma categoria de produtos
    /// </summary>
    public class Categoria
    {
        #region Atributos
        string nome;
        int quantidade;
        #endregion

        #region Propriedades
        public string Nome { set { nome = value; } get { return nome; } }
        public int Quantidade { set { if (value < 0) { quantidade = 0; } else { quantidade = value; } } get { return quantidade; } }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor que inicializa uma categoria com o nome dado
        /// </summary>
        /// <param name="n">Nome da categoria</param>
        public Categoria(string n)
        {
            Nome = n;
            Quantidade = 0;
        }

        /// <summary>
        /// Construtor que inicializa uma categoria com nome e quantidade
        /// </summary>
        /// <param name="n">Nome da categoria</param>
        /// <param name="quant">Quantidade inicial</param>
        public Categoria(string n, int quant)
        {
            Nome = n;
            Quantidade = quant;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que cria uma nova categoria.
        /// </summary>
        /// <param name="n">Nome da categoria.</param>
        /// <param name="quant">Quantidade inicial.</param>
        /// <returns>Objeto Categoria criado.</returns>
        /// <exception cref="ArgumentException">Lanca excecao se os parametros forem invalidos.</exception>
        /// <exception cref="Exception">Lanca excecao em caso de erro durante a execuçao</exception>
        public static Categoria CriaCategoria(string n, int quant)
        {
            try
            {
                Categoria categoria = new Categoria(n, quant);
                return categoria;
            }
            catch (ArgumentException e)
            {
                throw e;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }
        #endregion
    }
}