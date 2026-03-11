using Dapper;
using PersonagemApi.Data;
using PersonagemApi.DTOs;

namespace PersonagemApi.Repositories
{
    public class PersonagemREP(ConexaoBanco conexaoBanco, ILogger<PersonagemREP> logger) : IPersonagemREP
    {
        #region buscar

        // coloquei alias pq o dapper espera o construtor pelo nome do parâmetro, sem o alias, o dapper não consegue acessar por causa do underscore
        public async Task<List<PersonagemDTO>> BuscarTodosPersonagensAsync()
        {
            try
            {
                using var connection = conexaoBanco.CreateConnection();

                var query = @"SELECT X.CD_PERSONAGEM CdPersonagem,
                                            X.CD_CLASSE CdClasse,
                                            X.NM_PERSONAGEM NmPersonagem,
                                            X.NR_NIVEL NrNivel,
                                            X.DT_CADASTRO DtCadastro,
                                            Z.NM_CLASSE NmClasse
                                        FROM TESTE_PERSONAGEM X, TESTE_CLASSE Z
                                        WHERE 1 = 1
                                        AND X.CD_CLASSE = Z.CD_CLASSE";

                var result = await connection.QueryAsync<PersonagemDTO>(query);

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao buscar todos os personagens.");
                throw;
            }
        }

        // coloquei alias pq o dapper espera o construtor pelo nome do parâmetro, sem o alias, o dapper não consegue acessar por causa do underscore
        public async Task<List<PersonagemDTO>> BuscarPersonagensComFiltrosAsync(int? cdPersonagem, int? cdClasse, string? nmPersonagem)
        {
            try
            {
                using var connection = conexaoBanco.CreateConnection();

                var parametros = new DynamicParameters();

                var query = @"SELECT X.CD_PERSONAGEM CdPersonagem,
                                            X.CD_CLASSE CdClasse,
                                            X.NM_PERSONAGEM NmPersonagem,
                                            X.NR_NIVEL NrNivel,
                                            X.DT_CADASTRO DtCadastro,
                                            Z.NM_CLASSE NmClasse
                                        FROM TESTE_PERSONAGEM X, TESTE_CLASSE Z
                                        WHERE 1 = 1
                                        AND X.CD_CLASSE = Z.CD_CLASSE";

                if (cdPersonagem.HasValue)
                {
                    query += @" AND X.CD_PERSONAGEM = :CdPersonagem";
                    parametros.Add(":CdPersonagem", cdPersonagem);
                }

                if (cdClasse.HasValue)
                {
                    query += @" AND X.CD_CLASSE = :CdClasse";
                    parametros.Add(":CdClasse", cdClasse);
                }

                if (!string.IsNullOrEmpty(nmPersonagem))
                {
                    query += @" AND UPPER(X.NM_PERSONAGEM) LIKE UPPER(:NmPersonagem)";
                    parametros.Add(":NmPersonagem", $"%{nmPersonagem}%");
                }

                var result = await connection.QueryAsync<PersonagemDTO>(query, parametros);

                return result.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao buscar personagens com filtros.");
                throw;
            }
        }

        #endregion

        #region criar

        public async Task CriarPersonagemAsync(CriarPersonagemDTO criarPersonagemDTO)
        {
            try
            {
                using var connection = conexaoBanco.CreateConnection();

                var query = @"INSERT INTO TESTE_PERSONAGEM (CD_CLASSE, NM_PERSONAGEM, NR_NIVEL)
                                    VALUES (:CdClasse, :NmPersonagem, :NrNivel)";

                var parametros = new DynamicParameters();

                parametros.Add(":CdClasse", criarPersonagemDTO.CdClasse);
                parametros.Add(":NmPersonagem", criarPersonagemDTO.NmPersonagem);
                parametros.Add(":NrNivel", criarPersonagemDTO.NrNivel);

                await connection.ExecuteAsync(query, parametros);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao criar personagem.");
                throw;
            }
        }

        #endregion

        #region atualizar

        public async Task<int> AtualizarPersonagemAsync(int cdPersonagem, AtualizarPersonagemDTO atualizarPersonagem)
        {
            try
            {
                using var connection = conexaoBanco.CreateConnection();

                var query = @"UPDATE TESTE_PERSONAGEM
                                    SET NR_NIVEL = :NrNivel, CD_CLASSE = :CdClasse
                                    WHERE CD_PERSONAGEM = :CdPersonagem";

                var parametros = new DynamicParameters();

                parametros.Add(":CdClasse", atualizarPersonagem.CdClasse);
                parametros.Add(":NrNivel", atualizarPersonagem.NrNivel);
                parametros.Add(":CdPersonagem", cdPersonagem);

                return await connection.ExecuteAsync(query, parametros);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao atualizar personagem {CdPersonagem}.", cdPersonagem);
                throw;
            }
        }

        #endregion

        #region excluir

        public async Task<int> ExcluirPersonagemAsync(int cdPersonagem)
        {
            try
            {
                using var connection = conexaoBanco.CreateConnection();

                var query = @"DELETE FROM TESTE_PERSONAGEM
                                    WHERE CD_PERSONAGEM = :CdPersonagem";

                var parametros = new DynamicParameters();
                parametros.Add(":CdPersonagem", cdPersonagem);

                return await connection.ExecuteAsync(query, parametros);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao excluir personagem {CdPersonagem}.", cdPersonagem);
                throw;
            }
        }

        #endregion
    }
}
