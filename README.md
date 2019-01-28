# Movies Cup

Projeto de exemplo feito com ASP.NET Core e Xamarin.Forms.

## API

A [API](http://movies-cup.azurewebsites.net/api/values) possui três Controllers:

* [ValuesController](https://github.com/lucasfcoelho1/movies-cup/blob/master/MoviesCupApi/MoviesCupApi/Controllers/ValuesController.cs), com um método GET de teste:

### [GET]
```
http://movies-cup.azurewebsites.net/api/values
```

* [MoviesController](https://github.com/lucasfcoelho1/movies-cup/blob/master/MoviesCupApi/MoviesCupApi/Controllers/MoviesController.cs), com um método GET que 
retorna todos os filmes:

### [GET]
```
http://movies-cup.azurewebsites.net/api/movies/getall
```

* [CupController](https://github.com/lucasfcoelho1/movies-cup/blob/master/MoviesCupApi/MoviesCupApi/Controllers/CupController.cs), com um método post. 
Nele deve ser enviado um *array* de string com 8 elementos, os identifiers de cada filme selecionado no App:
### [POST]
```
http://movies-cup.azurewebsites.net/api/movies/startcup
```

* A API possui um projeto de [Teste](https://github.com/lucasfcoelho1/movies-cup/tree/master/MoviesCupApi/MoviesCupApi.Test) desenvolvido em [xUnit](https://github.com/xunit/xunit)

## APP

O App foi desenvolvido em Xamarin.Forms e tem um [APK](https://github.com/lucasfcoelho1/movies-cup/releases) disponível para a plataforma Android. 
Basta fazer o download do [.zip](https://github.com/lucasfcoelho1/movies-cup/releases/download/1/MoviesCupApp.zip) e instalar no dispositivo alvo.

O App está localizado em **Portugês do Brasil** e **Inglês USA**. Ele usará como base o idioma atual do dispositivo. O idioma padrão é o Inglês.

## Autor
* **Lucas Coelho** - Em caso de dúvidas pode me contatar por [Linkedin](https://www.linkedin.com/in/lucasfcoelho1/) ou aqui mesmo pelo Github.
