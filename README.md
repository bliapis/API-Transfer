# API-Transfer
Essa API foi desenvolvida para um teste, onde o objetivo é aplicar microservices para realizar lançamentos de transferencia entre
contas bancárias.

Principais tecnologias utilizadas: .Net Core, Docker, RabbitMQ e MongoDB.

Muitos conceitos foram simplificados nessa API devido ao tempo para desenvolvimento, principalmente a separação de camadas onde
gostaria de separar projetos como Domain, Infra, CrossCutting para realizar diversas atividades como IoC, entre outros.

## Como Executar
 - Clonar o repositório
 - Baixar as bibliotecas
 - Instalar o docker
 - Subir:
   -- Docker
      --- RabbitMQ
      --- MongoDb
   -- Aplicação
      --- Transfer.WebAPI
      --- Transfer.Services.Lancamentos

#### Serviços inicializados
![alt text](https://i.ibb.co/stDK29m/inicializado.png)

#### Chamada para adicionar lançamento
![alt text](http://url/to/img.png)

#### Resultado no Mongo
![alt text](http://url/to/img.png)

#### Exemplo de chamada passando uma conta inexistente
![alt text](http://url/to/img.png)

# Perguntas
1) EXPLIQUE COM SUAS PALAVRAS O QUE É DOMAIN DRIVEN DESIGN E SUA IMPORTÂNCIA
NA ESTRATÉGIA DE DESENVOLVIMENTO DE SOFTWARE.
R. É uma abordagem para desenvolvimento de software voltado para aplicações grandes e complexas,
permitindo um modelo de arquitetura onde sempre é possível evoluir tanto a parte técnica implementando
novas tecnologias, quanto a parte de negócio, uma vez que "dividimos" todo o negócio do cliente no design
de dominios, gerando um código mais organizado, desacoplado, focado no negócio do cliente, de fácil manutenção e permitindo que
várias equipes e/ou devs trabalharem na mesma aplicação sem grandes problemas.

2) EXPLIQUE COM SUAS PALAVRAS O QUE É E COMO FUNCIONA UMA ARQUITETURA BASEADA
EM MICROSERVICES. EXPLIQUE GANHOS COM ESTE MODELO E DESAFIOS EM SUA
IMPLEMENTAÇÃO.
R. Com uma arquitetura baseada em microservices, dividimos cada "operação", cada ação do business do cliente em pequenos serviços,
independentes e que se comunicam para esecutar as tarefas das aplicações. Os ganhos aplicando microservices são permitir que a aplicação
seja escalável, fácil manutenção, redução de custos uma vez que posso escalar os serviços de acordo com a necessidade e não
a aplicação como um todo, baixo acoplamento permitindo migrar de tecnologia se necessário e a facilidade no deploy uma vez que posso
realizar o deploy de acordo com a demanda/serviço. Os desafios em sua implementação acredito que estão mais relacionados a organização,
uma vez que quanto mais serviços nascem, mais fácil de perder o controle e começar criar serviços desnecessário e/ou que fazem a mesma
operação.

3) EXPLIQUE QUAL A DIFERENÇA ENTRE COMUNICAÇÃO SINCRONA E ASSINCRONA E QUAL O
MELHOR CENÁRIO PARA UTILIZAR UMA OU OUTRA.
A comunicação sincrona faz com que o sistema remetente fique bloqueado até que eu tenha uma resposta, fazendo com que minha 
aplicação fique "parada". Já com chamadas assincronas consigo enviar diversas requisições e quando as mesmas estiverem prontas,
serão retornadas, o que me permite disponibilizar uma experiência mais fluída ao meu usuário.

Um bom cenário para utilizar uma chamada sincrona seria no login, pois quero essa resposta imediatamente, para liberar ao usuário
o acesso a certo conteúdo. Já uma chamada assincrona eu poderia utilizar na exibição de notificações.
