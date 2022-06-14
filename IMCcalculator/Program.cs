using IMCcalculatorLibraries;

static void Diagnostic()
{
    Console.WriteLine("**********************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO");

    var calc = new Calculator();
    
    Console.Write("\nNome: ");
    string name = Console.ReadLine();

    bool validation = true;
    string sex = "";
    while (validation)
    {
        Console.Write("Sexo (Masculino ou Feminino): ");
        sex = Console.ReadLine();
        string sex_t = sex.ToLower();
        
        if (sex_t == "masculino" || sex_t == "feminino")
        {
            validation = false;
        }
    }

    validation = true;
    int age = 0;
    while (validation)
    {
        Console.Write("Idade: ");
        age = int.Parse(Console.ReadLine());

        if (age > 0)
        {
            validation = false;
        }
    }

    validation = true;
    double height = 0.0;
    while (validation)
    {
        Console.Write("Altura (em centimetros [cm]): ");
        height = double.Parse(Console.ReadLine());

        if (height > 0)
        {
            validation = false;
        }
    }

    validation = true;
    double weight = 0.0;
    while (validation)
    {
        Console.Write("Peso (em quilogramas [Kg]): ");
        weight = double.Parse(Console.ReadLine());

        if (weight > 0)
        {
            validation = false;
        }
    }
    
    string category = calc.SelectCategory(age);

    double imc = calc.CalculateIMC(weight, height);
    string classification = calc.IndicateClassification(imc);

    string risk = calc.IndicateRisks(imc);

    string recommendation = calc.RecommendSolution(imc);

    Console.WriteLine("\n***************************************************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO");
    Console.Write($"\nNome: {name}");
    Console.Write($"\nSexo: {sex}");
    Console.Write($"\nIdade: {age}");
    Console.Write($"\nAltura: {height/100} m");
    Console.Write($"\nPeso: {weight} Kg");
    Console.WriteLine($"\nCategoria: {category}");
    Console.WriteLine($"\nIMC Desejável: entre 20 e 24");
    Console.WriteLine($"\nResultado IMC: {imc:0.00} ({classification})");
    Console.WriteLine($"\nRiscos: {risk}");
    Console.WriteLine($"\nRecomendação inicial: {recommendation}");
    Console.WriteLine("\n***************************************************");
}

Diagnostic();