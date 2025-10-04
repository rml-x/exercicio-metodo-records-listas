Console.WriteLine("Hello, World!");

/*
Considere um sistema para pagamento de horistas (pessoas que trabalham por hora).

As entradas e saídas são marcadas com um TimeOnly (Somente Hora).
O tempo trabalhado é o TimeSpan (Tempo Decorrido).
As horas inteiras nos dias de semana contam o valor hora normalmente.
Horas aos sábados contam 50% mais (* 1.5).
Horas aos domingos contam 100% mais (o dobro).
Os pagamentos são semanais.
Valores abaixo de 500 reais serão depositados no primeiro dia útil.
A partir de 500 e abaixo de 1000 tomam três dias úteis.
A partir de 1000 reais tomam cinco dias úteis.
Mais de 44 horas vão para o banco de horas e não são pagos.
*/

string horista = "Steve Trabalhos";

DateOnly data1 = new(2025, 10, 3); // 3/10/2025
TimeOnly entrada1 = new(8, 15);
TimeOnly saida1 = new(13, 29);
TimeSpan tempo1 = saida1 - entrada1;

DateOnly data2 = new(2025, 10, 4); // 4/10/2025
Console.WriteLine(data2.DayOfWeek); // 0 Domingo, 1 Segunda, 2 Terça, ....
TimeOnly entrada2 = new(14, 29);
TimeOnly saida2 = new(20, 34);
TimeSpan tempo2 = saida2 - entrada2;

DateOnly data3 = new(2025, 10, 4); // 4/10/2025
TimeOnly entrada3 = new(14, 29);
TimeOnly saida3 = new(20, 34);
TimeSpan tempo3 = saida3 - entrada3;

// horas de segunda a sexta contam normalmente
int horas = tempo1.Hours;
// horas nos sábados contam 50% mais
int horasSabado = tempo2.Hours;
// horas aos domingos contam o dobro (100%)
int horasDomingo = tempo3.Hours;

// horas trabalhaas
int horasTotais = horas + horasSabado + horasDomingo;

// horas calculadas a 50% e 100%
int horasEfetivas = horas + ((int) (horasSabado * 1.5)) + (horasDomingo * 2);

// guardar no banco as horas acima de 44
int horasBanco = horasEfetivas > 44 ? horasEfetivas - 44 : 0;

// máximo 44h
int horasPagar = horasEfetivas > 44 ? 44 : horasEfetivas;

int valorHora = 45;

int remuneracaoSemanal = valorHora * horasEfetivas;

Console.WriteLine($"O horista {horista} trabalhou {horasTotais}h, sendo {horas}h normais, {horasSabado}h a 50% e {horasDomingo} a 100% totaliando {horasEfetivas}h efetivas sendo consideradas {horasPagar}h a pagar e {horasBanco}h como banco de horas. Com o valor hora de R$ {valorHora} a remuneração final é de {remuneracaoSemanal}");

// Agora considere a representação de uma Semana de trabalho, onde um horista tem até 7 entradas e saídas, crie um módulo (Classe) que permita realizar este cálculo (Método) com base nessas variáveis.

