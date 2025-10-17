using System;
using System.Collections.Generic;
using System.Globalization;

Console.WriteLine("Hello, World!");

var pagamentoSemanal = new Pagamento
{
    NomeHorista = "Steve Trabalhos",
    ValorHora = 45m
};

pagamentoSemanal.AdicionarDia(

    new Dia //(Dia útil)
    {
        Data = new(2025, 9, 29),
        Entrada = new(8, 0),
        Saida = new(13, 0)
    });
   
pagamentoSemanal.AdicionarDia(

    new Dia //(Sábado)
    {
        Data = new(2025, 11, 1),
        Entrada = new(8, 0),
        Saida = new(14, 0)
    });

pagamentoSemanal.AdicionarDia(

    new Dia //(Domingo) 
    {
        Data = new(2025, 10, 5),
        Entrada = new(8, 0),
        Saida = new(14, 0)
    }); 
    
pagamentoSemanal.AdicionarDia(

    new Dia //(Dia útil)
    {
        Data = new(2025, 10, 6),
        Entrada = new(8, 0),
        Saida = new(23, 0)
    }); 


ResultadoPagamento resultado = pagamentoSemanal.Calcular();

string remuneracaoFormatada = resultado.Remuneracao.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
double horasAcrescimo = resultado.HorasSabado + resultado.HorasDomingo;

Console.WriteLine(
   $"\nO horista {pagamentoSemanal.NomeHorista} trabalhou {resultado.HorasTotaisReais:N2}h, sendo  {resultado.HorasNormais:N2}h normais, {resultado.HorasSabado:N2}h a 50% e {resultado.HorasDomingo:N2}h a 100% totaliando {resultado.HorasEfetivas:N2}h efetivas sendo consideradas {resultado.HorasPagar:N2}h a pagar e {resultado.HorasParaBanco:N2}h como banco de horas. Com o valor hora de {pagamentoSemanal.ValorHora:N2} a remuneração final é de {remuneracaoFormatada}."
);
Console.WriteLine("-------------------------------");
Console.WriteLine($"Prazo para Depósito: {resultado.PrazoDeposito}");

