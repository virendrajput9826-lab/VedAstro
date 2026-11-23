using System;

namespace VedAstro.Library;

[Flags]
public enum TarabalaName
{
	Janma = 1,
	Sampat = 2,
	Vipat = Janma | Sampat,
	Kshema = 4,
	Pratyak = Janma | Kshema,
	Sadhana = Sampat | Kshema,
	Naidhana = Vipat | Kshema,
	Mitra = 8,
	ParamaMitra = Janma | Mitra
}
