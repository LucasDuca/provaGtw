# Este projeto foi desenvolvido utilizando NetCore 2.0. 
<br>
Utilizaremos o Swagger para realizar as operações de transações e consultas.<br>

Requisitos<br> 
Mysql Server > 5.0<br>
<a href="https://download.microsoft.com/download/4/0/9/40920432-3302-47a8-b13c-bbc4848ad114/dotnet-sdk-2.1.302-win-x64.exe">Dotnet Ef</a> <br>

Modelo Mer<br>
![alt text](https://imageshack.com/a/img923/507/3Hrbq5.png)
<br>

[Configuração]<br>
1° - Abrir o powershell<br>
2° - cd c:/seu_caminho_do_clone/diretorio_do_csproj<br>
3° - No diretório da aplicação executar o comando para gerar o banco de dados <br>

<b>dotnet ef database update -s  ./../duca_gateway</b><br>

Database Migrada[ok]!<br>

Ainda no mesmo powershell, dentro do diretório do projeto<br>
execute os seguintes comandos para iniciar a aplicação<br>
<b>
  dotnet build <br>
  dotnet run
</b>
<br>
Exibira seu endereço de acesso<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/923/s7TmNu.png)

Copie o endereço de acesso e cole no navegador<br>
<b>http://localhost:4541/swagger/index.html</b><br>


Usaremos o swagger para adicionar o Lojista e sua respectiva configuração<br>
- Adicionar Lojista<br>
Seguindo as especificações da Microsoft REST API Guidelines, os cadastros foram feitos dentro de um post, retornando seu insert.<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/921/Kfg8LW.png)

Clicar em Try Out<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/923/jkkMFu.png)

Copiar JSON e substituir:<br>
<br>
{
  "idLojista": 0,
  "razaosocial": "Tester Man",
  "login": "duca",
  "senha": "123"
}

![alt text](https://imagizer.imageshack.com/v2/1024x768q90/923/0qDv1p.png)
Clicar em Execute
<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/924/xlc2tH.png)
Response Retornado<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/921/jDsbhi.png)

<br>
<br>

Inserindo a configuração:<br>
Copiar JSON e substituir:<br>
<br>
{
  "idConfiguracao": 0,
  "idLojista": 1,
  "stone": "S",
  "cielo": "S",
  "antifraude": "S",
  "ruleVisa": "S",
  "ruleMaster": "C",
  "stonekey": "F2A1F485-CFD4-49F5-8862-0EBC438AE923",
  "cielokey": ""
} <br><br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/922/hgHSao.png)
Executar<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/923/2DR9BV.png)
<br>
Obs: os campos ruleVisa e ruleMaster definem por qual adiquirente vai passar a transação: [S = Stone. C = Cielo]<br>
nos campos stone e cielo definimos qual adiquirente esta habilitado S(im) ou N(ão) ) <br>

Feita a configuração vamos adicionar Transações:

Para simular um erro de Sales Force, basta deixar o parâmetro CreditCard vazio<br>
Para simular um erro do adiquirente, basta deixar o merchant-key(na configuração do banco de dados...) vazio<br>

Copiar JSON e substituir:<br>
<br>

{
  "idTransacao": 0,
  "idLojista": 1,
  "descricao": "Compra de Teste",
  "valor": 10000,
  "cielo": "",
  "stone": "S",
  "visa": "S",
  "master": "",
  "creditCard": "4500746091866249"
}
<br>

![alt text](https://imageshack.com/a/img923/434/fwalSv.png)
Executar<br>
![alt text](https://imagizer.imageshack.com/v2/1024x768q90/923/2DR9BV.png)

Response da Transação
![alt text](https://imageshack.com/a/img924/9532/lNbGvY.png)

<br>
 
Consultando Transação do Lojista <br>

![alt text](https://imageshack.com/a/img922/2820/T8Ir9Y.png)

O retorno é exibido abaixo do execute. <br>
![alt text](https://imageshack.com/a/img923/9977/LwgBHS.png)

<br>






