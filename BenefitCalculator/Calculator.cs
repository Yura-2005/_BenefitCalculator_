namespace BenefitCalculator
{
    public static class Calculator
    {
        public static double CalculateTotal(string category, double electricity, double gas, double water, double area)
        {
            // Логіка розрахунку знижки
            double discount = 0;

            if (category == "Одинокий інвалід")
                discount = 1.0; // 100%
            else if (category == "Особа з інвалідністю (50%)")
                discount = 0.5; // 50%
            else if (category == "Ветеран УПА (75%)")
                discount = 0.25; // 75%

            // Розрахунок загальної суми до знижки
            double totalBeforeDiscount = (electricity * 4.32) + (gas * 8) + (water * 90);

            // Розрахунок вартості після застосування знижки
            double totalCost = discount == 1.0 ? totalBeforeDiscount : totalBeforeDiscount * (1 - discount);

            return totalCost;
        }
    }
}