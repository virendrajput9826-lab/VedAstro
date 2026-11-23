namespace VedAstro.Library;

public record struct GhatakaRow(ZodiacName MoonSign, LunarDayGroup TithiGroup, DayOfWeek WeekDay, ConstellationName MoonConstellation, ZodiacName LagnaSameSex, ZodiacName LagnaOppositeSex);
