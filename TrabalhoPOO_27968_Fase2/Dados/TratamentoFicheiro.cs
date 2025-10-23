using Dados;
using TratamentoErros;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Classe responsavel por tratar o armazenamento e carregamento de dados em ficheiros.
    /// </summary>
    public static class TratamentoFicheiro
    {
        /// <summary>
        /// Guarda os dados num ficheiro binario no caminho especificado.
        /// </summary>
        /// <param name="caminho">Caminho para o ficheiro onde os dados serao guardados.</param>
        /// <param name="dados">Objeto do tipo Registo a ser guardado.</param>
        /// <returns>True se os dados forem guardados com sucesso.</returns>
        /// <exception cref="ExcecaoFicheiroGuardar">Excecao personalizada lancada se ocorrer um erro ao guardar os dados.</exception>
        /// <exception cref="Exception">Excecao generica lancada para outros erros nao especificados.</exception>
        public static bool GuardarDados(string caminho, Registo dados)
        {
            try
            {
                Stream stream = File.Open(caminho, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, dados);
                stream.Close();
                return true;
            }
            catch (ExcecaoFicheiroGuardar)
            {
                throw new ExcecaoFicheiroGuardar();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Carrega os dados a partir de um ficheiro binario no caminho especificado.
        /// </summary>
        /// <param name="caminho">Caminho para o ficheiro de onde os dados serao carregados.</param>
        /// <returns>Objeto do tipo Registo carregado a partir do ficheiro. Retorna null se o ficheiro nao existir.</returns>
        /// <exception cref="ExcecaoFicheiroCarregar">Excecao personalizada lancada se ocorrer um erro ao carregar os dados.</exception>
        /// <exception cref="Exception">Excecao generica lancada para outros erros nao especificados.</exception>
        public static Registo CarregarDados(string caminho)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    Stream stream = File.Open(caminho, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    return (Registo)bin.Deserialize(stream);
                }
                return null;
            }
            catch (ExcecaoFicheiroCarregar)
            {
                throw new ExcecaoFicheiroGuardar();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}