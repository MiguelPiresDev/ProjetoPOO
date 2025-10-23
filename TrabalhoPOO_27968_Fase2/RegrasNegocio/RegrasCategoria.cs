using ObjetosNegocio;
using TratamentoErros;
using Dados;
using System;

/// <summary>
/// Autor: José Miguel Pires - 27968
/// Data: 2024-12-18
/// Instituto: IPCA
/// </summary>

namespace RegrasNegocio
{
    /// <summary>
    /// Classe que define as regras relacionadas às categorias, incluindo criação, remoção e consulta de stock.
    /// </summary>
    public static class RegrasCategoria
    {
        /// <summary>
        /// Cria uma nova categoria com o nome e a quantidade especificados, se o nome for válido.
        /// </summary>
        /// <param name="nome">Nome da categoria (deve começar com uma letra maiúscula).</param>
        /// <param name="quant">Quantidade inicial atribuída à categoria.</param>
        /// <returns>Uma nova instância de Categoria se os parâmetros forem válidos; caso contrário, null.</returns>
        /// <exception cref="ArgumentException">Lançada se os argumentos fornecidos forem inválidos.</exception>
        /// <exception cref="Exception">Lançada para erros inesperados durante a criação da categoria.</exception>
        public static Categoria TentarCriarCategoria(string nome, int quant)
        {
            if (char.IsUpper(nome[0]))
            {
                try
                {
                    Categoria novaCategoria = Categoria.CriaCategoria(nome, quant);
                    return novaCategoria;
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
            return null;
        }

        /// <summary>
        /// Insere uma categoria na lista de categorias existentes, caso seja válida.
        /// </summary>
        /// <param name="categoria">Objeto Categoria a ser inserido na lista.</param>
        /// <returns>True se a inserção for bem-sucedida; caso contrário, False.</returns>
        /// <exception cref="Exception">Lançada para erros inesperados durante a inserção.</exception>
        public static bool TentaInserirLista(Categoria categoria)
        {
            if (categoria == null) return false;

            try
            {
                bool verificar = Categorias.AdicionarCategoria(categoria);
                return verificar;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        /// <summary>
        /// Metodo que tenta remover uma categoria com base no nome fornecido.
        /// </summary>
        /// <param name="nome">Nome da categoria a ser removida.</param>
        /// <returns>Retorna true se a remocao da categoria for bem-sucedida, ou false se a categoria nao existir.</returns>
        /// <exception cref="Exception">Lanca uma excecao generica caso ocorra um erro durante a remocao.</exception>
        public static bool TentaRemoverCategoria(string nome)
        {
            if (!Categorias.ExisteCategoria(nome)) return false;

            try
            {
                bool verificar = Categorias.RemoverCategoria(nome);
                return verificar;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Verifica o stock total e retorna um valor baseado no limite mínimo.
        /// </summary>
        /// <returns>0 se o stock total for menor que 30; caso contrário, retorna o valor do stock.</returns>
        public static int PedeStock()
        {
            int valor;
            valor = Categorias.Stock();

            if (valor < 30)
                return 0;

            return valor;
        }
    }
}
