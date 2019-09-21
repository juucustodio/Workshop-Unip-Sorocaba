# Workshop-Unip-Sorocaba
Exemplos e materiais utilizados no workshop realizado na faculdade UNIP de Sorocaba no dia 21/05/19

# Passos Seguidos

1 - Criar projeto Xamarin.Forms<br>

2 - Adicionar os Plugins: MVVMCoffee e Newtonsoft.Json<br>

3 - Criar estruturas de Pastas (Views, ViewModels, Models, Services)<br>

4 - Criar Classe RestClient na pasta Services<br>
  - Classe responsável por realizar a chamada para a api utilizada (DogApi)<br><br>

5 - Criar classe Retorno na pasta Models<br>
  - Classe responsável por representar nosso objeto que será retornado pela API com a propriedade Message, sendo ela a lista de imagens de cachorros.
  
6 - Criar MainPage na pasta Views (Nossa interface)<br>

7 - Criar classe MainViewModel na pasta ViewModels<br>


Observações:  Para quem esteve no evento, tivemos um problema de Binding no momento de carregar a lista, o motivo foi o fato de que não utilizamos o SetProperty no nosso objeto Retorno que criamos na classe MainViewModel. 

-- Todo Código utilizado para o exemplo sem o MVVM não foi apagado, apenas comentado.



<p>
  <image height="500px"src="https://julianocustodiosite.files.wordpress.com/2019/09/ezgif.com-video-to-gif.gif"/><br>  
</p>
