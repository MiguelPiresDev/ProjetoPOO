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
    /// Classe que representa uma lista estatica que contem campanhas.
    /// </summary>
    public static class Campanhas
    {
        #region Atributos
        /// <summary>
        /// Lista estatica para armazenar todas as campanhas
        /// </summary>
        static List<Campanha> todasCampanha = new List<Campanha>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para aceder a lista de todas as campanhas
        /// </summary>
        public static List<Campanha> TodasCampanha { set { todasCampanha = value; } get { return todasCampanha; } }
        #endregion

        #region Metodos
        //// <summary>
        /// Adiciona uma nova campanha à lista de campanhas.
        /// Lança uma exceção se ocorrer um erro durante a adição da campanha.
        /// </summary>
        /// <param name="campanha">Campanha a ser adicionada.</param>
        /// <returns>True se a campanha foi adicionada com sucesso, caso contrário False.</returns>
        /// <exception cref="Exception">Lançada quando ocorre um erro durante a adição da campanha.</exception>
        public static bool AdicionarCampanha(Campanha campanha)
        {
            if (campanha == null) return false;

            try
            {
                todasCampanha.Add(campanha);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Remove uma campanha da lista pelo ID.
        /// Lança uma exceção se ocorrer um erro durante a remoção da campanha.
        /// </summary>
        /// <param name="id">ID da campanha a ser removida.</param>
        /// <returns>True se a campanha foi removida com sucesso, caso contrário False.</returns>
        /// <exception cref="Exception">Lançada quando ocorre um erro durante a remoção da campanha.</exception>
        public static bool RemoverCampanha(int id)
        {
            Campanha campanha = EncontrarCampanha(id);

            if (campanha != null) return false;
            try
            {
                todasCampanha.Remove(campanha);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Verifica se uma campanha existe na lista pelo ID
        /// </summary>
        /// <param name="id">ID da campanha</param>
        /// <returns>True se a campanha existir, caso contrario False</returns>
        public static bool ExisteCampanha(int id)
        {
            foreach (Campanha campanha in todasCampanha)
            {
                if (campanha.IdCampanha == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Encontra uma campanha na lista pelo ID
        /// </summary>
        /// <param name="id">ID da campanha</param>
        /// <returns>A campanha encontrada ou null</returns>
        public static Campanha EncontrarCampanha(int id)
        {
            foreach (Campanha campanha in todasCampanha)
            {
                if (campanha.IdCampanha == id)
                {
                    return campanha;
                }
            }
            return null;
        }
        #endregion
    }
}
