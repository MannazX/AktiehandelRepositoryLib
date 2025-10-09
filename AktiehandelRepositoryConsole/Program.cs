// See https://aka.ms/new-console-template for more information
using AktiehandelRepositoryLib;

Console.WriteLine("Hello, Database Repository!");

Console.WriteLine();

// Add an item to the Database

AktieHandelRepositoryDB repoDB = new AktieHandelRepositoryDB();
// AktieHandelRepository repo = new AktieHandelRepository();
// AktieHandel newAktie = new AktieHandel("Coal", 10, 200);

/*
repoDB.Add(new AktieHandel("Coal", 10, 200));
repoDB.Add(new AktieHandel("Crude Oil", 10, 300));
repoDB.Add(new AktieHandel("Methane", 10, 150));
repoDB.Add(new AktieHandel("Wind", 10, 350));
repoDB.Add(new AktieHandel("Solar", 10, 500));
repoDB.Add(new AktieHandel("Uranium", 10, 450));
*/

// Console.WriteLine();

// Console.WriteLine(repoDB.GetById(1));

// Delete an item from the

// repoDB.Delete(1);

// IEnumerable<AktieHandel> itemListAll = repoDB.GetAll();
// IEnumerable<AktieHandel> itemListAntal = repoDB.GetByAntal(200);
IEnumerable<AktieHandel> itemListOrdered = repoDB.GetOrderBy("Handelspris");

foreach (AktieHandel item in itemListOrdered)
{
	Console.WriteLine(item);
	Console.WriteLine();
}

Console.WriteLine();


