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
    public class Compras
    {
        #region
        /// <summary>
        /// Lista estática para armazenar todas as compras
        /// </summary>
        static List<Compra> todasCompra = new List<Compra>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para acessar a lista de todas as compras
        /// </summary>
        public static List<Compra> TodasCompra { get { return todasCompra; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Adiciona uma nova compra à lista de compras
        /// </summary>
        /// <param name="compra">Compra a ser adicionada</param>
        /// <returns>True se a compra foi adicionada com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao adicionar a compra.</exception>
        public static bool AdicionarCompra(Compra compra)
        {
            if (compra == null) return false;
            try
            {
                todasCompra.Add(compra);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Remove uma compra da lista pelo ID
        /// </summary>
        /// <param name="id">ID da compra a ser removida</param>
        /// <returns>True se a compra foi removida com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao remover a compra.</exception>
        public static bool RemoverCompra(int id)
        {
            Compra compra = EncontrarCompra(id);

            if (compra == null) return false;
            try
            {
                todasCompra.Remove(compra);
                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Verifica se uma compra existe na lista pelo ID
        /// </summary>
        /// <param name="id">ID da compra</param>
        /// <returns>True se a compra existir, caso contrário False</returns>
        public static bool ExisteCompra(int id)
        {
            foreach (Compra compra in todasCompra)
            {
                if (compra.IdCompra == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Encontra uma compra na lista pelo ID
        /// </summary>
        /// <param name="id">ID da compra</param>
        /// <returns>A compra encontrada ou null</returns>
        public static Compra EncontrarCompra(int id)
        {
            foreach (Compra compra in TodasCompra)
            {
                if (compra.IdCompra == id)
                {
                    return compra;
                }
            }
            return null;
        }
        #endregion
    }
}
