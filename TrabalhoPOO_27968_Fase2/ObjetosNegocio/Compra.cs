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
    /// Classe que representa uma compra
    /// </summary>
    public class Compra
    {
        #region Atributos
        static int contadorIdCompra = 0;
        int idCompra;
        int idCliente;
        bool contrib;
        DateTime dataCompra;
        #endregion

        #region Propriedades
        public int IdCompra { private set { idCliente = value; } get { return idCompra; } }
        public int IdCliente { set { idCliente = value; } get { return idCliente; } }
        public bool Contribuinte { private set { contrib = value; } get { return contrib; } }
        public DateTime DataCompra { private set { dataCompra = value; } get { return dataCompra; } }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor da classe Compra para clientes com contribuinte
        /// </summary>
        /// <param name="idCl">ID do cliente</param>
        public Compra(int idCl)
        {
            IdCompra = ++contadorIdCompra; // Gera um ID unico para a compra
            IdCliente = idCl;
            DataCompra = DateTime.Now; // Define a data atual como data da compra
            Contribuinte = true; // Indica que o cliente tem contribuinte
        }

        /// <summary>
        /// Construtor da classe Compra para clientes sem contribuinte
        /// </summary>
        public Compra()
        {
            idCompra = ++contadorIdCompra;
            DataCompra = DateTime.Now;
            IdCliente = 0; // ID do cliente e 0 para compras sem cliente associado
            Contribuinte = false; // Indica que o cliente nao tem contribuinte
        }
        #endregion

        #region Metodos
        // <summary>
        /// Metodo estatico que cria uma nova compra
        /// </summary>
        /// <param name="idCliente">ID do cliente</param>
        /// <param name="contrib">Indica se o cliente tem contribuinte</param>
        /// <returns>Objeto Compra criado</returns>
        /// <exception cref="ArgumentException">Lancada quando os parametros fornecidos sao invalidos.</exception>
        /// <exception cref="Exception">Lancada para outros erros gerais.</exception>
        public static Compra CriaCompra(int idCliente, bool contrib)
        {
            try
            {
                if (contrib)
                {
                    Compra novaCompraCli = new Compra(idCliente);
                    if (novaCompraCli != null && novaCompraCli.IdCompra == idCliente)
                        return novaCompraCli;
                }
                Compra novaCompra = new Compra();
                return novaCompra;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch(Exception ) 
            {
                throw new Exception();
            } 
        }
        #endregion
    }
}