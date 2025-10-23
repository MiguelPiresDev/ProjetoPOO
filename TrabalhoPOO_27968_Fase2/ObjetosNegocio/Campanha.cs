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
    /// Classe que representa uma campanha.
    /// </summary>
    public class Campanha
    {
        #region Atributos
        string nomeCampanha;
        int idCampanha = 0;
        static int idcont = 0;
        DateTime dataInicial;
        DateTime dataFinal;
        string descricao;
        #endregion

        #region Propriedades
        public string NomeCampanha { set { nomeCampanha = value; } get { return nomeCampanha; } }
        public int IdCampanha { set { idCampanha = value; } get { return idCampanha; } }
        public string Descricao { set { descricao = value; } get { return descricao; } }
        public DateTime DataInicial { set { dataInicial = value; } get { return dataInicial; } }
        public DateTime DataFinal { set { dataFinal = value; } get { return dataFinal; } }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor que inicializa uma campanha
        /// </summary>
        /// <param name="n">Nome da campanha</param>
        /// <param name="dataI">Data inicial</param>
        /// <param name="dataF">Data final</param>
        /// <param name="descricao">Descricao da campanha</param>
        public Campanha(string n, DateTime dataI, DateTime dataF, string descricao)
        {
            NomeCampanha = n;
            IdCampanha = ++idcont;
            DataInicial = dataI;
            DataFinal = dataF;
            Descricao = descricao;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método estático que cria uma nova campanha.
        /// Lança uma exceção se ocorrer um erro durante a criação da campanha.
        /// </summary>
        /// <param name="n">Nome da campanha.</param>
        /// <param name="dataI">Data inicial da campanha.</param>
        /// <param name="dataF">Data final da campanha.</param>
        /// <param name="descricao">Descrição da campanha.</param>
        /// <returns>Objeto Campanha criado.</returns>
        /// <exception cref="ArgumentException">Lançada quando um argumento inválido é passado.</exception>
        /// <exception cref="Exception">Lançada para outros erros gerais.</exception>
        public static Campanha CriaCampanha(string n, DateTime dataI, DateTime dataF, string descricao)
        {
            try
            {
                Campanha campanha = new Campanha(n, dataI, dataF, descricao);
                return campanha;
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