using PowerGuard.Models;

namespace PowerGuard.Services;

public static class RulesEngine
{
    public static string GetRecommendation(EnergyEvent e)
    {
        if (e.DurationMinutes > 90)
            return "Reforçar a infraestrutura elétrica na região.";

        if (e.Cause.ToLower().Contains("chuva"))
            return "Inspecionar drenagem e sistemas de proteção.";

        return "Monitoramento padrão e suporte da concessionária.";
    }
}
