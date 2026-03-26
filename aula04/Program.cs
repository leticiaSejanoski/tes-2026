using System;

public class Carro{
    public string fabricante;
    public string modelo;
    public string cor;
    public double aro;
    public int ano;
    public bool estado;

    public void exibir(){
         Console.WriteLine($"Fabricante: {fabricante}\nModelo: {modelo}\nCor: {cor}\nAro: {aro}\nAno: {ano}");
    }

    public void ligar(){
         Console.WriteLine("Ligou");
    }

      public void desligar(){
         Console.WriteLine("Desligou");
    }
}

public class Livro{
    public string titulo;
    public int ano;
    public bool disponivel;

    public void exibir(){
         Console.WriteLine($"Título: {titulo}\nAno: {ano}\nDisponível: {disponivel}");
    }

     public void emprestar(){
        if(disponivel){
            disponivel = false;
         Console.WriteLine($"Livro '{titulo}' emprestado com sucesso!");
        }else{
            Console.WriteLine($"Livro '{titulo}' não está disponível!");
        }
    }

     public void devolver(){
        if(!disponivel){
            disponivel = true;
         Console.WriteLine($"Livro '{titulo}' devolvido com sucesso!");
        }else{
             Console.WriteLine($"Livro '{titulo}' não é possível pois já está devolvido!");
        }
    }
}

public class Program{
    static void Main(){

        Carro carro1 = new Carro();
        carro1.fabricante = "Toyota";
        carro1.modelo = "Corolla";
        carro1.cor = "Preto";
        carro1.aro = 17;
        carro1.ano = 2022;
        carro1.estado = false;

        carro1.exibir();

        if(carro1.estado){
           carro1.desligar();
        }else{
            carro1.ligar();
        }

        Console.WriteLine("-------------------------");

        Livro l1 = new Livro();
        l1.titulo = "Mentirosos";
        l1.ano = 2014;
        l1.disponivel = false;


        Livro[] biblioteca = new Livro[3];
        biblioteca[0] = l1;
        biblioteca[0].exibir();
        l1.emprestar();
    }

    

    
}
