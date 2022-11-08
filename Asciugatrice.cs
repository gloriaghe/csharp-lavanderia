
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





public class Asciugatrice : MacchineLavanderia
{
    
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
    public override void StampaDettagli()
    {
        int durataPassata = 0;
        if (Durata != 0)
        {
            Random random = new Random();
            durataPassata = random.Next(1, (Durata - 5));
        }
        else
            durataPassata = 0;


        string vuota = "Spenta";

        if (Stato != "vuota")
        {
            vuota = "Accesa";
        }

        Console.WriteLine("-------------");
        Console.WriteLine("Nome macchina: " + Nome);
        Console.WriteLine("Stato: " + vuota);
        Console.WriteLine("Programma: " + Stato);
        Console.WriteLine("Durata totale asciugatura: " + Durata );
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
    public override double Incasso()
    {
        return CostoLavaggio * 0.50;
    }
}
