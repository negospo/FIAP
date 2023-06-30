<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>FIAP Application</title>
</head>
<body>
    <h1>FIAP Application</h1>
    <p>Este repositório contém a aplicação FIAP, que é um sistema de gerenciamento XYZ. A aplicação é hospedada e versionada neste repositório do GitHub e é facilmente executada através do Docker Compose.</p>

    <h2>Pré-requisitos</h2>
    <ul>
        <li><a href="https://docs.docker.com/engine/install/">Docker</a></li>
        <li><a href="https://docs.docker.com/compose/install/">Docker Compose</a></li>
    </ul>

    <h2>Como usar</h2>
    <p>Siga as etapas abaixo para clonar e executar a aplicação:</p>

    <h3>1. Clonar o Repositório</h3>
    <p>Primeiro, clone o repositório do GitHub para a sua máquina local usando o seguinte comando:</p>
    <pre><code>git clone https://github.com/negospo/FIAP.git</code></pre>

    <h3>2. Navegar até o Diretório do Projeto</h3>
    <p>Em seguida, navegue até o diretório do projeto que você acabou de clonar:</p>
    <pre><code>cd FIAP</code></pre>

    <h3>3. Executar a Aplicação</h3>
    <p>Agora, você pode executar a aplicação usando o Docker Compose com o seguinte comando:</p>
    <pre><code>docker-compose up</code></pre>
    <p>A aplicação agora deve estar rodando em <code>localhost</code> na porta definida em seu arquivo <code>docker-compose.yml</code>.</p>
    
</body>
</html>