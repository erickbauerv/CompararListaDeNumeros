Console.WriteLine("Digite os números da primeira lista, separados por vírgula:");
string entrada1 = Console.ReadLine();
List<int> lista1 = ProcessarEntrada(entrada1);
 
Console.WriteLine("Digite os números da segunda lista, separados por vírgula:");
string entrada2 = Console.ReadLine();
List<int> lista2 = ProcessarEntrada(entrada2);

IEnumerable<int> numerosNovosLista1 = lista1.Except(lista2);
Console.WriteLine("Números que estão na lista1 mas não na lista2:");
ExibirLista(numerosNovosLista1);

IEnumerable<int> numerosNovosLista2 = lista2.Except(lista1);
Console.WriteLine("Números que estão na lista2 mas não na lista1:");
ExibirLista(numerosNovosLista2);

Console.Read();

static List<int> ProcessarEntrada(string entrada)
{
  return entrada.Split(',')
                .Select(s => int.TryParse(s.Trim(), out int numero) ? numero : (int?)null)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();
}

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
