namespace managershoppinglist;
using System.IO;

public class Program
{
    public static void Main()
    {
        String patch = @"C:\Users\iedso\Documents\curso-csharp-dotnet\GerenciadorListaDeCompras\";
        String fileName = "ListaDeCompras.txt";
        String filePath = Path.Combine(patch, fileName);

        List<String> shoppingList = new List<String>();

        if(File.Exists(filePath))
        {
            shoppingList.AddRange(File.ReadAllLines(filePath));
        }

        while(true)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("         MENU         ");
            Console.WriteLine("----------------------");
            Console.WriteLine("1 - Adicionar item");
            Console.WriteLine("2 - Remover item");
            Console.WriteLine("3 - Atualizar item");
            Console.WriteLine("4 - Listar itens");
            Console.WriteLine("5 - Limpar lista");
            Console.WriteLine("6 - Salvar (.txt)");
            Console.WriteLine("7 - Sair");
            Console.Write("Escolha uma opção: ");

            String option = Console.ReadLine();

            switch(option)
            {
                case "1":

                    Console.Write("Digite o item que deseja adicionar: ");
                    String itemToAdd = Console.ReadLine();

                    if(!String.IsNullOrWhiteSpace(itemToAdd))
                    {
                        shoppingList.Add(itemToAdd);
                        Console.WriteLine($"Item '{itemToAdd}' adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Item inválido. Tente novamente.");
                    }

                    break;

                case "2":
                    Console.Write("Digite o item que deseja remover: ");
                    String itemToRemove = Console.ReadLine();
                    if (shoppingList.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Item '{itemToRemove}' removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToRemove}' não encontrado na lista.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Itens na lista de compras:");
                    
                    for (int i = 0; i < shoppingList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {shoppingList[i]}");
                    }

                    Console.Write("Digite o item que deseja atualizar: ");
                    String itemToUpdate = Console.ReadLine();

                    int indexToUpdate = shoppingList.IndexOf(itemToUpdate);

                    if (indexToUpdate != -1)
                    {   
                        Console.Write("Digite o novo valor do item: ");
                        String newItemValue = Console.ReadLine();

                        if (!String.IsNullOrWhiteSpace(newItemValue))
                        {
                            shoppingList[indexToUpdate] = newItemValue;
                            Console.WriteLine($"Item '{itemToUpdate}' atualizado para '{newItemValue}' com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Novo valor inválido. Tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Item '{itemToUpdate}' não encontrado na lista.");
                    }
                    break;

                case "4":

                    Console.WriteLine("Itens na lista de compras:");
                    if(shoppingList.Count == 0)
                    {
                        Console.WriteLine("A lista está vazia.");
                    }
                    else
                    {
                        for (int i = 0; i < shoppingList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {shoppingList[i]}");
                        }
                    }

                    break;

                case "5":
                    shoppingList.Clear();
                    Console.WriteLine("Lista de compras limpa com sucesso!");
                    break;

                case "6":
                    File.WriteAllLines(filePath, shoppingList);
                    Console.WriteLine("Lista salva com sucesso!");
                    break;

                case "7":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;

            }

        }
    }
}