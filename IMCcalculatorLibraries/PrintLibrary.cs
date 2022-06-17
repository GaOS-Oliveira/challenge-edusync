using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IMCcalculatorLibraries
{
    public class PrintLibrary
    {
        Calculator calc = new Calculator();
        readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        public string getName()
        {
            bool validation = true;
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
            return name;
        }

        public string getSex()
        {
            bool validation = true;
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

                if (sex == "masculino" || sex == "feminino" || sex == "m" || sex == "f")
                {
                    validation = false; // Se o valor for válido
                }
            }

            if (sex == "f")
            {
                sex = "Feminino";
            }
            else if (sex == "m")
            {
                sex = "Masculino";
            }
            
            sex = textInfo.ToTitleCase(sex);
            return sex;
        }

        public Tuple<int, int> getAge()
        {
            bool validation = true;
            double age = 0.0;
            int age_months;
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
            age_months = (int)((age - Math.Truncate(age)) * 12);

            return Tuple.Create(age_years, age_months);
        }

        public string getAgeString(int age_years, int age_months)
        {
            string age_str;
            if (age_months > 0)
            {
                age_str = $"\nIdade: {age_years} anos e {age_months} meses";
            }
            else
            {
                age_str = $"\nIdade: {age_years} anos";
            }

            return age_str;
        }

        public double getHeight()
        {
            bool validation = true;
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

                if (height > 25 && height < 230 && validator == true)
                {
                    validation = false; // Se o valor for válido
                }
            }

            return height;
        }

        public double getWeight()
        {
            bool validation = true;
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

                if (weight > 5 && weight < 400 && validator == true)
                {
                    validation = false; // Se o valor for válido
                }
            }

            return weight;
        }

        public void printDiagnostic(string name, string sex, string age_str, double height, double weight, string category, double imc, string classification, string risk, string recommendation)
        {
            Console.WriteLine("\n***************************************************");
            Console.WriteLine("DIAGNÓSTICO PRÉVIO");
            Console.Write($"\nNome: {name}");
            Console.Write($"\nSexo: {sex}");
            Console.Write(age_str);
            Console.Write($"\nAltura: {height / 100:0.00} m");
            Console.Write($"\nPeso: {weight} Kg");
            Console.WriteLine($"\nCategoria: {category}");
            Console.WriteLine($"\nIMC Desejável: entre 20 e 24");
            Console.WriteLine($"\nResultado IMC: {imc:0.00} ({classification})");
            Console.WriteLine($"\nRiscos: {risk}");
            Console.WriteLine($"\nRecomendação inicial: {recommendation}");
            Console.WriteLine("\n***************************************************");
        }
            
    }
}