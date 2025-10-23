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
    public static class Clientes
    {
        #region Atributos
        /// <summary>
        /// Lista estatica para armazenar todos os clientes
        /// </summary>
        static List<Cliente> todosCliente = new List<Cliente>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para aceder a lista de todos os clientes
        /// </summary>
        public static List<Cliente> TodosCliente { get { return todosCliente; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Adiciona um novo cliente a lista de clientes
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado</param>
        /// <returns>True se o cliente foi adicionado com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao adicionar o cliente</exception>
        public static bool AdicionarCliente(Cliente cliente)
        {
            if (cliente == null) return false;
            try
            {
                todosCliente.Add(cliente);
                return true;
            }
            catch (Exception) 
            {
                throw new Exception();
            }       
        }

        /// <summary>
        /// Remove um cliente da lista pelo ID
        /// </summary>
        /// <param name="id">ID do cliente a ser removido</param>
        /// <returns>True se o cliente foi removido com sucesso, caso contrario False</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao remover o cliente</exception>
        public static bool RemoverCliente(int id)
        {
            Cliente cliente = EncontrarCliente(id);

            if (cliente == null) return false;
            try
            {
                todosCliente.Remove(cliente);
                return true;
            }
            catch(Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Atualiza os dados de um cliente existente
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <param name="op">Opçao de dado a ser alterado</param>
        /// <param name="alteracao">Novo valor do dado</param>
        /// <returns>True se a atualização foi bem-sucedida, caso contrario False</returns>
        public static bool AtualizarCliente(int id, int op, string alteracao)
        {
            Cliente cliente = EncontrarCliente(id);

            switch (op)
            {
                case 0:
                    cliente.Nome = alteracao;
                    break;

                case 1:
                    cliente.Telemovel = alteracao;
                    break;

                case 2:
                    cliente.Morada = alteracao;
                    break;

                case 3:
                    if (int.TryParse(alteracao, out int contribuinte))
                        cliente.Contribuinte = contribuinte;
                    else
                        return false; // Falha na conversão para Contribuinte
                    break;

                default:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica se um cliente existe na lista pelo ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>True se o cliente existir, caso contrario False</returns>
        public static bool ExisteCliente(int id)
        {
            foreach (Cliente cliente in TodosCliente)
            {
                if (cliente.IdCliente == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Encontra um cliente na lista pelo ID
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>O cliente encontrado ou null</returns>
        public static Cliente EncontrarCliente(int id)
        {
            foreach (Cliente cliente in TodosCliente)
            {
                if (cliente.IdCliente == id)
                {
                    return cliente;
                }
            }
            return null;
        }
        #endregion
    }
}
