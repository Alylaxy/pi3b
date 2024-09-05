# Documentação de como usar a API para participar do desafio

## Endpoints

### POST "/grupo"
#### Endpoint para cadastrar o grupo.
#### Body:
  ```JSON
    {
        "Nome" : "[Nome do Grupo]"
    }
  ```
#### Response:
  ```JSON
    {
        "Id" : "3F4365C5-77F1-405E-A6F2-66BE20521A40"
    }
  ```
### GET "/iniciar/{Id}"
#### Endpoint para começar o desafio para percorrer o labirinto.
#### Request Params:
    "3F4365C5-77F1-405E-A6F2-66BE20521A40"
#### Response:
  ```JSON
  {
    "Conexao" : "http://link.pro.handshake.inicial/"
  }
  ```

### GET "/labirintos/{Id}"
#### Retorna todos os labirintos disponíveis com dados do grupo escolhido.
#### Request Params:
    "3F4365C5-77F1-405E-A6F2-66BE20521A40"
#### Response:
  ```JSON
  {
    "Labirintos" : [
      {
        "Id" : 0,
        "Dificuldade" : "TesteAqui",
        "Completo" : false,
        "Passos" : 0,
        "Exploracao" : 0.0
      },
      {
        "Id" : 1,
        "Dificuldade" : "ChoreAqui",
        "Completo" : true,
        "Passos" : 8272,
        "Exploracao" : 0.1
      },
      {
        "Id" : 2,
        "Dificuldade" : "PisouNoLego",
        "Completo" : false,
        "Passos" : 40,
        "Exploracao" : 0.001
      }
    ]
  }
  ```

### GET listar todas as sessões WS armazenadas.
  
  