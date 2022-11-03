
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

Asciugatrice asciugatrice1 = new Asciugatrice("asciugatrice1");
Asciugatrice asciugatrice2 = new Asciugatrice("asciugatrice2");
Asciugatrice asciugatrice3 = new Asciugatrice("asciugatrice3");
Asciugatrice asciugatrice4 = new Asciugatrice("asciugatrice4");
Asciugatrice asciugatrice5 = new Asciugatrice("asciugatrice5");
Lavatrice lavatrice1 = new Lavatrice("lavatrice1");
Lavatrice lavatrice2 = new Lavatrice("lavatrice2");
Lavatrice lavatrice3 = new Lavatrice("lavatrice3");
Lavatrice lavatrice4 = new Lavatrice("lavatrice4");
Lavatrice lavatrice5 = new Lavatrice("lavatrice5");
Console.WriteLine("Cosa vuoi sapere? ");
Console.WriteLine("Premi 1 per sapere lo stato delle macchine");
Console.WriteLine("Premi 2 per avere i dettagli delle macchine");
Console.WriteLine("Premi 3 per sapere l'incasso");

int sceltaUser = Convert.ToInt32(Console.ReadLine());

if (sceltaUser == 1)
{

}
else if (sceltaUser == 2)
{

}
else if (sceltaUser == 3)
{

}
else
{
    Console.WriteLine("Scelta errata");

}
lavatrice1.Rinfrescante();
    lavatrice1.StampaDettagli();


public class Lavatrice
{
    public string Nome { get; }
    public int Durata { get; set; }
    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }

    public int CostoLavaggio { get; set; }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Stato { get; set; }
    //public double Incasso { get; set; }

    public Lavatrice(string nome)
    {
        this.Nome = nome;
        this.Detersivo = 1000;
        this.Ammorbidente = 500;
        Random random = new Random();
        this.Stato = random.Next(0,1);
        
    }

    public void Rinfrescante()
    {
        CostoLavaggio = 2;
        Durata = 20;
        ConsumoDetersivo = 20;
        ConsumoAmmorbidente = 5;
        Stato = 1;
    }
    public void Rinnovante()
    {
        CostoLavaggio = 3;
        Durata = 40;
        ConsumoDetersivo = 40;
        ConsumoAmmorbidente = 10;
        Stato = 1;
    }
    public void Sgrassante()
    {
        CostoLavaggio = 4;
        Durata = 60;
        ConsumoDetersivo = 60;
        ConsumoAmmorbidente = 15;
        Stato = 1;
    }

    private bool ControlloStato()
    {
        
    }
    public void StampaDettagli()
    {
        Console.WriteLine("Nome macchina: " + Nome);
        Console.WriteLine("Stato: " + ControlloStato());
        Console.WriteLine("Detersivo: " + ConsumoDetersivo + "ml");
        Console.WriteLine("Ammorbidente: " + ConsumoAmmorbidente + "ml");
        Console.WriteLine("Tempo rimasto alla fine del lavaggio: " + Durata);
    }
    public double Incasso()
    {
        return (double)CostoLavaggio * 0.50;
    }
}


public class Asciugatrice
{
    public string Nome { get; }
    public int Durata { get; set; }
    public bool Stato { get; set; }

    public int CostoLavaggio { get; set; }
    public double Incasso { get; set; }

    public Asciugatrice(string nome)
    {
        this.Nome = nome;
        this.Stato = true;
        this.Incasso = 0;
    }

    public void Rapido()
    {
        Durata = 30;
        CostoLavaggio = 2;
        Stato = false;

    }
    public void Intenso()
    {
        Durata = 60;
        CostoLavaggio = 4;
        Stato = false;
    }
}
