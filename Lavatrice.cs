
//Una lavanderia è aperta 24 ore su 24 e permette ai clienti di servizi autonomamente di 5 Lavatrici e 5 Asciugatrici.
//I clienti che usufruiscono delle macchine, possono effettuare diversi programmi di lavaggio e asciugatura ognuno con un costo diverso (in gettoni) e di una specifica durata.
//Ogni gettone costa 0.50 centesimi di euro e ogni lavaggio consuma detersivo e ammorbidente dai serbatoi della lavatrice. Ogni lavatrice può tenere fino ad un massimo di 1
//litro di detersivo e 500ml di ammorbidente.
//I programmi di lavaggio hanno quindi queste caratteristiche
//Rinfrescante, costo di 2 gettoni, durata di 20 minuti, consumo di 20ml di detersivo e 5ml di ammorbidente.
//Rinnovante, costo di 3 gettoni, durata di 40 minuti, consumo di 40ml di detersivo e 10ml di ammorbidente.
//Sgrassante, costo di 4 gettoni, durata di 60 minuti, consumo di 60 ml di detersivo e 15ml di ammorbidente.
//Le asciugatrici invece hanno soltanto due programmi di asciugatura, rapido 2 gettoni e intenso 4 gettoni della durata di 30 minuti e 60 minuti rispettivamente.
//Si richiede di creare un sistema di controllo in grado di riportare lo stato della lavanderia, in particolare si vuole richiedere:
//1 - Lo stato generale di utilizzo delle macchine: un elenco di tutte le macchine che semplicemente dica quali sono in funzione e quali non lo sono (in lavaggio / asciugatura
//oppure ferme)
//2 - Possa essere richiesto il dettaglio di una macchina: Tutte le informazioni relative alla macchina, nome del macchinario, stato del macchinario (in funzione o no),
//tipo di lavaggio in corso, quantità di detersivo presente (se una lavatrice), durata del lavaggio, tempo rimanente alla fine del lavaggio.
//3 - l’attuale incasso generato dall’utilizzo delle macchine.





public class Lavatrice : MacchineLavanderia
{

    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }

    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }


    public Lavatrice(string nome)
    {
        this.Nome = nome;
        this.Detersivo = 1000;
        this.Ammorbidente = 500;
        this.Stato = "vuota";
    }

    public void Rinfrescante()
    {
        CostoLavaggio = 2;
        Durata = 20;
        ConsumoDetersivo = 20;
        ConsumoAmmorbidente = 5;
        Stato = "Rinfrescante";
    }
    public void Rinnovante()
    {
        CostoLavaggio = 3;
        Durata = 40;
        ConsumoDetersivo = 40;
        ConsumoAmmorbidente = 10;
        Stato = "Rinnovante";
    }
    public void Sgrassante()
    {
        CostoLavaggio = 4;
        Durata = 60;
        ConsumoDetersivo = 60;
        ConsumoAmmorbidente = 15;
        Stato = "Sgrassante";
    }
    public void Lavaggio()
    {
        Random random = new Random();
        int sceltaLavaggio = random.Next(1, 6);

        if (sceltaLavaggio == 1)
            Rinfrescante();
        else if (sceltaLavaggio == 2)
            Rinnovante();
        else if (sceltaLavaggio == 3)
            Sgrassante();

    }

    public void LavaggioScelta(int sceltalavaggio)
    {


        if (sceltalavaggio == 1)
            Rinfrescante();
        else if (sceltalavaggio == 2)
            Rinnovante();
        else if (sceltalavaggio == 3)
            Sgrassante();
    }
    public override void StampaDettagli(bool nuova)
    {
        int durataPassata = 0;
        if (nuova == false)
        {
            if (Durata != 0)
            {
                Random random = new Random();
                durataPassata = random.Next(1, (Durata - 5));
            }
            else
                durataPassata = 0;

        }


        string vuota = "Spenta";

        if (Stato != "vuota")
        {
            vuota = "Accesa";
        }

        Console.WriteLine("-------------");
        Console.WriteLine("Nome macchina: " + Nome);
        Console.WriteLine("Stato: " + vuota);
        Console.WriteLine("Lavaggio: " + Stato);
        Console.WriteLine("Detersivo: " + (Detersivo - ConsumoDetersivo) + "ml");
        Console.WriteLine("Ammorbidente: " + (Ammorbidente - ConsumoAmmorbidente) + "ml");
        Console.WriteLine("Durata totale lavaggio: " + Durata);
        Console.WriteLine("Tempo rimasto alla fine del lavaggio: " + (Durata - durataPassata));

    }
    public override double Incasso()
    {
        return CostoLavaggio * 0.50;
    }
}
