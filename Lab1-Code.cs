using System;
using System.Collections.Generic;

class Motor
{
    public string Model { get; set; }
    public int BeygirGucu { get; set; }
    public void Calistir()
    {
        Console.WriteLine($"{Model} ,Motor calisti.");
    }
    public Motor(string model, int beygirGucu)
    {
        Model = model;
        BeygirGucu = beygirGucu;
    }
}
class Araba
{
    public string Marka { get; set; }
    private Motor motor;//Bu ilişki composite bir yapıdır.
    public Araba(string marka, string model, int beygirGucu)
    {
        Marka = marka;
        motor = new Motor(model, beygirGucu);
        motor.Calistir();

    }
  
    public void BilgileriGoster()
    {
        Console.WriteLine($"Marka: {Marka}");

        Console.WriteLine(
            $"Motor: {motor.Model}"
        );

        Console.WriteLine(
            $"Beygir: {motor.BeygirGucu}"
        );
    }

}
class Program
{
    static void Main()
    {
        Araba araba = new Araba("Lotus", "Sporv1", 500);
        araba.BilgileriGoster();
    }
}
