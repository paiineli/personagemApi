using PersonagemApi.DTOs;

namespace PersonagemApi.Repositories
{
    public interface IPersonagemREP
    {
        #region buscar

        public Task<List<PersonagemDTO>> BuscarTodosPersonagensAsync();

        public Task<List<PersonagemDTO>> BuscarPersonagensComFiltrosAsync(int? cdPersonagem, int? cdClasse, string? nmPersonagem);

        #endregion

        #region criar

        public Task CriarPersonagemAsync(CriarPersonagemDTO criarPersonagemDTO);

        #endregion

        #region atualizar

        Task<int> AtualizarPersonagemAsync(int cdPersonagem, AtualizarPersonagemDTO atualizarPersonagemDTO);

        #endregion

        #region excluir

        Task<int> ExcluirPersonagemAsync(int cdPersonagem);

        #endregion
    }
}
