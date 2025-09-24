// See https://aka.ms/new-console-template for more information
using AktiehandelRepositoryLib;

Console.WriteLine("Hello, World!");

// Add an item to the Database

AktieHandelRepositoryDB repo = new AktieHandelRepositoryDB();
AktieHandel newAktie = new AktieHandel("Coal", 10, 200);
// repo.Add(newAktie); // Confirmed

// Delete an item from the Database

repo.Delete(1); //

