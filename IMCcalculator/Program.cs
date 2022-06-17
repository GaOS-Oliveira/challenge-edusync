using IMCcalculatorLibraries;
using System.Globalization;

static void getDiagnostic()
{
    var calc = new Calculator();

    var print = new PrintLibrary();

    Console.WriteLine("**********************");
    Console.WriteLine("DIAGNÓSTICO PRÉVIO\n");

    string name = print.getName();

    string sex = print.getSex();

    // Categoria por idade:
    var age = print.getAge();
    string category = calc.SelectCategory(age.Item1);
    string age_str = print.getAgeString(age.Item1, age.Item2);

    // Cálculo do IMC e indicação da classificação do valor:
    double height = print.getHeight();
    double weight = print.getWeight();

    double imc = calc.CalculateIMC(weight, height);
    string classification = calc.IndicateClassification(imc);

    // Indicação dos riscos:
    string risk = calc.IndicateRisks(imc);

    // Indicação das recomendações:
    string recommendation = calc.RecommendSolution(imc);

    #region "Confirmation"
    bool validation = true;
    string input_confirm = "";
    while (validation)
    {
        Console.Write("\nDeseja alterar os dados? [S]/[N]");
        var input_temp = Console.ReadLine();

        // Correção da Exceção CS8600
        if (input_temp is not null)
        {
            input_confirm = input_temp.ToLower();
        }

        if (input_confirm == "s" || input_confirm == "n")
        {
            validation = false; // Se o valor for válido
        }

        if (input_confirm == "s")
        {
            getDiagnostic();
        }
        else
        {
            print.printDiagnostic(name, sex, age_str, height, weight, category, imc, classification, risk, recommendation);

        }
    }
    #endregion
}

getDiagnostic();