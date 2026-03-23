# JotaSystem.Sdk.Common

Biblioteca de utilidades compartilhadas da **Jota System** para aplicações .NET.

## Descrição

O `JotaSystem.Sdk.Common` concentra recursos reutilizáveis de baixo nível que podem ser consumidos por outros SDKs e aplicações da empresa.

Hoje o pacote contém principalmente:

- `Constants` com padrões de datas, regex, claims, máscaras e códigos de status.
- `Enums` de uso transversal, como status, tipos de pessoa, escopo de acesso, tipo de empresa, perfil de usuário, estoque, pedidos, produtos e documentos.
- `Extensions` para tipos comuns, incluindo `string`, `DateTime`, `bool`, `object`, `collection`, `task`, `http` e `json`.
- `Helpers` para operações práticas, como CSV, validação e formatação de CPF/CNPJ, senha, privacidade, arquivos, e-mail, JSON e URL.
- `Models` simples de apoio, como mensagens de chat.

## Perfil do pacote

Este SDK é a base utilitária do ecossistema Jota System. Ele não define regras de domínio nem integrações externas; o foco é reuso de código e padronização técnica.
