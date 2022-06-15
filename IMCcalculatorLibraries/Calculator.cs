using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMCcalculatorLibraries
{
    public class Calculator
    {
        
        public string SelectCategory(int age)
        {
            string category = "";

            switch (age)
            {
                case < 12:
                    category = "Infantil";
                    break;
                case < 21:
                    category = "Juvenil";
                    break;
                case < 66:
                    category = "Adulto";
                    break;
                case >= 66:
                    category = "Idoso";
                    break;
            }

            return category;
        }

        public double CalculateIMC(double weight, double height)
        {
            double imc = weight / (Math.Pow(height/100, 2.0));
            return imc;
        }

        public string IndicateClassification(double imc)
        {
            string classification = "";
            
            switch (imc)
            {
                case < 20:
                    classification = "Abaixo do Peso Ideal";
                    break;
                case < 25:
                    classification = "Peso Normal";
                    break;
                case < 30:
                    classification = "Excesso de Peso";
                    break;
                case < 36:
                    classification = "Obesidade";
                    break;
                case >= 36:
                    classification = "Super Obesidade";
                    break;
            }

            return classification;
        }

        public string IndicateRisks(double imc)
        {
            string risks = "";

            switch (imc)
            {
                case < 20:
                    risks = "Muitas complicações de saúde como doenças pulmonares e cardiovasculares podem estar associadas ao baixo peso.";
                    break;
                case < 25:
                    risks = "Seu peso está ideal para suas referências.";
                    break;
                case < 30:
                    risks = "Aumento de peso apresenta risco moderado para outras doenças crônicas e cardiovasculares.";
                    break;
                case < 36:
                    risks = "Quem tem obesidade vai estar mais exposto a doenças graves e ao risco de mortalidade.";
                    break;
                case >= 36:
                    risks = "O obeso mórbido vive menos, tem alto risco de mortalidade geral por diversas causas.";
                    break;
            }

            return risks;
        }

        public string RecommendSolution(double imc)
        {
            string recommendation = "";

            switch (imc)
            {
                case < 20:
                    recommendation = "Inclua carboidratos simples em sua dieta, além de proteínas - indispensáveis para ganho de massa magra. Procure um profissional.";
                    break;
                case < 25:
                    recommendation = "Mantenha uma dieta saudável e faça exames periódicos.";
                    break;
                case < 30:
                    recommendation = "Adote um tratamento baseado em dieta balanceada, exercício físico e medicação. A ajuda de um profissional pode ser interessante.";
                    break;
                case < 36:
                    recommendation = "Adote uma dieta alimentar rigorosa, com o acompanhamento de um nutricionista e um médico especialista (endócrino).";
                    break;
                case >= 36:
                    recommendation = "Procure com urgência o acompanhamento de um nutricionista para realizar reeducação alimentar, um psicólogo e um médico especialista (endócrino).";
                    break;
            }

            return recommendation;
        }
    }
}
