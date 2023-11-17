using System;
using Zero.ContentContext;


namespace Zero {
  class Program {
    static void Main(string[] args){
      var articles = new List<Article>();
      articles.Add(new Article("Artigo sobre POO", "orientacao-objetos"));

      var coursePOO = new Course("Fundamentos POO", "fundamentos-poo");
      
      var carreiras = new List<Career>();
      var carreira = new Career("Especialista .NET", "especialista-dotnet");
      var carreiraItem = new CareerItem(1,"POO","descricao", null);

      carreira.Items.Add(carreiraItem);

      
      carreiras.Add(carreira);

      foreach(var c in carreiras){
        Console.WriteLine(c.Title);
          foreach(var el in c.Items.OrderByDescending(x => x.Order)){
            Console.WriteLine($"{el.Order} - {el.Title}");
            Console.WriteLine(el.Course?.Title);
            // Console.WriteLine(el.Course?.Notifications.Any());
            foreach(var notification in el.Notifications){
              Console.WriteLine($"{notification?.Property} - {notification?.Message}");
            }
          }
      }
    }
  }
}