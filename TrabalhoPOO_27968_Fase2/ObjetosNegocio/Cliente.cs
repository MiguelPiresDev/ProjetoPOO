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
    /// Classe que representa um cliente
    /// </summary>
    public class Cliente
    {
        #region Atributos
        string nome;
        string telemovel;
        string morada;
        int contribuinte;
        int idCliente;
        static int contadorIdCli = 0;
        #endregion

        #region Propriedades
        public string Nome { set { nome = value; } get { return nome; } }
        public string Telemovel { set { telemovel = value; } get { return telemovel; } }
        public string Morada { set { morada = value; } get { return morada; } }
        public int Contribuinte { set { contribuinte = value; } get { return contribuinte; } }
        public int IdCliente { private set { idCliente = value; } get { return idCliente; } }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor que inicializa um novo cliente
        /// </summary>
        /// <param name="n">Nome do cliente</param>
        /// <param name="tele">Número de telemóvel</param>
        /// <param name="morada">Morada do cliente</param>
        /// <param name="contrib">Número de contribuinte</param>
        public Cliente(string n, int tele, string morada, int contrib)
        {
            Nome = n;
            Telemovel = "+351" + tele;
            Morada = morada;
            Contribuinte = contrib;
            IdCliente = ++contadorIdCli;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo estatico que cria um novo cliente
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="telemovel">Numero de telemovel</param>
        /// <param name="morada">Morada do cliente</param>
        /// <param name="contrib">Numero de contribuinte</param>
        /// <returns>Objeto Cliente criado</returns>
        /// <exception cref="ArgumentException">Lancada quando algum parametro for invalido</exception>
        /// <exception cref="Exception">Lancada para outros erros gerais</exception>
        public static Cliente CriaCliente(string nome, int telemovel, string morada, int contrib)
        {
            try
            {
                Cliente novoCliente = new Cliente(nome, telemovel, morada, contrib);
                return novoCliente;
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch(Exception) 
            {
                throw new Exception();
            }
        }
        #endregion
    }
}
