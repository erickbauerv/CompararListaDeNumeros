using CompararListaDeNumeros;
using Newtonsoft.Json;

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\listas.json");
string json = File.ReadAllText(Path.GetFullPath(filePath));
DadosListas dadosListas = JsonConvert.DeserializeObject<DadosListas>(json);

IEnumerable<int> numerosNovosLista1 = dadosListas.lista1.Except(dadosListas.lista2);
Console.WriteLine("Números que estão na lista1 mas não na lista2:");
ExibirLista(numerosNovosLista1);

IEnumerable<int> numerosNovosLista2 = dadosListas.lista2.Except(dadosListas.lista1);
Console.WriteLine("Números que estão na lista2 mas não na lista1:");
ExibirLista(numerosNovosLista2);

Console.Read();

static void ExibirLista(IEnumerable<int> lista)
{
  if (!lista.Any())
  {
    Console.WriteLine("Nenhum número encontrado.");
  }
  else
  {
    Console.WriteLine(string.Join(", ", lista));
  }
}
