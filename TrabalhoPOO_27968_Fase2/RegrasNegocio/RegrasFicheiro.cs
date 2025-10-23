using ObjetosNegocio;
using TratamentoErros;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegrasNegocio
{
    /// <summary>
    /// Classe que contem as regras de negocio para o tratamento de ficheiros.
    /// </summary>
    public class RegrasFicheiro
    {
        /// <summary>
        /// Metodo que tenta carregar os dados de um ficheiro especificado.
        /// </summary>
        /// <param name="caminho">Caminho do ficheiro a carregar.</param>
        /// <returns>Retorna true se os dados forem carregados com sucesso, ou false se o caminho for invalido ou ocorrer um erro.</returns>
        /// <exception cref="ExcecaoFicheiroGuardar">Lanca uma excecao caso ocorra um erro ao guardar os dados apos o carregamento.</exception>
        /// <exception cref="Exception">Lanca uma excecao generica para outros erros durante o carregamento.</exception>
        public static bool TentaCarregarFicheiro(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho)) return false;

            try
            {
                Registo dados = TratamentoFicheiro.CarregarDados(caminho);
                Registo.AdicionarDados(dados);
            }
            catch (ExcecaoFicheiroGuardar)
            {
                throw new ExcecaoFicheiroGuardar();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return true;
        }

        /// <summary>
        /// Metodo que tenta guardar os dados num ficheiro especificado.
        /// </summary>
        /// <param name="caminho">Caminho onde o ficheiro sera guardado.</param>
        /// <returns>Retorna true se os dados forem guardados com sucesso, ou false se o caminho for invalido ou ocorrer um erro.</returns>
        /// <exception cref="ExcecaoFicheiroCarregar">Lanca uma excecao caso ocorra um erro ao carregar os dados antes de guardar.</exception>
        /// <exception cref="Exception">Lanca uma excecao generica para outros erros durante o processo de gravacao.</exception>
        public static bool TentaGuardarFicheiro(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho)) return false;

            try
            {
                Registo dados = Registo.GuardarDados();
                TratamentoFicheiro.GuardarDados(caminho, dados);
            }
            catch (ExcecaoFicheiroCarregar)
            {
                throw new ExcecaoFicheiroCarregar();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }
    }
}