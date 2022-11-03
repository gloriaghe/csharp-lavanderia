
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


Console.WriteLine("Cosa vuoi sapere? ");
Console.WriteLine("Premi 1 per sapere lo stato delle macchine");
Console.WriteLine("Premi 2 per avere i dettagli delle macchine");
Console.WriteLine("Premi 3 per sapere l'incasso");

int sceltaUser = Convert.ToInt32(Console.ReadLine());

Lavanderia lavanderia = new Lavanderia();
lavanderia.StartLavatrici();
lavanderia.StartAsciugatrici();

if (sceltaUser == 1)
{
    lavanderia.StatoMacchine();

}
else if (sceltaUser == 2)
{
    for (int i = 0; i < 5; i++)
    {
        lavanderia.DettagliMacchina("lavatrice", i);
        lavanderia.DettagliMacchina("asciugatrice", i);
    }


}
else if (sceltaUser == 3)
{
    lavanderia.Incasso();
}
else
{
    Console.WriteLine("Scelta errata");

}


public class Lavanderia
{
    public Lavanderia()
    {
        lavatrici = new Lavatrice[5];
        asciugatrici = new Asciugatrice[5];

        for (int i = 0; i < 5; i++)
        {
            lavatrici[i] = new Lavatrice("Lavatrice" + (i + 1));
            asciugatrici[i] = new Asciugatrice("Asciugatrice" + (i + 1));

        }
    }
    private Lavatrice[] lavatrici;
    private Asciugatrice[] asciugatrici;

    public void StatoMacchine()
    {
        Console.WriteLine("Stato: ");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].Stato);
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].Stato);
        }

    }
    public void DettagliMacchina(string macchina, int numero)
    {
        if (macchina == "lavatrice")
            lavatrici[numero].StampaDettagli();
        else
            asciugatrici[numero].StampaDettagli();
    }
    public void Incasso()
    {
        Console.WriteLine("Incassi:");
        double incassoTotale = 0;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].Incasso() + " Euro");
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].Incasso() + " Euro");
            incassoTotale = incassoTotale + lavatrici[i].Incasso() + asciugatrici[i].Incasso();
        }
        Console.WriteLine("Totale: " + incassoTotale + " Euro");
    }
    public void StartLavatrici()
    {
        for (int i = 0; i < lavatrici.Length; i++)
        {

            lavatrici[i].Lavaggio();

        }
    }
    public void StartAsciugatrici()
    {
        for (int i = 0; i < asciugatrici.Length; i++)
        {

            asciugatrici[i].Asciugatura();

        }
    }

}
public class Lavatrice
{
    public string Nome { get; }
    public int Durata { get; set; }
    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }

    public int CostoLavaggio { get; set; }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public string Stato { get; set; }
    //public double Incasso { get; set; }

    public Lavatrice(string nome)
    {
        this.Nome = nome;
        this.Detersivo = 1000;
        this.Ammorbidente = 500;
        //Random random = new Random();
        //this.Stato = random.Next(0, 1);
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
        int sceltaLavaggio = random.Next(1, 5);

        if (sceltaLavaggio == 1)
            Rinfrescante();
        else if (sceltaLavaggio == 2)
            Rinnovante();
        else if (sceltaLavaggio == 3)
            Sgrassante();

    }


    public void StampaDettagli()
    {
        int durataPassata = 0;
        if (Durata != 0)
        {
            Random random = new Random();
            durataPassata = random.Next(1, (Durata - 5));
        }
        else
            durataPassata = 0;


        Console.WriteLine("-------------");
        Console.WriteLine("Nome macchina: " + Nome);
        Console.WriteLine("Stato: " + Stato);
        Console.WriteLine("Detersivo: " + (Detersivo - ConsumoDetersivo) + "ml");
        Console.WriteLine("Ammorbidente: " + (Ammorbidente - ConsumoAmmorbidente) + "ml");
        Console.WriteLine("Tempo rimasto alla fine del lavaggio: " + (Durata - durataPassata));

    }
    public double Incasso()
    {
        return CostoLavaggio * 0.50;
    }
}


public class Asciugatrice
{
    public string Nome { get; }
    public int Durata { get; set; }
    public string Stato { get; set; }

    public int CostoLavaggio { get; set; }
    //public double Incasso { get; set; }
    public Asciugatrice(string nome)
    {
        this.Nome = nome;
        this.Stato = "vuota";

    }

    public void Rapido()
    {
        Durata = 30;
        CostoLavaggio = 2;
        Stato = "Rapido";

    }
    public void Intenso()
    {
        Durata = 60;
        CostoLavaggio = 4;
        Stato = "Intenso";
    }
    public void StampaDettagli()
    {
        int durataPassata = 0;
        if (Durata != 0)
        {
            Random random = new Random();
            durataPassata = random.Next(1, (Durata - 5));
        }
        else
            durataPassata = 0;
        Console.WriteLine("-------------");
        Console.WriteLine("Nome macchina: " + Nome);
        Console.WriteLine("Stato: " + Stato);
        Console.WriteLine("Tempo rimasto alla fine del lavaggio: " + (Durata - durataPassata));
    }
    public void Asciugatura()
    {
        Random random = new Random();
        int sceltaLavaggio = random.Next(1, 5);

        if (sceltaLavaggio == 1)
            Rapido();
        else if (sceltaLavaggio == 2)
            Intenso();

    }
    public double Incasso()
    {
        return CostoLavaggio * 0.50;
    }
}
