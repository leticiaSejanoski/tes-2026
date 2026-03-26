using System;

public class Carro
{
    public string fabricante;
    public string modelo;
    public string cor;
    public double aro;
    public int ano;
    public bool estado;

    public void Exibir()
    {
        Console.WriteLine($"Fabricante: {fabricante}\nModelo: {modelo}\nCor: {cor}\nAro: {aro}\nAno: {ano}");
    }

    public void Ligar()
    {
        if (estado) Console.WriteLine("O carro já está ligado!");
        else Console.WriteLine("Ligou!");
    }

    public void Desligar()
    {
        if (!estado) Console.WriteLine("O carro já está desligado!");
        else Console.WriteLine("Desligou!");
    }
}

public class Livro
{
    public string titulo;
    public int ano;
    public bool disponivel;

    public void Exibir()
    {
        Console.WriteLine($"Título: {titulo}\nAno: {ano}\nDisponível: {disponivel}");
    }

    public void Emprestar()
    {
        if (disponivel)
        {
            disponivel = false;
            Console.WriteLine($"Livro '{titulo}' emprestado com sucesso!");
        }
        else
        {
            Console.WriteLine($"Livro '{titulo}' não está disponível!");
        }
    }

    public void Devolver()
    {
        if (!disponivel)
        {
            disponivel = true;
            Console.WriteLine($"Livro '{titulo}' devolvido com sucesso!");
        }
        else
        {
            Console.WriteLine($"Livro '{titulo}' não é possível pois já está devolvido!");
        }
    }
}


public class Produto
{
    public string nome;
    public double preco;
    public int quantidade;

    public void ExibirDados()
    {
        Console.WriteLine($"Produto: {nome}\nPreco: {preco:F2}\nEstoque: {quantidade}");
    }

    public void AdicionarEstoque()
    {
        Console.Write("Adicionar ao estoque: ");
        int adicional = int.Parse(Console.ReadLine());
        quantidade += adicional;
    }

    public void RemoverEstoque()
    {
        Console.Write("Remover do estoque: ");
        int removido = int.Parse(Console.ReadLine());
        if (removido <= quantidade)
        {
            quantidade -= removido;
        }
        else
        {
            Console.WriteLine("Estoque insuficiente!");
        }
    }

    public void CalcularValorTotal()
    {
        double total = quantidade * preco;
        Console.WriteLine($"Valor total do estoque: R${total:F2}");
    }

    public void AplicarDesconto(int percentual)
    {
        double desconto = percentual / 100.0;
        preco -= preco * desconto;
        Console.WriteLine($"Novo preço com desconto de {percentual}%: R${preco:F2}");

    }
}

public class Program
{
    static void Main()
    {

        Carro carro1 = new Carro();
        carro1.fabricante = "Toyota";
        carro1.modelo = "Corolla";
        carro1.cor = "Preto";
        carro1.aro = 17;
        carro1.ano = 2022;
        carro1.estado = false;

        carro1.Exibir();
        carro1.Desligar();


        Console.WriteLine("-------------------------");

        Livro l1 = new Livro();
        l1.titulo = "Mentirosos";
        l1.ano = 2014;
        l1.disponivel = false;


        Livro[] biblioteca = new Livro[3];
        biblioteca[0] = l1;
        biblioteca[0].Exibir();
        l1.Emprestar();

        Console.WriteLine("-------------------------");

        Produto p1 = new Produto();
        p1.nome = "Lápis";
        p1.preco = 1.99;
        p1.quantidade = 200;

        p1.ExibirDados();
        p1.AdicionarEstoque();
        p1.RemoverEstoque();

        p1.CalcularValorTotal();
        p1.AplicarDesconto(50);
    }


}
