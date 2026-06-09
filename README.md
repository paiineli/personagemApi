<p align="center">
  <b>character api</b>
</p>

<p align="center">
  a small .net minimal api for managing rpg characters and their classes.<br>
  built as a training exercise, kept clean enough to read.
</p>

---

**// architecture**

a single web project organized by responsibility: minimal api endpoints, a repository behind an interface for data access, dtos for the request and response shapes, and a thin connection factory wired through dependency injection. endpoints depend only on the repository interface.

- repository pattern over raw sql, no orm
- dtos decouple the api contract from the database columns
- every database call is wrapped with structured logging and surfaced as a proper http result
- interactive api docs served through scalar at `/scalar/v1`

**// stack**

`.NET 10` · `Minimal APIs` · `C#`<br>
`Oracle` · `Dapper` · `Oracle.ManagedDataAccess`<br>
`OpenAPI` · `Scalar`

**// under the hood**

- **data** raw parametrized sql over dapper on oracle, joining characters to their class
- **filters** the search endpoint composes its where clause dynamically from optional id and name filters
- **mapping** column aliases line up with the dto constructor so dapper can bind by name
- **docs** openapi document generated at build time and rendered by scalar in development

**// endpoints**

| method | route | action |
|--------|-------|--------|
| `GET` | `/api/character/get-all` | list every character with its class name |
| `GET` | `/api/character/search` | list characters filtered by id, class or name |
| `POST` | `/api/character/create` | create a new character |
| `PUT` | `/api/character/update/{characterId}` | update a character's level or class |
| `DELETE` | `/api/character/delete/{characterId}` | delete a single character |

**// schema**

```sql
SELECT CD_PERSONAGEM, CD_CLASSE, NM_PERSONAGEM, NR_NIVEL FROM TESTE_PERSONAGEM;

SELECT CD_CLASSE, NM_CLASSE FROM TESTE_CLASSE;
```
