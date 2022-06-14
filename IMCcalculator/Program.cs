using IMCcalculatorLibraries;

static void Diagnostic()
{
    Console.WriteLine("**********************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO");

    var calc = new Calculator();
    
    Console.Write("\nNome: ");
    string name = Console.ReadLine();

    Console.Write("Sexo (Masculino ou Feminino): ");
    string sex = Console.ReadLine();

    Console.Write("Idade: ");
    int age = int.Parse(Console.ReadLine());

    Console.Write("Altura (em centimetros [cm]): ");
    double height = double.Parse(Console.ReadLine());

    Console.Write("Peso (em quilogramas [Kg]): ");
    double weight = double.Parse(Console.ReadLine());

    string category = calc.SelectCategory(age);
    Console.WriteLine($"Categoria: {category}");

    Console.WriteLine($"\nIMC Desejável: entre 20 e 24");

    double imc = calc.CalculateIMC(weight, height);
    Console.WriteLine($"\nResultado IMC: {imc:0.00}");

    string risk = calc.IndicateRisks(imc);
    Console.WriteLine($"\nRiscos: {risk}");

    string recommendation = calc.RecommendSolution(imc);
    Console.WriteLine($"\nRecomendação inicial: {recommendation}");

    Console.WriteLine("\n**********************");
}

Diagnostic();