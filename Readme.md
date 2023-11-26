
# Camada AdmBoaFe.Api

A camada `AdmBoaFe.Api` é responsável por lidar com todas as questões relacionadas à interface da sua aplicação com o mundo externo, ou seja, a interface de programação de aplicações (API). Abaixo estão os principais componentes desta camada, com base nas imagens que você compartilhou:

## Dependências (Dependencies)

Aqui estão listadas as dependências externas que o projeto `AdmBoaFe.Api` utiliza. Isso inclui bibliotecas, frameworks e pacotes NuGet que fornecem funcionalidades adicionais à sua API.

## Configuration

Esta pasta contém classes de configuração específicas que ajudam a organizar o código relacionado à configuração de diferentes aspectos da API, como:

- `ApiConfig.cs`: Configurações relacionadas à própria API, como CORS (Cross-Origin Resource Sharing), formatação de resposta, compressão de resposta, configuração de versionamento da API e middlewares específicos para tratamento de erros e outras configurações de pipeline.

- `AutomapperConfig.cs`: Configuração do AutoMapper, uma ferramenta para mapear automaticamente entre objetos, frequentemente usada para mapear dados entre camadas de domínio e de aplicação.

- `DependencyInjectionConfig.cs`: Configurações para a injeção de dependências, uma técnica de design de software que ajuda a tornar o código mais modular e testável.

- `IdentityConfig.cs`: Configurações relacionadas ao sistema de identidade, provavelmente usado para autenticação e autorização de usuários.

- `LoggerConfig.cs`: Configurações do sistema de log, para registrar mensagens que ajudam no diagnóstico e na compreensão do comportamento da aplicação.

- `SwaggerConfig.cs`: Configurações para o Swagger, uma ferramenta usada para descrever e documentar a API de forma interativa.

## Controllers

Contém os controladores, que são classes responsáveis por manipular as requisições HTTP. Cada controlador geralmente gerencia um conjunto de ações relacionadas a um aspecto específico da API.

## Data

Inclui classes relacionadas ao acesso e manipulação de dados, como o `ApplicationDbContext`, que é uma classe do Entity Framework que gerencia o mapeamento de objetos para o banco de dados.

## Extensions

Contém métodos de extensão ou classes auxiliares que adicionam funcionalidades específicas ou configuram aspectos da API.


## V1/V2

Diretórios que sugerem uma estrutura de versionamento para a API. Você pode ter diferentes versões da API com diferentes controladores ou comportamentos, permitindo que mudanças sejam feitas sem quebrar a compatibilidade com clientes que utilizam versões antigas.

## ViewModels (Versionamento)

A pasta `ViewModels` contém modelos de visualização que são usados para passar dados entre os controladores e as views ou, no caso de uma API, formatar a resposta que será enviada ao cliente. O versionamento das ViewModels é uma prática que ajuda a manter a compatibilidade com clientes existentes e a evoluir a estrutura dos dados à medida que a API evolui.

- `V1`: Nesta subpasta, você encontrará as ViewModels relacionadas à versão 1 da sua API. Essas ViewModels podem ter estruturas de dados específicas para a primeira versão da API.

- `V2`: Na subpasta `V2`, estão as ViewModels relacionadas à versão 2 da API. À medida que sua API evolui e novos campos ou estruturas de dados são adicionados às respostas da API, essas novas versões de ViewModels são criadas.

O versionamento das ViewModels permite que os clientes da API escolham a versão de dados com a qual desejam trabalhar. Isso é útil quando você precisa adicionar ou modificar campos de dados nas respostas da API sem afetar os clientes existentes.

## appsettings.json

Arquivos de configuração que contêm parâmetros e configurações, como strings de conexão de banco de dados, configurações de ambiente e outras constantes necessárias para a aplicação.

## Dockerfile

Se você estiver usando contêineres Docker, este arquivo contém as instruções para criar uma imagem Docker para a sua API.

## Program.cs

O ponto de entrada da aplicação que configura o host da web e o pipeline de processamento de requisições HTTP.

## Princípios SOLID, Padrão Observer e Separação em Camadas

A camada `AdmBoaFe.Api` foi projetada com base nos princípios SOLID, na implementação do padrão Observer para notificação de erros e na estrutura de separação em camadas. Vamos entender como esses conceitos são aplicados:

### Princípios SOLID

Os princípios SOLID são diretrizes de design de software que promovem a criação de código limpo, flexível e de fácil manutenção. Na camada `AdmBoaFe.Api`, você encontrará exemplos dos seguintes princípios:

- **Single Responsibility Principle (SRP)**: Cada classe e componente tem uma única responsabilidade bem definida. Por exemplo, os controladores têm a responsabilidade de lidar com requisições HTTP, enquanto as classes de configuração têm a responsabilidade de configurar a aplicação.

- **Open/Closed Principle (OCP)**: A camada está aberta para extensão, mas fechada para modificação. Isso significa que você pode adicionar novos recursos (novos controladores, serviços, etc.) sem precisar modificar o código existente.

- **Dependency Inversion Principle (DIP)**: A injeção de dependências é amplamente utilizada na camada, permitindo que as dependências sejam injetadas em vez de criadas dentro das classes. Isso torna o código mais modular e facilita os testes unitários.

### Padrão Observer para Notificação de Erros

O padrão Observer é aplicado na classe `Notificador`. Ela desempenha o papel de um observável que notifica outros componentes do sistema sobre eventos ou erros relevantes. Quando ocorrem eventos ou erros, como validações de dados, exceções ou outros eventos personalizados, o `Notificador` notifica automaticamente outras partes do sistema que desejam ser informadas. Isso promove o desacoplamento entre as partes do sistema e facilita a extensibilidade.

### Separação em Camadas

A camada `AdmBoaFe.Api` segue uma estrutura de separação em camadas, o que significa que diferentes responsabilidades são agrupadas em camadas específicas. Essa separação promove a organização, a manutenção e a escalabilidade do código. Aqui estão algumas das camadas utilizadas:

- **Camada de Apresentação (Controllers)**: Responsável por lidar com as requisições HTTP e controlar o fluxo da aplicação.

- **Camada de Aplicação (Services)**: Responsável por conter a lógica de negócios e orquestrar as operações da aplicação.

- **Camada de Infraestrutura (Data, Configuration, Extensions)**: Responsável por configurar e fornecer recursos de infraestrutura, como acesso a dados, injeção de dependências, configuração da API e extensões úteis.

Essa estrutura em camadas permite que cada parte da aplicação tenha uma responsabilidade bem definida, tornando-a mais fácil de entender, manter e escalar.

A combinação desses conceitos resulta em uma camada `AdmBoaFe.Api` que é robusta, flexível e aderente a boas práticas de design de software, promovendo a qualidade do código e a facilidade de evolução da aplicação.
