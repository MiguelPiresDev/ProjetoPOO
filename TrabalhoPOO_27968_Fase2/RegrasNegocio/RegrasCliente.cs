using ObjetosNegocio;
using TratamentoErros;
using Dados;
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

namespace RegrasNegocio
{
    /// <summary>
    /// Classe que define as regras relacionadas aos clientes, incluindo criação e atualização.
    /// </summary>
    public static class RegrasCliente
    {
        /// <summary>
        /// Tenta criar um novo cliente com os dados especificados e inserir na lista estatica.
        /// </summary>
        /// <param name="nome">Nome do cliente.</param>
        /// <param name="telemovel">Numero de telemovel do cliente.</param>
        /// <param name="morada">Morada do cliente.</param>
        /// <param name="contrib">Numero de contribuinte do cliente.</param>
        /// <returns>Uma nova instancia de Cliente se valida; caso contrario, null.</returns>
        /// <exception cref="ArgumentException">Lancada quando os parametros fornecidos sao invalidos.</exception>
        /// <exception cref="Exception">Lancada para outros erros gerais.</exception>
        public static bool TentaCriarInserirCliente(string nome, int telemovel, string morada, int contrib)
        {
            string strTelemovel = telemovel.ToString();

            if (strTelemovel[0] == '9' && (strTelemovel[1] == '1' || strTelemovel[1] == '2' ||
                                           strTelemovel[1] == '3' || strTelemovel[1] == '6'))
            {
                try
                {
                    Cliente cliente = Cliente.CriaCliente(nome, telemovel, morada, contrib);
                    bool verifica = Clientes.AdicionarCliente(cliente);
                    return verifica;
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
            return false;
        }

        /// <summary>
        /// Tenta remover um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser removido.</param>
        /// <returns>True se a remocao for bem-sucedida; caso contrario, False.</returns>
        /// <exception cref="Exception">Lancada quando ocorre um erro ao remover o cliente.</exception>
        public static bool TentaRemoverLista(int id)
        {
            if (!Clientes.ExisteCliente(id)) return false;
            try
            {
                bool verifica = Clientes.RemoverCliente(id);
                return verifica;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Tenta atualizar os dados de um cliente existente.
        /// </summary>
        /// <param name="id">ID do cliente a ser atualizado.</param>
        /// <param name="op">Codigo da operacao a ser realizada.</param>
        /// <param name="alteracao">Nova informacao a ser atualizada.</param>
        /// <returns>True se a atualizacao for bem-sucedida; caso contrario, False.</returns>
        public static bool TentaAtualizarCliente(int id, int op, string alteracao)
        {
            if (!Clientes.ExisteCliente(id)) return false;

            bool verifica = Clientes.AtualizarCliente(id, op, alteracao);
            return verifica;
        }
    }
}
