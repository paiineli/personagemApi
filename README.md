# Desafio

Exercício de fixação do treinamento. Deve ser construída uma API com .NET, versão e modelo a critério do dev.

A API deve conter ao menos 5 endpoints listados abaixo e permitir gerar as ações listadas a frente da tabela.

## Tabelas

```sql
SELECT CD_PERSONAGEM, CD_CLASSE, NM_PERSONAGEM, NR_NIVEL FROM TESTE_PERSONAGEM;

SELECT CD_CLASSE, NM_CLASSE FROM TESTE_CLASSE;
```

## Endpoints

| Endpoint | Ação |
|----------|------|
| PERSONAGEM/BUSCAR | Buscar todos os personagens da base * |
| PERSONAGEM/BUSCARCOMFILTRO | Buscar todos os personagens com filtros de códigos ou de nome * |
| PERSONAGEM/CADASTRAR | Cadastrar um novo personagem |
| PERSONAGEM/ATUALIZAR | Atualizar nível ou classe do personagem |
| PERSONAGEM/EXCLUIR | Excluir 1 personagem |

*dados do personagem + nome da classe

## Stacks desse Projeto

- .NET 10 (Minimal APIs)
- Dapper
- Oracle.ManagedDataAccess
