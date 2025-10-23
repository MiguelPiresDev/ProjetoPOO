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
    /// Classe com regras para gerir campanha.
    /// </summary>
    public static class RegrasCampanha
    {
        #region Metodos
        /// <summary>
        /// Tenta criar e inserir uma nova campanha na lista de campanhas.
        /// Lanca uma excecao se ocorrer um erro durante a criacao ou insercao da campanha.
        /// </summary>
        /// <param name="n">Nome da campanha.</param>
        /// <param name="dataI">Data inicial da campanha.</param>
        /// <param name="dataF">Data final da campanha.</param>
        /// <param name="descricao">Descricao da campanha.</param>
        /// <returns>True se a campanha foi criada e inserida com sucesso; caso contrario, False.</returns>
        /// <exception cref="ArgumentException">Lancada se os argumentos fornecidos forem invalidos.</exception>
        /// <exception cref="Exception">Lancada para outros erros durante a execucao.</exception>
        public static bool TentaCriarInserirCampanha(string n, DateTime dataI, DateTime dataF, string descricao)
        {
            if (dataI == null || dataF == null) return false;
            try
            {
                Campanha campanha = Campanha.CriaCampanha(n, dataI, dataF, descricao);
                bool verifica = Campanhas.AdicionarCampanha(campanha);
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

        /// <summary>
        /// Tenta remover uma campanha da lista pelo ID.
        /// Lanca uma excecao se ocorrer um erro durante a remocao.
        /// </summary>
        /// <param name="idCampanha">ID da campanha a ser removida.</param>
        /// <returns>True se a campanha foi removida com sucesso; caso contrario, False.</returns>
        /// <exception cref="Exception">Lancada se ocorrer um erro durante a remocao da campanha.</exception>
        public static bool TentaRemoverCampanha(int idCampanha)
        {
            if (idCampanha <= 0) return false;
            try
            {
                bool verifica = Campanhas.RemoverCampanha(idCampanha);
                return verifica;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Tenta alterar a data de inicio e termino de uma campanha.
        /// </summary>
        /// <param name="idCampanha">ID da campanha.</param>
        /// <param name="dataInicio">Nova data de inicio.</param>
        /// <param name="dataFim">Nova data de termino.</param>
        /// <returns>True se a alteracao foi bem-sucedida; caso contrario, False.</returns>
        public static bool TentaAlterarData(int idCampanha, DateTime dataInicio, DateTime dataFim)
        {
            if (idCampanha <= 0) return false;

            if (!Campanhas.ExisteCampanha(idCampanha)) return false;
            if (dataInicio == null || dataFim == null || dataInicio > dataFim) return false;

            Campanha campanha = Campanhas.EncontrarCampanha(idCampanha);
            if (campanha == null) return false;

            campanha.DataFinal = dataFim;
            campanha.DataInicial = dataInicio;
            return true;
        }

        /// <summary>
        /// Tenta aplicar uma oferta vinculada a uma campanha numa compra.
        /// </summary>
        /// <param name="idCampanha">ID da campanha.</param>
        /// <param name="idCompra">ID da compra.</param>
        /// <returns>True se a oferta foi aplicada com sucesso; caso contrario, False.</returns>
        public static bool TentaAplicarOferta(int idCampanha, int idCompra)
        {
            if (Campanhas.ExisteCampanha(idCampanha))
            {
                Campanha campanha = Campanhas.EncontrarCampanha(idCampanha);

                if (DateTime.Now < campanha.DataInicial || DateTime.Now > campanha.DataFinal)
                    return false;

                int contadorSup600 = 0;
                List<Produto> produtosCompra = Carrinhos.EncontraProdutosCompra(idCompra);

                foreach (Produto produto in produtosCompra)
                {
                    //Conta quantos produtos tem valor superior a 600
                    if (produto.Preco > 600)
                    {
                        contadorSup600++;
                    }

                    //se comprar 3 ou mais produtos, e o valor de dois deles forem superior a 600, recebe produtoGratuito
                    if (contadorSup600 > 1 && produtosCompra.Count > 2)
                    {
                        Produto produtoGratuito = Produto.CriaProduto("Produto Gratuito", "", "", "", 1, 0);

                        produtosCompra.Add(produtoGratuito);
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Tenta aplicar um desconto a uma compra, considerando uma campanha.
        /// </summary>
        /// <param name="idCampanha">ID da campanha.</param>
        /// <param name="Desconto">Percentual de desconto a ser aplicado.</param>
        /// <param name="idCompra">ID da compra.</param>
        /// <returns>O valor final da compra apos o desconto.</returns>
        public static double TentaAplicarDesconto(int idCampanha, int Desconto, int idCompra)
        {
            if (Campanhas.ExisteCampanha(idCampanha))
            {
                Campanha campanha = Campanhas.EncontrarCampanha(idCampanha);
                
                if (DateTime.Now < campanha.DataInicial || DateTime.Now > campanha.DataFinal)
                    return RegrasCompra.ValorPagar(idCompra);

                double total = RegrasCompra.ValorPagar(idCompra);
                if (total < 1500) return RegrasCompra.ValorPagar(idCompra);

                total = RegrasCompra.ValorPagar(idCompra) - RegrasCompra.ValorPagar(idCompra) * Desconto / 100;
                return total;
            }
            return RegrasCompra.ValorPagar(idCompra);
        }
        #endregion
    }
}
