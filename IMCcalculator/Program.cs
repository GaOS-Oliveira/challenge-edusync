using IMCcalculatorLibraries;
using System.Globalization;

static void Diagnostic()
{
    Console.WriteLine("**********************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");

    // Variável de objeto contendo as funções para cálculo do IMC:
    var calc = new Calculator();

    // Variável para validação de valores das outras variáveis:
    bool validation = true;

    // TextInfo var para formatação de texto:
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    #region "Variavel 'name'"
    string name = "";
    while (validation)
    {
        Console.Write("Nome: ");
        var name_temp = Console.ReadLine();

        // Correção da Exceção CS8600
        if (name_temp is not null && name_temp.Length > 0)
        {
            name = name_temp;
            validation = false; // Se o valor for válido
        }
    }

    name = textInfo.ToTitleCase(name.ToLower());
    #endregion

    #region "Variável 'sex'"
    validation = true;
    string sex = "";
    while (validation)
    {
        Console.Write("Sexo (Masculino ou Feminino): ");
        var sex_temp = Console.ReadLine();

        // Correção da Exceção CS8600
        if (sex_temp is not null)
        {
            sex = sex_temp.ToLower();
        }

        if (sex == "masculino" || sex == "feminino")
        {
            validation = false; // Se o valor for válido
        }
    }

    sex = textInfo.ToTitleCase(sex);
    #endregion

    #region "Variável 'age'"
    validation = true;
    double age = 0.0;
    double age_months;
    int age_years;
    while (validation)
    {
        Console.Write("Idade: ");

        // Correção da Exceção CS8600
        var age_temp = Console.ReadLine();
        #pragma warning disable CS8604 // Desabilitar alerta de uma referência possivelmente nula.
        bool validator = calc.isConversable(age_temp);
        age = calc.convertStringDouble(age_temp);
        #pragma warning restore CS8604 // O próximo 'if' corrige este problema, mas o visual studio não reconhece.

        if (age >= 1.0 && validator == true)
            {
                validation = false; // Se o valor for válido
            }

    }

    age_years = (int)age;
    age_months = (age - Math.Truncate(age)) * 12;

    string age_str;
    if (age_months > 0)
    {
        age_str = $"\nIdade: {age_years} anos e {age_months} meses";
    }
    else
    {
        age_str = $"\nIdade: {age_years} anos";
    }
    #endregion

    #region "Variável 'height'"
    validation = true;
    double height = 0.0;
    while (validation)
    {
        Console.Write("Altura (em centimetros [cm]): ");

        // Correção da Exceção CS8600
        var height_temp = Console.ReadLine();

        #pragma warning disable CS8604 // Desabilitar alerta de uma referência possivelmente nula.
        bool validator = calc.isConversable(height_temp);
        height = calc.convertStringDouble(height_temp);
        #pragma warning restore CS8604 // O próximo 'if' corrige este problema, mas o visual studio não reconhece.

        if (height > 0 && validator == true)
        {
            validation = false; // Se o valor for válido
        }
    }
    #endregion

    #region "Variável 'weight'"
    validation = true;
    double weight = 0.0;
    while (validation)
    {
        Console.Write("Peso (em quilogramas [Kg]): ");

        // Correção da Exceção CS8600
        var weight_temp = Console.ReadLine();
        #pragma warning disable CS8604 // Desabilitar alerta de uma referência possivelmente nula.
        bool validator = calc.isConversable(weight_temp);
        weight = calc.convertStringDouble(weight_temp);
        #pragma warning restore CS8604 // O próximo 'if' corrige este problema, mas o visual studio não reconhece.

        if (weight > 0 && validator == true)
        {
            validation = false; // Se o valor for válido
        }
    }
    #endregion

    // Categoria por idade:
    string category = calc.SelectCategory(age);

    // Cálculo do IMC e indicação da classificação do valor:
    double imc = calc.CalculateIMC(weight, height);
    string classification = calc.IndicateClassification(imc);

    // Indicação dos riscos:
    string risk = calc.IndicateRisks(imc);

    // Indicação das recomendações:
    string recommendation = calc.RecommendSolution(imc);

    #region "Print diagnostic"
    Console.WriteLine("\n***************************************************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO");
    Console.Write($"\nNome: {name}");
    Console.Write($"\nSexo: {sex}");
    Console.Write(age_str);
    Console.Write($"\nAltura: {height/100:0.00} m");
    Console.Write($"\nPeso: {weight} Kg");
    Console.WriteLine($"\nCategoria: {category}");
    Console.WriteLine($"\nIMC Desejável: entre 20 e 24");
    Console.WriteLine($"\nResultado IMC: {imc:0.00} ({classification})");
    Console.WriteLine($"\nRiscos: {risk}");
    Console.WriteLine($"\nRecomendação inicial: {recommendation}");
    Console.WriteLine("\n***************************************************");
    #endregion
}

Diagnostic();