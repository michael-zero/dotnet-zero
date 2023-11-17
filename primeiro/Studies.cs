// internal class Program
// {
//     static void ReceberDinheiro(double valor){
//      Console.WriteLine($"Recebeu o valor de R$ {valor}");
//     }
//     static void Main(string[] args)
//     {
  

//        var arr = new int[3];

//        //receber é uma função
//        var receber = new Payment.Receber(ReceberDinheiro);
//        receber(300);

//        using(
//           var animal = new Animal("Gold")
//        ){
//         Console.WriteLine(animal.ToString());
//        }

//        try{
//         // for(var index = 0; index < 10; index++){
//         //     Console.WriteLine(arr[index]);        
//         // }

//         // Salvar("");
        
//        }
//        catch(ArgumentNullException e){
//             Console.WriteLine(e.Message);
//             Console.WriteLine("Falha ao salvar texto");
//        }
//        catch(IndexOutOfRangeException e){
//             Console.WriteLine(e.Message);
//             Console.WriteLine("Índice do array estourou");
//        }
//        catch(Exception e){
//             Console.WriteLine($"ops, erro! {e}");
//             Console.WriteLine(e.Message);
//        }
//     }

//     private static void Salvar(string texto){
//         if(string.IsNullOrEmpty(texto)){
//             throw new ArgumentNullException("Texto nulo ou vazio");
//         }
//     }

//     class Animal : IDisposable {
//         public string Nome;
//         public int Idade { get; set; }

//         public Animal (){}
//         public Animal(string nome)
//         {
//             Nome = nome;
//         }

//         public virtual void Locomocao(){

//         }

//         public override string ToString()
//         {
//               return Nome ?? "Nome Não Definido"; 
//         }

//         public void Dispose()
//         {
//           Console.WriteLine("Finalizando o Animal");
//         }
//     }

//     class Peixe : Animal {
//         public Peixe(string nome) : base(nome)
//         {
//         }
//         public override void Locomocao()
//         {
//             base.Locomocao();
//         }

//         public void Dispose(){
//             Console.WriteLine("Finalizando o Peixe");
//         }
//     }

//     class Cachorro : Animal {

//     }

//     public static class Settings {
//         public static string API_URL {get; set;}
//     }

//     // Classe Selada, que não pode ser herdada
//     // public  sealed class Pagamento {
//     //     public DateTime Vencimento {get; set;}
//     // }

//     // public class PagamentoBoleto: Pagamento {
//     // }

//     public  abstract class Pagamento {
//         public DateTime Vencimento {get; set;}

//         //pode sofrer override
//         public virtual void Pagar(double valor){

//         }

   
//     }

//     public  abstract class PagamentoPix : Pagamento {
//     }

//     public interface IPagamento {
//         DateTime Vencimento {get; set;}
//         void Pagar(double valor);
//         void Transferencia(double valor, string conta);
//     }

//     public class Payment : IPagamento
//     {
//         DateTime IPagamento.Vencimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//         void IPagamento.Pagar(double valor)
//         {
//             throw new NotImplementedException();
//         }

//         void IPagamento.Transferencia(double valor, string conta)
//         {
//             throw new NotImplementedException();
//         }

//         //delegate
//         public delegate void Receber(double valor);
//     }
// }