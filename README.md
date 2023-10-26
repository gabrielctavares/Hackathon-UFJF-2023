
# Hackathon UFJF 2023

Esse projeto tem como função a geração de código para persistência de dados com uso da ODL


## Requisitos

* .NET 7.0 
* Docker

## Instruções de inicialização

Baixe a imagem do SQL Server

```bash
  docker pull mcr.microsoft.com/mssql/server
```
Execute o container

```bash
  docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=@202265163AB!" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

Inicie o gerador de códigos

```bash
  cd ./CodeGeneratorHackathon/  
```

```bash
  dotnet run
```


## Documentação da API

#### Retorna todos os itens

```https
  GET /api/[Entidade]
```


#### Retorna um item

```https
  GET /api/[Entidade]/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer |

#### Cadastra um item
```https
  POST /api/[Entidade]
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Objeto`      | `[Entidade]` | **Obrigatório**. O objeto a ser cadastrado |

#### Edita um item
```https
  POST /api/[Entidade]/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você editar |
| `Objeto`      | `[Entidade]` | **Obrigatório**. O objeto a ser editado  |

#### Edita um item
```https
  DELETE /api/[Entidade]/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você deletar |

## Stack utilizada

**Front-end:** Razor Pages, Bootstrap;

**Back-end:** ASP.NET;

