using IMCcalculatorLibraries;
using System.Globalization;

static void Diagnostic()
{
    Console.WriteLine("**********************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");

    var calc = new Calculator();

    bool validation = true;

    string name = "";
    while (validation)
    {
        Console.Write("Nome: ");
        name = Console.ReadLine();

        if (name.Length > 0)
        {
            validation = false;
        }
    }

    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    name = textInfo.ToTitleCase(name.ToLower());

    validation = true;
    string sex = "";
    while (validation)
    {
        Console.Write("Sexo (Masculino ou Feminino): ");
        sex = Console.ReadLine();
        sex = sex.ToLower();
        
        if (sex == "masculino" || sex == "feminino")
        {
            validation = false;
        }
    }

    sex = textInfo.ToTitleCase(sex);

    validation = true;
    int age = 0;
    while (validation)
    {
        Console.Write("Idade: ");
        string age_temp = Console.ReadLine();
        bool validator = Int32.TryParse(age_temp, out age);

        if (age > 0 && validator == true)
        {
            validation = false;
        }
    }

    validation = true;
    double height = 0.0;
    while (validation)
    {
        Console.Write("Altura (em centimetros [cm]): ");
        string height_temp = Console.ReadLine();
        bool validator = double.TryParse(height_temp, out height);

        if (height > 0 && validator == true)
        {
            validation = false;
        }
    }

    validation = true;
    double weight = 0.0;
    while (validation)
    {
        Console.Write("Peso (em quilogramas [Kg]): ");
        string weight_temp = Console.ReadLine();
        bool validator = double.TryParse(weight_temp, out weight);

        if (weight > 0 && validator == true)
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