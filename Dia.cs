using System;

public class Dia
{
    public DateOnly Data { get; set; }
    public TimeOnly Entrada { get; set; }
    public TimeOnly Saida { get; set; }

    public TimeSpan TempoTrabalhado
    {
        get
        {
            if (Saida < Entrada)
                return (Saida.AddHours(24) - Entrada);
            
            return Saida - Entrada;
        }
    }
    public double Horas => TempoTrabalhado.TotalHours;
}