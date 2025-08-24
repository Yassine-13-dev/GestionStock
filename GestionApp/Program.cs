using System;
using System.Collections.Generic;

class Produit
{
    public string Nom { get; set; }
    public double Prix { get; set; }
    public int Quantite { get; set; }

    public Produit(string nom, double prix, int quantite)
    {
        Nom = nom;
        Prix = prix;
        Quantite = quantite;
    }

    public override string ToString()
    {
        return $"Nom: {Nom}, Prix: {Prix} FCFA, Quantité: {Quantite}";
    }
}

class Program
{
    static List<Produit> inventaire = new List<Produit>();

    static void Main()
    {
        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\n===== Système de gestion de stock =====");
            Console.WriteLine("1. Ajouter un produit");
            Console.WriteLine("2. Mettre à jour le stock");
            Console.WriteLine("3. Supprimer un produit");
            Console.WriteLine("4. Afficher tous les produits");
            Console.WriteLine("5. Quitter");
            Console.Write("Votre choix : ");

            string? choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AjouterProduit();
                    break;
                case "2":
                    MettreAJourStock();
                    break;
                case "3":
                    SupprimerProduit();
                    break;
                case "4":
                    AfficherProduits();
                    break;
                case "5":
                    continuer = false;
                    Console.WriteLine("Fermeture du programme...");
                    break;
                default:
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                    break;
            }
        }
    }

    static void AjouterProduit()
    {
        Console.Write("Nom du produit : ");
        string? nom = Console.ReadLine() ?? "Inconnu";

        Console.Write("Prix du produit : ");
        double prix = double.TryParse(Console.ReadLine(), out double p) ? p : 0;

        Console.Write("Quantité en stock : ");
        int quantite = int.TryParse(Console.ReadLine(), out int q) ? q : 0;

        inventaire.Add(new Produit(nom, prix, quantite));
        Console.WriteLine("✅ Produit ajouté avec succès !");
    }

    static void MettreAJourStock()
    {
        Console.Write("Nom du produit à modifier : ");
        string? nom = Console.ReadLine();

        Produit? produit = inventaire.Find(p => p.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));

        if (produit != null)
        {
            Console.Write("Nouvelle quantité : ");
            if (int.TryParse(Console.ReadLine(), out int nouvelleQuantite))
            {
                produit.Quantite = nouvelleQuantite;
                Console.WriteLine("✅ Stock mis à jour !");
            }
            else
            {
                Console.WriteLine("⚠️ Quantité invalide !");
            }
        }
        else
        {
            Console.WriteLine("⚠️ Produit introuvable !");
        }
    }

    static void SupprimerProduit()
    {
        Console.Write("Nom du produit à supprimer : ");
        string? nom = Console.ReadLine();

        Produit? produit = inventaire.Find(p => p.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase));

        if (produit != null)
        {
            inventaire.Remove(produit);
            Console.WriteLine("✅ Produit supprimé !");
        }
        else
        {
            Console.WriteLine("⚠️ Produit introuvable !");
        }
    }

    static void AfficherProduits()
    {
        if (inventaire.Count == 0)
        {
            Console.WriteLine("⚠️ Aucun produit en stock.");
        }
        else
        {
            Console.WriteLine("\n📦 Liste des produits :");
            foreach (var produit in inventaire)
            {
                Console.WriteLine(produit);
            }
        }
    }
}