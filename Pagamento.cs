using System;
using System.Collections.Generic;

public record ResultadoPagamento(
    double HorasNormais,     
    double HorasSabado,      
    double HorasDomingo,     
    double HorasTotaisReais, 
    double HorasEfetivas,    
    double HorasPagar,       
    double HorasParaBanco,   
    decimal Remuneracao,     
    string PrazoDeposito     
);

public class Pagamento
{
    private const int LIMITE_HORAS = 44;
    
    public string NomeHorista { get; set; } = null!;
    public decimal ValorHora { get; set; } = 45;
    public List<Dia> DiasTrabalhados { get; } = new();

    public void AdicionarDia(Dia d)
    {
        if (DiasTrabalhados.Count >= 7)
        {
            Console.WriteLine("Já existem 7 dias registrados. Ignorando novo dia.");
            return;
        }
        DiasTrabalhados.Add(d);
    }
    
       public ResultadoPagamento Calcular()
    {
        double horasNormais = 0, horasSabado = 0, horasDomingo = 0;

        foreach (var dia in DiasTrabalhados)
        {
            double horas = dia.Horas;

            switch (dia.Data.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    horasSabado += horas;
                    break;
                case DayOfWeek.Sunday:
                    horasDomingo += horas;
                    break;
                default:
                    horasNormais += horas;
                    break;
            }
        }
        

        double horasTotaisReais = horasNormais + horasSabado + horasDomingo;
        double horasEfetivas = horasNormais + (horasSabado * 1.5) + (horasDomingo * 2);

        double horasParaBanco = horasEfetivas > LIMITE_HORAS ? horasEfetivas - LIMITE_HORAS : 0;
        double horasPagar = Math.Min(horasEfetivas, LIMITE_HORAS);

        decimal remuneracao = (decimal)horasPagar * ValorHora;

    
        string prazoDeposito = remuneracao < 500 ? "Primeiro dia útil"
                             : remuneracao < 1000 ? "Três dias úteis"
                             : "Cinco dias úteis";

       
        return new ResultadoPagamento(
            HorasNormais: horasNormais,
            HorasSabado: horasSabado,
            HorasDomingo: horasDomingo,
            HorasTotaisReais: horasTotaisReais,
            HorasEfetivas: horasEfetivas,
            HorasPagar: horasPagar,
            HorasParaBanco: horasParaBanco,
            Remuneracao: remuneracao,
            PrazoDeposito: prazoDeposito
        );
    }
}