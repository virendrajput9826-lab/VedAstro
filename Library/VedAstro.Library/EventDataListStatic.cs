using System.Collections.Generic;

namespace VedAstro.Library;

public static class EventDataListStatic
{
	public static List<EventData> Rows = new List<EventData>
	{
		new EventData(EventName.GhatakaMoonSign, EventNature.Bad, SpecializedSummary.Empty, " injury is on reputation, ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.GhatakaChakra
		}, EventManager.GetEventCalculatorMethod(EventName.GhatakaMoonSign)),
		new EventData(EventName.GhatakaTithiGroup, EventNature.Bad, SpecializedSummary.Empty, " the injury is more mental and emotional. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.GhatakaChakra
		}, EventManager.GetEventCalculatorMethod(EventName.GhatakaTithiGroup)),
		new EventData(EventName.GhatakaWeekDay, EventNature.Bad, SpecializedSummary.Empty, " the injury is more physical ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.GhatakaChakra
		}, EventManager.GetEventCalculatorMethod(EventName.GhatakaWeekDay)),
		new EventData(EventName.GhatakaMoonConstellation, EventNature.Bad, SpecializedSummary.Empty, " the injury is more mental and emotional. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.GhatakaChakra
		}, EventManager.GetEventCalculatorMethod(EventName.GhatakaMoonConstellation)),
		new EventData(EventName.GhatakaLagna, EventNature.Bad, SpecializedSummary.Empty, " the injury is more physical ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.GhatakaChakra
		}, EventManager.GetEventCalculatorMethod(EventName.GhatakaLagna)),
		new EventData(EventName.BirdRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Bird is at its highest activity of strength. Ruling, all his endeavours are crowned with success, he wins over others. He succeeds in interviews, he wins over the heart of his fiancé, he succeeds in any work which he starts during this time, his illness is cured if treatment is started during this time. At this stage; a girl attaining puberty (appearance of first period), lives in a highest standard of life happily throughout. Apart from the above this can be applied in the same way such as starting for a travel, going to see the higher-ups, performing marriage, starting education for the first time in life (putting to school first), accepting a new job, joining a new job, taking a new assignment or taking oath of allegiance for the post of Ministers, Head ofthe Departments etc. When once started, during the strongest ebb of vibrations or activities all these endeavours get succeeded ", new List<EventTag>(1) { EventTag.PanchaPakshi }, EventManager.GetEventCalculatorMethod(EventName.BirdRuling)),
		new EventData(EventName.BirdEating, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The eating activity gets defeated by Ruling activity but wins over the remaining three viz.. Walking, Sleeping and Dying ", new List<EventTag>(1) { EventTag.PanchaPakshi }, EventManager.GetEventCalculatorMethod(EventName.BirdEating)),
		new EventData(EventName.BirdWalking, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Walking activity gets defeated by Ruling and Eating activity but wins over the other two activities viz.. Sleeping and Dying. ", new List<EventTag>(1) { EventTag.PanchaPakshi }, EventManager.GetEventCalculatorMethod(EventName.BirdWalking)),
		new EventData(EventName.BirdSleeping, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.PanchaPakshi }, EventManager.GetEventCalculatorMethod(EventName.BirdSleeping)),
		new EventData(EventName.BirdDying, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.PanchaPakshi }, EventManager.GetEventCalculatorMethod(EventName.BirdDying)),
		new EventData(EventName.GoodLunarDayForTravel, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " For journeys/travel the best lunar days are the 2nd, 3rd, 5th, 7th, 10th, 11th and 13th. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.GoodLunarDayForTravel)),
		new EventData(EventName.BadLunarDayForTravel, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " For journeys/travel the 14th lunar day and Full and New Moon days should be avoided at any cost. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadLunarDayForTravel)),
		new EventData(EventName.GoodConstellationForTravel, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " If a journey is undertaken in the following constellations, the person is supposed to return back early after satisfactorily completing his work: Mrigasira, Aswini, Pushya, Punarvasu, Hasta, Anuradha, Sravana, Moola, Dhanishta and Revati. It is better that the journey is commenced in the 2nd, 3rd or last quarter of the constellation. The first quarter may be avoided as far as possible. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.GoodConstellationForTravel)),
		new EventData(EventName.BadConstellationForTravel, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " No journey should be undertaken on days ruled by Krithika, Bharani. Aslesha. Visakha, Pubba, Poorvabhadra and Aridra. Of these, the following nakshatras may be deemed fit for travelling beyond the spheres of evil influence: - Krittika - 13 ghatis; Bharani - 7; Makha - 14; Pubba, Poorvashadha and Poorvabhadra - 16; Swati, Aslesha and Visakha - 14. In our humble experience, it is found that Bharani and Krithika should always be avoided while the other stars given in this paragraph, journeys can be undertaken in. We have to emphasize that Bharani and Krithika should be invariably rejected. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadConstellationForTravel)),
		new EventData(EventName.BadWeekdayForTravelEast, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Do not travel towards the East on Saturday and Monday Provided the journey is timed to begin beyond 8 ghatis on Saturday and Monday, the above restriction does not hold good. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadWeekdayForTravelEast)),
		new EventData(EventName.BadWeekdayForTravelSouth, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Do not travel towards South on Thursday. Provided the journey is timed to begin beyond 22 ghatis on Thursday, the above restriction does not hold good. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadWeekdayForTravelSouth)),
		new EventData(EventName.BadWeekdayForTravelWest, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Do not travel towards West on Sunday and Friday. Provided the journey is timed to begin beyond 15 ghatis on Friday and Sunday, the above restriction does not hold good. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadWeekdayForTravelWest)),
		new EventData(EventName.BadWeekdayForTravelNorth, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Do not travel towards North on Wednesday and Tuesday. Provided the journey is timed to begin beyond 12 ghatis on Tuesday and Wednesday, the above restriction does not hold good In our view, Tuesday must preferably be avoided. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadWeekdayForTravelNorth)),
		new EventData(EventName.GoodLagnaForTravel, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aries, Taurus, Cancer, Leo, Libra and Sagittarius are favorable signs for starting on a journey. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.GoodLagnaForTravel)),
		new EventData(EventName.BestLagnaForTravel, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rising sign at the time of journey being one's Janma Rasi is highly favoured. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BestLagnaForTravel)),
		new EventData(EventName.WorstLagnaForTravel, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rising sign at the time of journey should never be the sign of one's Janma Lagna. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.WorstLagnaForTravel)),
		new EventData(EventName.BadLagnaForTravel, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Journey should not also be undertaken when the Lagna is the 5th, 7th or the 9th from one's Janma Lagna. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.BadLagnaForTravel)),
		new EventData(EventName.GoodPlanetsInLagnaForTravel, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Let Jupiter or Venus be well placed in Lagna at the time of starting. This makes the journey successful. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.GoodPlanetsInLagnaForTravel)),
		new EventData(EventName.GoodMoonJupiterTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon should be in the 3rd, 6th, 9th or 12th and Jupiter in a kendra from Lagna. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.GoodMoonJupiterTravelYoga)),
		new EventData(EventName.FortifiedMoonTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Start when the Moon is in Lagna fortified by the disposition of Jupiter or Venus in a kendra. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.FortifiedMoonTravelYoga)),
		new EventData(EventName.StrongJupiterTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter strong in Lagna and the Moon in any place other than the 8th would be a strong combination. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.StrongJupiterTravelYoga)),
		new EventData(EventName.EasyPeacefulTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The journey will be easy and peaceful if the Moon be in the 7th and Venus and Mercury be in the 4th. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.EasyPeacefulTravelYoga)),
		new EventData(EventName.NeutralizeBadTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury in the 4th, Jupiter in the 2nd or 7th will neutralize all the other adverse influences. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.NeutralizeBadTravelYoga)),
		new EventData(EventName.StrongBeneficsTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Benefics dignified in kendras or trikonas act as powerful antidotes for all evils. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.StrongBeneficsTravelYoga)),
		new EventData(EventName.IdealPlanetsTravelYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter in Lagna, malefics in Upachayas and Venus in any house other than the 7th would be an ideal combinations. ", new List<EventTag>(1) { EventTag.Travel }, EventManager.GetEventCalculatorMethod(EventName.IdealPlanetsTravelYoga)),
		new EventData(EventName.AmritaSiddhaYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sunday to Saturday respectively coinciding with the constellations Hasta, Sravana, Aswini, Anuradha, Pushya, Revati and Rohini will give rise to Amita Siddha Yoga. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.AmritaSiddhaYoga)),
		new EventData(EventName.PanchangaSuddhi, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Panchanga Suddhi. - We have already said that a Panchanga consists of tithi, vara, nakshatra. yoga and karana. All these must be auspicious. In regard to lunar days, the 4th, 6th, 8th, 12th and 14th, full and new moon days should be avoided. In regard to vara, Thursday and Friday are held to be suitable for all works. Tuesday, is to be generally avoided except when it happens to be the 10th, 12th or 16th day of the child's birth when the child's Namakarana (baptising or giving name) may be performed. Of the several Nakshatras, Bharani and Krittika should be avoided for all auspicious works as these two are said to be presided o ver by the god of death (Yama) and the god of fire (Agni) respectively. In urgent cases if the Lagna could be fortified, the dosha due to nakshatra may get neutralised. The last parts of Aslesha, Jyeshta and Revati should also be avoided. Coming to the Yoga (vide page 12) the 6th (Atiganda). 9th (Soola). 10th (Ganda), 17th (Vyatipata) and 27th (Vydhruti) have deleterious effects upon events which are started or commenced under them. - The Karana chosen must be appropriate to the election in view. Thus Bava is auspicious for starting works of permanent importance while Thaithula is propitious for marriage. Bhadra is unfit for any good work but is eminently suitable for violent and cruel deeds. For getting initiation into kshudra mantras Sakuni Havana is propitious. Therefore, Panchanga Suddhi means a good lunar day, a beneficial weekday, an auspicious constellation, a good yoga and a fertilising Karana. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.PanchangaSuddhi)),
		new EventData(EventName.UgraYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Any treatment commenced under Ugra yogas are supposed to prove successful. Ugra yogas arise when the 3rd (or 9th), 4th, 5th, 6th, 7th, 9th, 10th, 12th (or 3rd) and 13th lunar days coincide respectively with Rohini, Uttara, Sravana, Mrigasira. Revats, Krittika, Pushva, Anuradha. Krittika (or Makha). ", new List<EventTag>(1) { EventTag.Medical }, EventManager.GetEventCalculatorMethod(EventName.UgraYoga)),
		new EventData(EventName.SuryaSankramana, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The 2nd great evil is Surya Sankramana or the solar ingress into different zodiacal signs. When the Sun is about to leave one sign and enter another there seem to occur certain disturbances in the organisation of the solar forces and such times are not recommended for any good work. On the contrary, they are held to be propitious for meditation, initiation into secret mantras and performance of certain religious rites which are held to purify not only the bodily electrical discharges but also the mental currents. Sixteen ghatis (6 hours 24 minutes) both before and after the entry of the Sun into a new sign should be rejected for all new works. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.SuryaSankramana)),
		new EventData(EventName.KarthariDosha, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Karthari means scissors. In an election, when two evil planets are placed on either side of the Lagna, the combination goes under the special name of Karthari Dosha and it should be rejected for good work particularly in regard to marriage. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.KarthariDosha)),
		new EventData(EventName.ShashtashtaRiphagathaChandraDosha, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Shashtashta Riphagatha Chandra Dosha. - The Moon should invariably be avoided in the 6th, 8th and 12th houses from the Lagna rising in an election chart. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.ShashtashtaRiphagathaChandraDosha)),
		new EventData(EventName.SagrahaChandraDosha, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagraha Chandra Dosha. - The Moon's association (conjunction) with any other planet, benefic or malefic, should be avoided. This injunction is specially applicable in case of marriage. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.SagrahaChandraDosha)),
		new EventData(EventName.UdayasthaSuddhi, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Udayasta Suddhi. - The Lagna and the seventh should be strong. The Lagna should be occupied by its own lord and the Navamsa Lagna by its own lord or vice versa or lord of Lagna should aspect Navamsa Lagna and vice versa. Similarly the seventh and the lord of the seventh Bhava should be favourably disposed. The strength of Lagna and the seventh is necessary in all elections but especially so in regard to marriage. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.UdayasthaSuddhi)),
		new EventData(EventName.SiddhaYoga, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When a certain weekday coincides with a certain asterism and a certain lunar day, it becomes specialy auspicious for good work. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.SiddhaYoga)),
		new EventData(EventName.SakunaKarana, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "For getting initiations into mantras Sakini Karana is propitious", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.SakunaKarana)),
		new EventData(EventName.BadNithyaYoga, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Bad),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Coming to the Yoga the 6th (Atiganda). 9th (Soola). 10th (Ganda), 17th (Vyatipata) and 27th (Vydhruti) have deleterious effects upon events which are started or commenced under them. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.BadNithyaYoga)),
		new EventData(EventName.LagnaThyajya, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Even when the ascendant is strong, certain parts of it which go under the name of Lagna tyajya should be rejected. In Aries, Taurus, Sagittarius and Virgo, the first three degrees should be avoided as it is supposed to be in the nature of a serpent (bhujanga) and hence destructive. In regard to Pisces, Capricorn, Cancer and Scorpio, the last (three degrees) has to be avoided as it is supposed to be presided over by the evil force of Rahu. The middle half ghati (13° 30' to 16° 30') should be rejected with regard to Gemini, Libra, Leo and Aquarius as it is ruled by an evil force termed Gridhra. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.LagnaThyajya)),
		new EventData(EventName.GoodPanchaka, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Panchaka (Five-Source Energy): For matters of ordinary importance such as interviewing superiors or going on short journeys, a favourable Tarabala will do and there is no need to consider the panchaka. But in regard to very important ceremonies such as marriage, nuptials, entry into new houses, etc., this should be carefully looked into. Five sources of planetary, stellar and zodiacal energies are involved. Take the number of the lunar day (from the 1st of the month), the number of the weekday, Sunday 1. etc.), the number of the constellation (from Aswini) and the number of the Lagna (from Aries). Add these together and divide the total by 9. ", new List<EventTag>(1) { EventTag.Personal }, EventManager.GetEventCalculatorMethod(EventName.GoodPanchaka)),
		new EventData(EventName.BadPanchaka, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Panchaka (Five-Source Energy): For matters of ordinary importance such as interviewing superiors or going on short journeys, a favourable Tarabala will do and there is no need to consider the panchaka. But in regard to very important ceremonies such as marriage, nuptials, entry into new houses, etc., this should be carefully looked into. Five sources of planetary, stellar and zodiacal energies are involved. Take the number of the lunar day (from the 1st of the month), the number of the weekday, Sunday 1. etc.), the number of the constellation (from Aswini) and the number of the Lagna (from Aries). Add these together and divide the total by 9. ", new List<EventTag>(1) { EventTag.Personal }, EventManager.GetEventCalculatorMethod(EventName.BadPanchaka)),
		new EventData(EventName.BhriguShatka, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The position of Venus in the 6th is injurious. This is especially so in regard to marriage. Even when Venus is exalted and associated with benefics, such a disposition is not approved. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.BhriguShatka)),
		new EventData(EventName.Kujasthama, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mars should be avoided in the 8th house, as it indicates destruction of the object in view. In a marriage election chart. Mars in the 8th is unthinkable. Even if Mars is otherwise powerful, he should not occupy the 8th house. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.Kujasthama)),
		new EventData(EventName.GoodHairCutting, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Shaving may be had in the constellations of Pushya, Punarvasu, Rcvati, Hasta, Sravana, Dhanista, Mrignsira, Aswini, Chitta, Jyeshta, Satabliislia and Swati. 4th, Gth and 14th lunar days as also New Moon and Full Moon days arc not desirable. And solar and lunar eclipses. ", new List<EventTag>(1) { EventTag.HairNailCutting }, EventManager.GetEventCalculatorMethod(EventName.GoodHairCutting)),
		new EventData(EventName.GoodNailCutting, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Avoid Fridays and Saturdays - the 8th, 9th, 14th lunar days as well as New and Full Moon days. ", new List<EventTag>(1) { EventTag.HairNailCutting }, EventManager.GetEventCalculatorMethod(EventName.GoodNailCutting)),
		new EventData(EventName.FixedConstellationRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rohini, Uttara, Uttarashadha and Uttarabhadra are supposed to be fixed constellations and they are favourable for coronations, laying the foundations of cities, sowing operations, planting trees and other permanent things. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.FixedConstellationRuling)),
		new EventData(EventName.SoftConstellationRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Chitta, Anuradha, Mrigasira and Revati are soft constellations. They are good for wearing new apparel, learning dancing, music and fine arts, sexual union and performance of auspicious ceremonies. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.SoftConstellationRuling)),
		new EventData(EventName.LightConstellationRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aswini, Pushya, Hasta and Abhijit are light constellations, and they can be selected for putting ornamentation, pleasures and sports, administering medicine, starting industries and undertaking travels. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.LightConstellationRuling)),
		new EventData(EventName.SharpConstellationRuling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Moola, Jyestha, Aridra and Aslesha are sharp in nature and they are favourable for incantations, invoking spirits, for imprisonment, murders, and separation of friends. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.SharpConstellationRuling)),
		new EventData(EventName.MovableConstellationRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Saravana, Dhanishta, Satabhisha, Punarvasu and Swati are movable stars and they are auspicious for acquiring vehicles, for gardening and for going on procession. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.MovableConstellationRuling)),
		new EventData(EventName.DreadfulConstellationRuling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Pubba, Poorvashadha and Poorvabhadra, Bharani and Makha are dreadful stars and they are suitable for nefarious schemes, poisoning, deceit, imprisonment, setting fire and other evil deeds. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.DreadfulConstellationRuling)),
		new EventData(EventName.MixedConstellationRuling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Krittika and Visakha are mixed constellations and during their influences, works of day-to-day importance can be undertaken. ", new List<EventTag>(2)
		{
			EventTag.RulingConstellation,
			EventTag.General
		}, EventManager.GetEventCalculatorMethod(EventName.MixedConstellationRuling)),
		new EventData(EventName.BadForStartingAllAgriculture, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " While beginning all agricultural operations, see that the 8th house is unoccupied. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.BadForStartingAllAgriculture)),
		new EventData(EventName.LagnaLordIsWeekdayLord, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Lagna owned by the planet who is lord of the weekday in question. ", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.LagnaLordIsWeekdayLord)),
		new EventData(EventName.GoodLunarDayAgriculture, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " All odd lunar days except the 9th are good. All even tithis except the 2nd and 4th should be avoided. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodLunarDayAgriculture)),
		new EventData(EventName.BadLagnaForAllAgriculture, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini: Not favourable for any planting being a barren sign. Leo: Not good for any planting, especially bad for underground plants such as potato. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.BadLagnaForAllAgriculture)),
		new EventData(EventName.GoodYogaForAllAgriculture, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Good yoga for all agriculture is formed when: 1. A good lunar day for planting 2. Lagna owned by the planet who is lord of the weekday 3. Beginning all agricultural operations, see that the 8th house is unoccupied 4. No malefic rising sign (Gemini and Leo) ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodYogaForAllAgriculture)),
		new EventData(EventName.GoodAnySeedsSowing, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Any seeds can be sown on a day ruled by Hasta, Chitta, Swati, Makha, Pushyami, Uttara, Uttarashadha, Uttarabhadra, Rohini, Revati, Aswini, Moola or Anuradha provided the lunar day is also propitious. Choose a Lagna, owned by the planet who is lord of the weekday in question. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodAnySeedsSowing)),
		new EventData(EventName.Ekadashi, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " It is the 11th tithi. Special religious significance in Hindu tradition, usually it's observed by fasting. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.Ekadashi)),
		new EventData(EventName.NotAuspiciousDay, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Tuesday and Saturday should be avoided for all good and auspicious works. Tuesday is not evil after midday ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.NotAuspiciousDay)),
		new EventData(EventName.GoodPlanetsInLagna, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus, Mercury or Jupiter in the ascendant will completely destroy all other adverse influences. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.GoodPlanetsInLagna)),
		new EventData(EventName.GoodForPlantingFloweringPlants, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting flowering plants when Virgo is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFloweringPlants)),
		new EventData(EventName.GoodForPlantingGarlic, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting garlic when Aries is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingGarlic)),
		new EventData(EventName.GoodForPlantingPeachAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting peach, plum, potatoes, radishes, onion sets and turnips when Taurus is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingPeachAndOthers)),
		new EventData(EventName.GoodForPlantingTomatoesAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Good for planting beans, cabbage, corn, cucumber, lettuce, melons, pumpkins, tomatoes, cauliflower, water melons, and cereals when Cancer is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingTomatoesAndOthers)),
		new EventData(EventName.GoodForPlantingGrains, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting wheat, rye, barley, rice and other field crops when Libra is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingGrains)),
		new EventData(EventName.GoodForPlantingOnionAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Good for planting garlic and onion seeds when Scorpio is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingOnionAndOthers)),
		new EventData(EventName.GoodForPlantingPepperAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting Pepper and other spring crops and garlic when Sagittarius is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingPepperAndOthers)),
		new EventData(EventName.GoodForPlantingPotatoAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting potato, radishes and turnips when Capricorn is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingPotatoAndOthers)),
		new EventData(EventName.GoodForPlantingGrainsAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting all black cereals and grains when Aquarius is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingGrainsAndOthers)),
		new EventData(EventName.GoodForPlantingPumpkinsAndOthers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Good for planting cucumbers, pumpkins, radishes, water-melons and carrots when Pisces is rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingPumpkinsAndOthers)),
		new EventData(EventName.GoodForPlantingTrees, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting trees in Rohini and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingTrees)),
		new EventData(EventName.GoodForPlantingSugarcane, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for planting sugarcane in Punarvasu and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingSugarcane)),
		new EventData(EventName.GoodForPlantingFlowerSeeds, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Seeds of flower plants, and fruit-bearing creepers should be sown in the asterisms of Mriyusira, Punarvasu, Hasta, Chitta, Swati, Anuradha and Revati and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFlowerSeeds)),
		new EventData(EventName.GoodForPlantingFruitTrees, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Seedlings of long-lived fruit trees when Jupiter is in Lagna on Thursday OR Fruit trees may be planted when Sagittarius and Pisces are rising on Thursday and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFruitTrees)),
		new EventData(EventName.GoodForPlantingFlowerTrees, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Seedlings of flower trees when Venus is in Lagna on Friday and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFlowerTrees)),
		new EventData(EventName.GoodForPlantingFlowers, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Seedlings of flower sown when Mars is in Lagna on Tuesday and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFlowers)),
		new EventData(EventName.GoodForPlantingFlowerCuttings, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Flower seeds and cuttings may be sown when Taurus or Libra rising and general good time for planting. ", new List<EventTag>(1) { EventTag.Agriculture }, EventManager.GetEventCalculatorMethod(EventName.GoodForPlantingFlowerCuttings)),
		new EventData(EventName.GoodRullingConstellation, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pushya rulling is a constellation par excellence that could be universally employed for all purposes, excepting of course marriage ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.GoodRullingConstellation)),
		new EventData(EventName.BadRullingConstellation, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Certain constellations, apart from their being harmonious or otherwise disposed with reference to one's own Janma Nakshatra, should be avoided for certain specific purposes on account of their inherent evil natures. In fact, Bharani is condemned for all good work and it has to be scrupulously avoided for all good work. When a constellation like Bharani(beta Arietis) is held to be constitutionally unfit for certain types of elections; it means that the vibrations emanating from it are destructive in character Of the several Nakshatras, Bharani and Krittika should be avoided for all auspicious works as these two are said to be presided over by the god of death (Yama) and the god of fire (Agni) respectively. In urgent cases if the Lagna could be fortified, the dosha due to nakshatra may get neutralised. The last parts of Aslesha, Jyeshta and Revati should also be avoided. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.BadRullingConstellation)),
		new EventData(EventName.GoodTakingInjections, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Injections may be taken on Saturday or Monday. Aries, Taurus. Cancer and Virgo are auspicious. The 8th house must be unoccupied. See that Mercury is free from affliction; as otherwise the pain wilt be severe and nervous weakness may set in. ", new List<EventTag>(1) { EventTag.Medical }, EventManager.GetEventCalculatorMethod(EventName.GoodTakingInjections)),
		new EventData(EventName.GoodSellingForProfit, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Selling for Profit. - Let the Moon and Mercury be free from the conjunction or aspect of Mars. The Moon's situation in Taurus. Cancer or Pisces would greatly help the seller. Try to keep Mercury in a kendra from Lagna or at least in good aspect to Jupiter. Tuesday should be avoided. Monday, Wednesday and Thursday are the best. While Friday is unpropitious, Saturday is middling. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodSellingForProfit)),
		new EventData(EventName.BavaKarana, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Bava is auspicious for starting works of permanent importance. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.BavaKarana)),
		new EventData(EventName.TaitulaKarana, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Thaithula is propitious for marriage ", new List<EventTag>(1) { EventTag.Marriage }, EventManager.GetEventCalculatorMethod(EventName.TaitulaKarana)),
		new EventData(EventName.BhadraKarana, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Bhadra is unfit for any good work but is eminently suitable for violent and cruel deeds. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.BhadraKarana)),
		new EventData(EventName.JanmaNakshatraRulling, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " A day ruled by one's Janma Nakshatra is ordinarily held to be unfavourable for an election. But in regard to nuptials, sacrifices, first feeding, agriculture, upanayanam, coronation, buying lands, learning the alphabet, Janma Nakshatra is favourable without exception. But it is inauspicious for war, sexual union, shaving, taking medical treatment, travel and marriage. For a woman, Janma Nakshatra would be quite favourable for marriage. ", new List<EventTag>(1) { EventTag.Personal }, EventManager.GetEventCalculatorMethod(EventName.JanmaNakshatraRulling)),
		new EventData(EventName.Yama1, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Astronomical,
			EventTag.YamaNumber
		}, EventManager.GetEventCalculatorMethod(EventName.Yama1)),
		new EventData(EventName.Yama2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Astronomical,
			EventTag.YamaNumber
		}, EventManager.GetEventCalculatorMethod(EventName.Yama2)),
		new EventData(EventName.Yama3, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Astronomical,
			EventTag.YamaNumber
		}, EventManager.GetEventCalculatorMethod(EventName.Yama3)),
		new EventData(EventName.Yama4, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Astronomical,
			EventTag.YamaNumber
		}, EventManager.GetEventCalculatorMethod(EventName.Yama4)),
		new EventData(EventName.Yama5, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Astronomical,
			EventTag.YamaNumber
		}, EventManager.GetEventCalculatorMethod(EventName.Yama5)),
		new EventData(EventName.SunIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.SunIsStrong)),
		new EventData(EventName.MoonIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.MoonIsStrong)),
		new EventData(EventName.MarsIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.MarsIsStrong)),
		new EventData(EventName.MercuryIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.MercuryIsStrong)),
		new EventData(EventName.JupiterIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.JupiterIsStrong)),
		new EventData(EventName.VenusIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.VenusIsStrong)),
		new EventData(EventName.SaturnIsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.SaturnIsStrong)),
		new EventData(EventName.House1IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House1IsStrong)),
		new EventData(EventName.House2IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House2IsStrong)),
		new EventData(EventName.House3IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House3IsStrong)),
		new EventData(EventName.House4IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House4IsStrong)),
		new EventData(EventName.House5IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House5IsStrong)),
		new EventData(EventName.House6IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House6IsStrong)),
		new EventData(EventName.House7IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House7IsStrong)),
		new EventData(EventName.House8IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House8IsStrong)),
		new EventData(EventName.House9IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House9IsStrong)),
		new EventData(EventName.House10IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House10IsStrong)),
		new EventData(EventName.House11IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House11IsStrong)),
		new EventData(EventName.House12IsStrong, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.House12IsStrong)),
		new EventData(EventName.BadForBuyingToolsUtensilsJewellery, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Utensils, etc. Avoid the asterisms of Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th and 9th lunar days and New Moon. Buying Jewellery. As usual unfavourable lunar days and asterisms should be avoided. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.BadForBuyingToolsUtensilsJewellery)),
		new EventData(EventName.GoodForBuyingBrassVessels, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Utensils, etc. - Place Jupiter in good aspect to the Moon while buying brass vessels. Avoid the asterisms of Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th and 9th lunar days and New Moon. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodForBuyingBrassVessels)),
		new EventData(EventName.GoodForBuyingCopperVessels, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Utensils, etc. - Place Jupiter in good aspect to Mars when buying vessels of copper. Avoid the asterisms of Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th and 9th lunar days and New Moon. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodForBuyingCopperVessels)),
		new EventData(EventName.GoodForBuyingSteelIronVessels, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Utensils, etc. - Place Jupiter in good aspect to Saturn if steel and iron. Avoid the asterisms of Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th and 9th lunar days and New Moon. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodForBuyingSteelIronVessels)),
		new EventData(EventName.GoodForBuyingSilverVessels, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Utensils, etc. - Place Jupiter in good aspect to ascendant if of silver. Avoid the asterisms of Aslesha. Moola and Jyeshta. For buying tools, similarly avoid the 8th and 9th lunar days and New Moon. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodForBuyingSilverVessels)),
		new EventData(EventName.GoodForBuyingJewellery, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Buying Jewellery. - The Sun and the Moon should be well situated and aspected. As usual unfavourable lunar days and asterisms should be avoided. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodForBuyingJewellery)),
		new EventData(EventName.GoodPlanetsIn11th, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The mere presence of the Moon or the Sun in the 11th will act as an antidote for other evils obtaining in the horoscope. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.GoodPlanetsIn11th)),
		new EventData(EventName.GoodPlanetsInKendra, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter or Venus in a kendra (quadrant) and malefics in 3, 6 or 11 will remove all the flaws arising on account of unfavourable weekday, constellation, lunar day and yoga. ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.GoodPlanetsInKendra)),
		new EventData(EventName.Sunrise, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " It has been acknowledged that it is the moment at which the centre of the solar disc rises at the eastern horizon, that marks the sunrise at the particular place. It must also be noted that on account of the refraction of the solar rays, due to the various strata enveloping the earth, the Sun is not really at the horizon where he appears to be so but is really below the horizon by about a few minutes of arc (Rekha). But we can take the apparent time as almost correct and need not worry ourselves with the so called delicate correct time of rising. ", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.Sunrise)),
		new EventData(EventName.Sunset, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " It has been acknowledged that it is the moment at which the centre of the solar disc rises at the western horizon, that marks the sunset at the particular place. It must also be noted that on account of the refraction of the solar rays, due to the various strata enveloping the earth, the Sun is not really at the horizon where he appears to be so but is really below the horizon by about a few minutes of arc (Rekha). But we can take the apparent time as almost correct and need not worry ourselves with the so called delicate correct time of setting. ", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.Sunset)),
		new EventData(EventName.Midday, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " This is marked when the centre of the Sun is exactly on the meridian of the place. The apparent noon is almost the same for all places. ", new List<EventTag>(1) { EventTag.Astronomical }, EventManager.GetEventCalculatorMethod(EventName.Midday)),
		new EventData(EventName.GoodChandrabala, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " To be at its best, the Moon should not occupy in the election chart, a position that happens to represent the 6th, 8th or 12th from the persons Janma Rasi ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Chandrabala
		}, EventManager.GetEventCalculatorMethod(EventName.GoodChandrabala)),
		new EventData(EventName.BadChandrabala, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " To be at its best, the Moon should not occupy in the election chart, a position that happens to represent the 6th, 8th or 12th from the persons Janma Rasi Exceptions: Chandrashtama (8th) shows no evil when the Moon is waxing and occupies a benefic sign and a benefic Navamsa, or when there is Tarabala. The sting is lost when the Moon and the 8th lord are friends. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Chandrabala
		}, EventManager.GetEventCalculatorMethod(EventName.BadChandrabala)),
		new EventData(EventName.TarabalaJanmaStrong, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Janma: danger to body 1st Paryaya or cycle : the evil suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaJanmaStrong)),
		new EventData(EventName.TarabalaJanmaMiddling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Janma: danger to body 2nd Paryaya or cycle : the evil is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaJanmaMiddling)),
		new EventData(EventName.TarabalaJanmaWeak, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Janma: danger to body 3rd Paryaya or cycle : the evil is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaJanmaWeak)),
		new EventData(EventName.TarabalaSampatStrong, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sampat: wealth and prosperity 1st Paryaya or cycle : the good suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSampatStrong)),
		new EventData(EventName.TarabalaSampatMiddling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sampat: wealth and prosperity 2nd Paryaya or cycle : the good is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSampatMiddling)),
		new EventData(EventName.TarabalaSampatWeak, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sampat: wealth and prosperity 3rd Paryaya or cycle : the good is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSampatWeak)),
		new EventData(EventName.TarabalaVipatStrong, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Vipat: dangers, losses and accidents 1st Paryaya or cycle : the evil suggested holds good in full It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaVipatStrong)),
		new EventData(EventName.TarabalaVipatMiddling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Vipat: dangers, losses and accidents 2nd Paryaya or cycle : the evil is said to be only fifty percent. It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaVipatMiddling)),
		new EventData(EventName.TarabalaVipatWeak, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Vipat: dangers, losses and accidents 3rd Paryaya or cycle : the evil is said to be almost negligible It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaVipatWeak)),
		new EventData(EventName.TarabalaKshemaStrong, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Kshema: prosperity 1st Paryaya or cycle : the good suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaKshemaStrong)),
		new EventData(EventName.TarabalaKshemaMiddling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Kshema: prosperity 2nd Paryaya or cycle : the good is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaKshemaMiddling)),
		new EventData(EventName.TarabalaKshemaWeak, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Kshema: prosperity 3rd Paryaya or cycle : the good is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaKshemaWeak)),
		new EventData(EventName.TarabalaPratyakStrong, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pratyak: obstacles 1st Paryaya or cycle : the evil suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaPratyakStrong)),
		new EventData(EventName.TarabalaPratyakMiddling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pratyak: obstacles 2nd Paryaya or cycle : the evil is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaPratyakMiddling)),
		new EventData(EventName.TarabalaPratyakWeak, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pratyak: obstacles 3rd Paryaya or cycle : the evil is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaPratyakWeak)),
		new EventData(EventName.TarabalaSadhanaStrong, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Sadhana: realisation of ambitions 1st Paryaya or cycle : the good suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSadhanaStrong)),
		new EventData(EventName.TarabalaSadhanaMiddling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sadhana: realisation of ambitions 2nd Paryaya or cycle : the good is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSadhanaMiddling)),
		new EventData(EventName.TarabalaSadhanaWeak, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sadhana: realisation of ambitions 3rd Paryaya or cycle : the good is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaSadhanaWeak)),
		new EventData(EventName.TarabalaNaidhanaStrong, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Naidhana: dangers 1st Paryaya or cycle : the evil suggested holds good in full It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaNaidhanaStrong)),
		new EventData(EventName.TarabalaNaidhanaMiddling, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Naidhana: dangers 2nd Paryaya or cycle : the evil is said to be only fifty percent. It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaNaidhanaMiddling)),
		new EventData(EventName.TarabalaNaidhanaWeak, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Naidhana: dangers 3rd Paryaya or cycle : the evil is said to be almost negligible It is better to avoid Vipat and Naidhana stars for all important undertakings - long journeys, marriage, starting of an enterprise, etc., even if such a star happens to fall in the 3rd-cycle, unless there are other counteracting factors. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaNaidhanaWeak)),
		new EventData(EventName.TarabalaMitraStrong, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mitra: good 1st Paryaya or cycle : the good suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaMitraStrong)),
		new EventData(EventName.TarabalaMitraMiddling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mitra: good 2nd Paryaya or cycle : the good is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaMitraMiddling)),
		new EventData(EventName.TarabalaMitraWeak, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mitra: good 3rd Paryaya or cycle : the good is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaMitraWeak)),
		new EventData(EventName.TarabalaParamaMitraStrong, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Parama Mitra: very favourable 1st Paryaya or cycle : the good suggested holds good in full ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaParamaMitraStrong)),
		new EventData(EventName.TarabalaParamaMitraMiddling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Parama Mitra: very favourable 2nd Paryaya or cycle : the good is said to be only fifty percent. ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaParamaMitraMiddling)),
		new EventData(EventName.TarabalaParamaMitraWeak, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Parama Mitra: very favourable 3rd Paryaya or cycle : the good is said to be almost negligible ", new List<EventTag>(2)
		{
			EventTag.Personal,
			EventTag.Tarabala
		}, EventManager.GetEventCalculatorMethod(EventName.TarabalaParamaMitraWeak)),
		new EventData(EventName.Papashadvargas, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Papashadvargs : Malefics should not be strong in shadvargas in an election chart. This event idicates that malefics are strong in shadvargas ", new List<EventTag>(1) { EventTag.General }, EventManager.GetEventCalculatorMethod(EventName.Papashadvargas)),
		new EventData(EventName.GoodMoonSignForSelling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Selling for Profit. - The Moon's situation in Taurus. Cancer or Pisces would greatly help the seller. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodMoonSignForSelling)),
		new EventData(EventName.GoodWeekdayForSelling, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Selling for Profit. - Monday, Wednesday and Thursday are the best. ", new List<EventTag>(1) { EventTag.BuyingSelling }, EventManager.GetEventCalculatorMethod(EventName.GoodWeekdayForSelling)),
		new EventData(EventName.GocharaSummary, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Combination of all gochara occurring at time. ", new List<EventTag>(1) { EventTag.GocharaSummary }, EventManager.GetEventCalculatorMethod(EventName.GocharaSummary)),
		new EventData(EventName.SunGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When the Sun traverses through the Rasi occupied by the Moon, the person suffers from loss of wealth, loss of prestige, sickness and will have many obstacles and aimless travels. Financial loss, discomfort, chest pain and aimless journey ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse1)),
		new EventData(EventName.SunGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When he transits in the 2nd house, there will be loss of wealth, he will suffer deceit, he will have full of financial worries. Increase of expenditure, eye trouble, deceit and unhappiness ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse2)),
		new EventData(EventName.SunGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " In the 3rd house there will be advent of money, happiness, relief from diseases, recognition from superiors, honours and courage. Increase of emoluments, freedom from sickness and destruction of enemies ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse3)),
		new EventData(EventName.SunGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 4th house, there will be diseases, constant attacks from opponents, no peace of mind, pressure from creditors, and sorrow and misery. Quarrels with wife, unhappiness in conjugal life and the general ailments ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse4)),
		new EventData(EventName.SunGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun transiting the 5th will cause mental agitation, ill-health, embarrassment and accidents. Increase of enemies and physical indisposition ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse5)),
		new EventData(EventName.SunGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " The Sun in the 6th gives rise to release from sorrows, worries and troubles, destruction of enemies and peace of mind. Success over enemies, joy and good health. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse6)),
		new EventData(EventName.SunGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun transiting the 7th, produces wearisome travelling, colic and anal troubles, humiliation and sickness. Wearisome travelling, chest pain and stomach troubles. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse7)),
		new EventData(EventName.SunGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 8th, Sun's progress gives rise to quarrels with friends, diseases, high blood pressure, royal and official displeasure. Misunderstandings with or separation from wife. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse8)),
		new EventData(EventName.SunGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun's transit in the 9th house will cause to the native danger, humiliation, dependency, disappointment and separation. Accidents, stomach trouble, mental worry and opposition. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse9)),
		new EventData(EventName.SunGocharaInHouse10, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " One will accomplish his desire and plans, and success will attend on all kinds or undertakings when the Sun is in the 10th. Success in endeavors, honour and realisation of ambition ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse10)),
		new EventData(EventName.SunGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " In the 11th, the passage of the Sun will confer on a person honour, health, wealth and success. Great success, respect, freedom from disease and prosperity. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse11)),
		new EventData(EventName.SunGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When the Sun passes through the 12th house, there will be sorrow, creation of a situation which causes loss to everything, quarrels and ill-health. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SunGocharaInHouse12)),
		new EventData(EventName.MoonGocharaInHouse1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " When the Moon transits the sign occupied by her at the time of birth of a person, the native will get excellent food, bed and clothes. Good food, comforts and clothes ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse1)),
		new EventData(EventName.MoonGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When the Moon passes through the 2nd house, loss of respect and of money and obstacles in the way of success are to be predicted. Loss of respect, money and increase of obstacles. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse2)),
		new EventData(EventName.MoonGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 3rd house, the native gets clothes, pleasure from wife and finance. Domestic happiness and access to money ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse3)),
		new EventData(EventName.MoonGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 4th, he becomes mentally uneasy. Loss of trust in others and lack of peace of mind. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse4)),
		new EventData(EventName.MoonGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 5th, suffers from humility, ill-health, pain of mind and other obstacles. Indisposition, grief and disappointment; ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse5)),
		new EventData(EventName.MoonGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " In the 6th, enjoys wealth, health, comfort, redemption from enemies. Happiness, success over enemies and good health. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse6)),
		new EventData(EventName.MoonGocharaInHouse7, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " 7th house, conveyances, good food and financial equilibrium. Respect from others and sudden influx of unexpected resources. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse7)),
		new EventData(EventName.MoonGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Moon transiting the 8th produces misery, ill-health and fear from unexpected sources. Apprehension, uneasiness and worry. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse8)),
		new EventData(EventName.MoonGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 9th from herself, pain of mind, chest pain, fatigue of body and the like are caused. Mental pain, stomach trouble and incarceration. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse9)),
		new EventData(EventName.MoonGocharaInHouse10, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When the Moon passes through the 10th house, success will attend in every sphere of activity. Success, authority and position, realisation of ambition. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse10)),
		new EventData(EventName.MoonGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 11th house, the person will enjoy prosperity, will get wealth and new friends. Prosperity, new friends and good income ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse11)),
		new EventData(EventName.MoonGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When the Moon transits through the 12th sign. He suffers from accidents and injuries. Injuries due to fall from vehicles and increased expenditure. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MoonGocharaInHouse12)),
		new EventData(EventName.MarsGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Mars passes through tbe sign occupied by the Moon at the time of birth of a person, be will suffer from troubles. Troubles from various sources and bodily affliction. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse1)),
		new EventData(EventName.MarsGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 2nd house from the Moon displeasure of king, and suffering from quarrels, from enemies and disgrace is indicated. There will be fear from thieves and the body will be afflicted with bilious and windy complaints. Trouble from the Government, frequent quarrels with enemies, disease, accidents, bilious and windy complaints and loss by theft. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse2)),
		new EventData(EventName.MarsGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Mars transiting the 3rd gives rise to gain of objects, pleasure from children, good health, access to riches and new clothes. Benefits through auspicious characters, financial improvement and acquisition of woolen articles and also authority. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse3)),
		new EventData(EventName.MarsGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 4th sign, Mars produces evil results such as fever, digestive troubles, blood discharges and depravity of character. Fever, stomachache, piles and blood discharges and frequent trouble from ailments. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse4)),
		new EventData(EventName.MarsGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Enemies will increase, fresh diseases will make their appearance and mental peace will be completely absent when Mars passes through the 5th house. Trouble from enemies, illness, misunderstandings with children and loss of physical energy. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse5)),
		new EventData(EventName.MarsGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 6th house, relief from troubles, worries and ill-health should be predicted; he leads an independent life, obtains riches and becomes pretty cheerful. Success over enemies, termination of strife in the family, and acquisition of self-confidence ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse6)),
		new EventData(EventName.MarsGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When transiting the 7th, tbe native quarrels with wife or husband, eye troubles, stomach-ache, indigestion, etc., are also likely to be felt. Frequent quarrels with wife, eye trouble and stomachache. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse7)),
		new EventData(EventName.MarsGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars transiting in the 8th produces quite unfavorable effects, such as discharging of blood, loss of wealth, disgrace and mental worry. Loss of blood from piles and anemia and loss of wealth and name. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse8)),
		new EventData(EventName.MarsGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars transiting in the 9th produces quite unfavorable effects, such as discharging of blood, loss of wealth, disgrace and mental worry.In addition, the subject becomes extremely weak. Suffering from insults, heavy expenditure and weakness due to ill-health. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse9)),
		new EventData(EventName.MarsGocharaInHouse10, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " His transiting the 10th produces quite favourable results. Amounts due will be realised. Success will attend on his ventures. Business will improve. Acquisition of money from unexpected source. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse10)),
		new EventData(EventName.MarsGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " His transiting the 11th produces quite favourable results. Amounts due will be realised. Success will attend on his ventures. Business will improve. Fame, reputation and authority ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse11)),
		new EventData(EventName.MarsGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 12th house, however,he will suffer from various expenses, troubles, diseases of the eye, pinpricks from an angry wife, from bilious complaints and various other worries. Unforeseen expenses, quarrels with wife, eye disease and bilious affections ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MarsGocharaInHouse12)),
		new EventData(EventName.MercuryGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Mercury passes through the sign occupied by the Moon at time of birth of a person, such person will suffer loss of wealth caused by the advice of wicked men, by talebearers, by imprisonment and quarrels. He will, besides, receive disagreeable intelligence when in his journey. Loss of money due to advice by wicked men, worry due to association with tale-bearers, quarrels, imprisonment and disagreeable news while travelling ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse1)),
		new EventData(EventName.MercuryGocharaInHouse2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Mercury passes through the 2nd house, the person will suffer disgrace but gains success and wealth. Disgrace, ill-treatment from relatives but acquisition of success and wealth ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse2)),
		new EventData(EventName.MercuryGocharaInHouse3, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When he passes through tbe 3rd house, the subject will get friends, will be afraid of troubles from the king and from his enemies, he will quit his place due to his wicked deeds. New friends, but anticipation of trouble from government and enemies, aimless roaming about due to misdeeds ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse3)),
		new EventData(EventName.MercuryGocharaInHouse4, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Mercury passes through the 4th house, the person's kinsmen and family will increase and there will be much gain. Prosperity for relatives and family members, addition to family and gain of money. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse4)),
		new EventData(EventName.MercuryGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 5th house, the person will quarrel with his wife and sons and will not enjoy the company of an excellent wife. Quarrels with wife and children. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse5)),
		new EventData(EventName.MercuryGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 6th house,the person will be liked by all and will gain renown. Gain of renown, success and popularity. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse6)),
		new EventData(EventName.MercuryGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 7th house, the person's appearance becomes less bright and there will be quarrels. Bloodlessness, quarrels and mental uneasiness. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse7)),
		new EventData(EventName.MercuryGocharaInHouse8, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Mercury passes through the 8th house, the person will get sons, success, clothes and wealth and will become happy and powerful. Birth of an issue, success, happiness and acquisition of new articles. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse8)),
		new EventData(EventName.MercuryGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When he passes through the 9th house from the Moon, the person will meet with obstacles in his work. Obstacles and mental worry. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse9)),
		new EventData(EventName.MercuryGocharaInHouse10, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 10th house, the person's enemies will meet with ruin and the person will get wealth, will enjoy the company of his wife and will be dressed in the flannel. Defeat of enemies, acquisition of money, happiness with wife and agreeable company. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse10)),
		new EventData(EventName.MercuryGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Mercury passes through the 11th house from the Moon, the person will get wealth, comfort, sons, women, friends and conveyance and will be happy and will receive good intelligence. Acquisition of wealth; birth of a son and happiness. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse11)),
		new EventData(EventName.MercuryGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 12th, the person will suffer disgrace from his enemies, will suffer from diseases and will not enjoy the company of a good wife. Disgrace from enemies, disease and domestic disharmony. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryGocharaInHouse12)),
		new EventData(EventName.JupiterGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the sign occupied by the Moon at the time of birth of a person, such person will lose his wealth and intelligence, will quit his place and will suffer from many quarrels. Loss of money and intelligence, aimless roaming about and frequent quarrels. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse1)),
		new EventData(EventName.JupiterGocharaInHouse2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 2nd house from the Moon, the person will have no enemies and will enjoy wealth and women. Happiness, domestic harmony and success over enemies. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse2)),
		new EventData(EventName.JupiterGocharaInHouse3, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 3rd house from the Moon, the person will quit his place and will meet with obstacles in his work. Moving about from place to place, obstacles to own work and loss of position. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse3)),
		new EventData(EventName.JupiterGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 4th house from the Moon, the person will suffer from troubles caused by his kinsmen, will become patient and resigned and will delight in nothing. Troubles from relatives, development of a sense of resignation to the inevitable. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse4)),
		new EventData(EventName.JupiterGocharaInHouse5, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 5th house from the Moon, the person will get servants, prosperity, sons, elephants, houses, bullocks, gold, women, clothes, gems and good qualities. Acquisition of servants, birth of a son, general prosperity, addition of property and development of good qualities. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse5)),
		new EventData(EventName.JupiterGocharaInHouse6, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 6th house from the Moon, the person will be so much afflicted at heart that he will take no delight in the agreeable faces of beautiful women, in the music of the peacock and the cuckoo and in houses made pleasant by the frolic of children playing like the young of the deer. Affliction of mind, friends turning enemies and indifferent to good things. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse6)),
		new EventData(EventName.JupiterGocharaInHouse7, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 7th house from the Moon, the person will enjoy good bed, the company of an excellent woman, wealth, good meals, flowers, conveyance and the like and be will be of good speech and intelligence. Happiness, erotic pleasure, good income, purchase of a conveyance and graceful speech ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse7)),
		new EventData(EventName.JupiterGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Jupiter passes through the 8th house from the Moon, the person will suffer from imprisonment, diseases, heavy grief, the fatigue of journey and serious illness. Imprisonment, disease, heavy grief and serious illness. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse8)),
		new EventData(EventName.JupiterGocharaInHouse9, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 9th house from the Moon, the person will become efficient at work and influential and he will get sons, success in work, wealth and gain. Influential, birth of an issue, success in work and acquisition of wealth from an unexpected source. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse9)),
		new EventData(EventName.JupiterGocharaInHouse10, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Jupiter passes through the 10th house from the Moon, the person will quit his place and suffer loss of health and wealth. Destruction of position, loss of money and health and aimless roaming about. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse10)),
		new EventData(EventName.JupiterGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " When Jupiter passes through the 11th house, the person will return to his country and will recover his health and wealth. Reinstatement in former position, and recovery of health. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse11)),
		new EventData(EventName.JupiterGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Jupiter passes through the 12th house, the person will suffer grief in his return journey. Fall from ideals and right conduct and increase of grief. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterGocharaInHouse12)),
		new EventData(EventName.VenusGocharaInHouse1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " When Venus passes through the sign occupied by the Moon at the time of birth of a person, such a person will enjoy excellent perfumes, flowers, clothes, houses, bed, meals and women. Acquisition of comforts for pleasure, and a happy life. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse1)),
		new EventData(EventName.VenusGocharaInHouse2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 2nd house from the Moon, the person will get sons, wealth, grain and presents from the king; will have a prosperous family, will enjoy flowers and gems and will be of bright appearance. Acquisition of money and gifts, birth of an issue and erotic pleasure. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse2)),
		new EventData(EventName.VenusGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 3rd house from the Moon, the person will become influential, wealthy and respectable and will get clothes. His enemies will meet with ruin. Influence, wealth and respect. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse3)),
		new EventData(EventName.VenusGocharaInHouse4, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 4th house, the person will get friends and will become greatly powerful. Disgrace to enemies and general prosperity. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse4)),
		new EventData(EventName.VenusGocharaInHouse5, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 5th house, the person will be happy, will get kinsmen, sons, wealth and friends and will not suffer defeat by the enemy. Renewal of contact with friends, increase of reputation, influence and power. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse5)),
		new EventData(EventName.VenusGocharaInHouse6, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Venus passes through the 6th house from the Moon, the person will suffer disgrace, will be afflicted with diseases and will be exposed to danger. General happiness, extension of business, birth of an issue and good income. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse6)),
		new EventData(EventName.VenusGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Venus passes through the 7th house, the person will suffer injuries through women. Humiliation, disease and danger. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse7)),
		new EventData(EventName.VenusGocharaInHouse8, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 8th house from the Moon, the person will get houses, articles of lacquer and beautiful women. Injuries and trouble from women and mental worry. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse8)),
		new EventData(EventName.VenusGocharaInHouse9, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 9th house from the Moon, the person will become virtuous, happy and wealthy and he will get plenty or clothes. Acquisition of a new house, articles of luxury and wife if not married. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse9)),
		new EventData(EventName.VenusGocharaInHouse10, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 10th house from the Moon, the person will suffer disgrace and will also suffer quarrels. Increase of virtue, happiness, wealth and performance of religious acts. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse10)),
		new EventData(EventName.VenusGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Venus passes through the 11th house from the Moon, the person will get wealth of his friends and will also get perfumes and clothes. Quarrels and disgrace. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse11)),
		new EventData(EventName.VenusGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Venus passes through the 12th house, the person will get very few clothes. Acquisition of new friends, money, perfumes and clothes. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.VenusGocharaInHouse12)),
		new EventData(EventName.SaturnGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the sign occupied by the Moon at the time of his birth, such person will suffer from poison and from fire, will quit his kinsmen, will suffer from imprisonment and torture, will travel to foreign lands and live with his friend there, will suffer miseries, loss of wealth and or sons, will suffer also from the fatigues of foot journey and from humiliation. Fear from poison or fire, of friends and family members, fear of incarceration, travel to foreign lands, loss of money and near relatives, separation from kith and kin and suffering from insults. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse1)),
		new EventData(EventName.SaturnGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Saturn passes through the 2nd house from the Moon, the person will suffer from loss of beauty and comfort, will become weak and will get wealth from other men but will not enjoy this wealth long. Emaciated physical appearance, loss of comfort, acquisition but not enjoyment of wealth ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse2)),
		new EventData(EventName.SaturnGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " When Saturn passes through the 3rd house from the Moon, the person will get wealth, servants, articles of enjoyment, camels, buffaloes, elephants, asses and horses. He will become influential, happy, free from disease and will become greatly powerful and will defeat his enemies in fight. Increase of wealth and other comforts, good health, general happiness and disappearance of enemies. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse3)),
		new EventData(EventName.SaturnGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 4th house from the Moon, the person will be separated from his friends, wealth, and wife and ever suspecting evil in everything, will never feel happy. Separation from friends and family members, suspicious nature, crooked behaviour and wicked acts. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse4)),
		new EventData(EventName.SaturnGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 5th house from the Moon, the person will be separated from his sons and wealth and will suffer from quarrels. Separation from sons, loss of money and frequent quarrels. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse5)),
		new EventData(EventName.SaturnGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " When Saturn passes through the 6th house from the Moon, the person will be freed from his enemies and diseases and will enjoy the company of women. Freedom from enemies and diseases association with fair sex. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse6)),
		new EventData(EventName.SaturnGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 7th or 8th house from the Moon, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. Separation from wife and children and aimless roaming about. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse7)),
		new EventData(EventName.SaturnGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 7th or 8th house from the Moon, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. Indulgence in mean activities and bereft of happiness. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse8)),
		new EventData(EventName.SaturnGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When he passes through the 9th house, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. Besides that, suffer from hatred, chest pain, imprisonment and in consequence will not properly observe the daily duties. Indulgence in mean activities and bereft of happiness. Suffers from hatred, heart trouble and even imprisonment. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse9)),
		new EventData(EventName.SaturnGocharaInHouse10, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 10th house, the person will get work and will suffer loss of wealth, learning and fame. Gets new avocation, but loses money and fame. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse10)),
		new EventData(EventName.SaturnGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Saturn passes through the 11th house from the Moon, the person will become cruel and will get women and wealth. Frequent loss of temper but acquisition of wealth through wrong means. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse11)),
		new EventData(EventName.SaturnGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Saturn passes through the 12th house from the Moon, the person will suffer from much grief. Grief, series of miseries, ill-health and general affliction. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnGocharaInHouse12)),
		new EventData(EventName.RahuGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Rahu passes through the sign occupied by the Moon at the time of his birth, such person will suffer from poison and from fire, will quit his kinsmen, will suffer from imprisonment and torture, will travel to foreign lands and live with his friend there, will suffer miseries, loss of wealth and or sons, will suffer also from the fatigues of foot journey and from humiliation. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse1)),
		new EventData(EventName.RahuGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Rahu passes through the 2nd house from the Moon, the person will suffer from loss of beauty and comfort, will become weak and will get wealth from other men but will not enjoy this wealth long. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse2)),
		new EventData(EventName.RahuGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 3rd house from the Moon, the person will get wealth, servants, articles of enjoyment, camels, buffaloes, elephants, asses and horses. He will become influential, happy, free from disease and will become greatly powerful and will defeat his enemies in fight. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse3)),
		new EventData(EventName.RahuGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 4th house from the Moon, the person will be separated from his friends, wealth, and wife and ever suspecting evil in everything, will never feel happy. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse4)),
		new EventData(EventName.RahuGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 5th house from the Moon, the person will be separated from his sons and wealth and will suffer from quarrels. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse5)),
		new EventData(EventName.RahuGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 6th house from the Moon, the person will be freed from his enemies and diseases and will enjoy the company of women. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse6)),
		new EventData(EventName.RahuGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 7th or 8th house from the Moon, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse7)),
		new EventData(EventName.RahuGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 7th or 8th house from the Moon, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse8)),
		new EventData(EventName.RahuGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When he passes through the 9th house, the person will be separated from his wife and sons, will travel on foot in a pitiable condition. Besides that, suffer from hatred, chest pain, imprisonment and in consequence will not properly observe the daily duties. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse9)),
		new EventData(EventName.RahuGocharaInHouse10, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Bad),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 10th house, the person will get work and will suffer loss of wealth, learning and fame. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse10)),
		new EventData(EventName.RahuGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 11th house from the Moon, the person will become cruel and will get women and wealth. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse11)),
		new EventData(EventName.RahuGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Rahu passes through the 12th house from the Moon, the person will suffer from much grief. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.RahuGocharaInHouse12)),
		new EventData(EventName.KetuGocharaInHouse1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When Ketu passes through tbe sign occupied by the Moon at the time of birth of a person, be will suffer from troubles. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse1)),
		new EventData(EventName.KetuGocharaInHouse2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 2nd house from the Moon displeasure of king, and suffering from quarrels, from enemies and disgrace is indicated. There will be fear from thieves and the body will be afflicted with bilious and windy complaints. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse2)),
		new EventData(EventName.KetuGocharaInHouse3, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Ketu transiting the 3rd gives rise to gain of objects, pleasure from children, good health, access to riches and new clothes. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse3)),
		new EventData(EventName.KetuGocharaInHouse4, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 4th sign, Ketu produces evil results such as fever, digestive troubles, blood discharges and depravity of character. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse4)),
		new EventData(EventName.KetuGocharaInHouse5, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Enemies will increase, fresh diseases will make their appearance and mental peace will be completely absent when Ketu passes through the 5th house. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse5)),
		new EventData(EventName.KetuGocharaInHouse6, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " In the 6th house, relief from troubles, worries and ill-health should be predicted; he leads an independent life, obtains riches and becomes pretty cheerful. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse6)),
		new EventData(EventName.KetuGocharaInHouse7, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " When transiting the 7th, tbe native quarrels with wife or husband, eye troubles, stomach-ache, indigestion, etc., are also likely to be felt. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse7)),
		new EventData(EventName.KetuGocharaInHouse8, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu transiting in the 8th produces quite unfavorable effects, such as discharging of blood, loss of wealth, disgrace and mental worry. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse8)),
		new EventData(EventName.KetuGocharaInHouse9, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu transiting in the 9th produces quite unfavorable effects, such as discharging of blood, loss of wealth, disgrace and mental worry.In addition, the subject becomes extremely weak. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse9)),
		new EventData(EventName.KetuGocharaInHouse10, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " His transiting the 10th produces quite favourable results. Amounts due will be realised. Success will attend on his ventures. Business will improve. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse10)),
		new EventData(EventName.KetuGocharaInHouse11, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " His transiting the 11th produces quite favourable results. Amounts due will be realised. Success will attend on his ventures. Business will improve. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse11)),
		new EventData(EventName.KetuGocharaInHouse12, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " In the 12th house, however,he will suffer from various expenses, troubles, diseases of the eye, pinpricks from an angry wife, from bilious complaints and various other worries. ", new List<EventTag>(1) { EventTag.Gochara }, EventManager.GetEventCalculatorMethod(EventName.KetuGocharaInHouse12)),
		new EventData(EventName.SunTransit8Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "wealth and prosperity and royal favour", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit8Bindu)),
		new EventData(EventName.SunTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "welfare, happiness and pomp", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit7Bindu)),
		new EventData(EventName.SunTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "rising power", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit6Bindu)),
		new EventData(EventName.SunTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "wealth", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit5Bindu)),
		new EventData(EventName.SunTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "both good and bad will be equal", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit4Bindu)),
		new EventData(EventName.SunTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "fatigue through journey", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit3Bindu)),
		new EventData(EventName.SunTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "sinful actions", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit2Bindu)),
		new EventData(EventName.SunTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "severe sickness", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit1Bindu)),
		new EventData(EventName.SunTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "death", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SunTransit0Bindu)),
		new EventData(EventName.MoonTransit8Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "happiness,prosperity and help from relatives", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit8Bindu)),
		new EventData(EventName.MoonTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain of clothes, agreeable food and gain of perfumes", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit7Bindu)),
		new EventData(EventName.MoonTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "study of Mantras and association with religious heads", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit6Bindu)),
		new EventData(EventName.MoonTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "courage and mental satisfaction", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit5Bindu)),
		new EventData(EventName.MoonTransit4Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "misery and ill-health", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit4Bindu)),
		new EventData(EventName.MoonTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "quarrels with relations", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit3Bindu)),
		new EventData(EventName.MoonTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "quarrels brought about by one's wife and one's wealth", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit2Bindu)),
		new EventData(EventName.MoonTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "irreparable losses", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit1Bindu)),
		new EventData(EventName.MoonTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "sorrow and extreme panic", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MoonTransit0Bindu)),
		new EventData(EventName.MarsTransit8Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " gain of landed property and moneys, acquisition of a house and victory ", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit8Bindu)),
		new EventData(EventName.MarsTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "prosperity through brothers", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit7Bindu)),
		new EventData(EventName.MarsTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "favour through kings", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit6Bindu)),
		new EventData(EventName.MarsTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "pleasing experiences", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit5Bindu)),
		new EventData(EventName.MarsTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "good and bad in equal proportion", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit4Bindu)),
		new EventData(EventName.MarsTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "separation from brothers and women", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit3Bindu)),
		new EventData(EventName.MarsTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "quarrels due to wife and wealth", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit2Bindu)),
		new EventData(EventName.MarsTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "disease, as smallpox, etc.", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit1Bindu)),
		new EventData(EventName.MarsTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "disease in the stomach, fits and exhaustion", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MarsTransit0Bindu)),
		new EventData(EventName.MercuryTransit8Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "respect from rulers", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit8Bindu)),
		new EventData(EventName.MercuryTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "increase of wealth and learning", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit7Bindu)),
		new EventData(EventName.MercuryTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "success attending all efforts", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit6Bindu)),
		new EventData(EventName.MercuryTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "reconciliation with relation", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit5Bindu)),
		new EventData(EventName.MercuryTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "want of spirit in everything", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit4Bindu)),
		new EventData(EventName.MercuryTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "anxiety through disturbed thoughts", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit3Bindu)),
		new EventData(EventName.MercuryTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "diseases caused by mental worry", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit2Bindu)),
		new EventData(EventName.MercuryTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "imprisonment by force and unexpected calamities", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit1Bindu)),
		new EventData(EventName.MercuryTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "unexpected loss of everytime and consequent mental worries", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.MercuryTransit0Bindu)),
		new EventData(EventName.JupiterTransit8Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "sovereignty, ownership and kingly prosperity", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit8Bindu)),
		new EventData(EventName.JupiterTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain of wealth and happiness", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit7Bindu)),
		new EventData(EventName.JupiterTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain of clothes, vehicles and gold", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit6Bindu)),
		new EventData(EventName.JupiterTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "ruin to enemies, accomplishment of desired objects", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit5Bindu)),
		new EventData(EventName.JupiterTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain and loss in equal measure", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit4Bindu)),
		new EventData(EventName.JupiterTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "nervous debility and ear diseases", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit3Bindu)),
		new EventData(EventName.JupiterTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "royal frowns", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit2Bindu)),
		new EventData(EventName.JupiterTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "loss of wealth and relations", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit1Bindu)),
		new EventData(EventName.JupiterTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "derangement of the mind, loss of wealth and children", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.JupiterTransit0Bindu)),
		new EventData(EventName.VenusTransit8Bindu, EventNature.Good, SpecializedSummary.Empty, " comfort from good clothes, women, flowers and wholesome food ", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit8Bindu)),
		new EventData(EventName.VenusTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain of ornaments and pearls", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit7Bindu)),
		new EventData(EventName.VenusTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "happiness from agreeable wife", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit6Bindu)),
		new EventData(EventName.VenusTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "meeting with friends", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit5Bindu)),
		new EventData(EventName.VenusTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "equal dose of good and bad", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit4Bindu)),
		new EventData(EventName.VenusTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "quarrel with the people of the locality and relatives", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit3Bindu)),
		new EventData(EventName.VenusTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "diseases and dismissal from service", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit2Bindu)),
		new EventData(EventName.VenusTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "fear from water and poison", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit1Bindu)),
		new EventData(EventName.VenusTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "all sorts of calamities", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.VenusTransit0Bindu)),
		new EventData(EventName.SaturnTransit8Bindu, EventNature.Good, SpecializedSummary.Empty, " acquisition of administrative control over a village or town ", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit8Bindu)),
		new EventData(EventName.SaturnTransit7Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "acquisition of servants and domestic animals", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit7Bindu)),
		new EventData(EventName.SaturnTransit6Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "popularity with thieves, hill tribes and army chief", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit6Bindu)),
		new EventData(EventName.SaturnTransit5Bindu, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "gain of grain", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit5Bindu)),
		new EventData(EventName.SaturnTransit4Bindu, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "good and bad equal", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit4Bindu)),
		new EventData(EventName.SaturnTransit3Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "loss of wealth, servants, women and happiness", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit3Bindu)),
		new EventData(EventName.SaturnTransit2Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "imprisonment, fear and disease", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit2Bindu)),
		new EventData(EventName.SaturnTransit1Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "dirty fallen life", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit1Bindu)),
		new EventData(EventName.SaturnTransit0Bindu, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Bad),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, "ill-luck in everything", new List<EventTag>(1) { EventTag.AshtakvargaGochara }, EventManager.GetEventCalculatorMethod(EventName.SaturnTransit0Bindu)),
		new EventData(EventName.AriesSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Dasa of the Sun in Aries in deep exaltation.- Sudden gains in cattle and wealth, much traveling in eastern countries, residence in foreign countries, quarrels among friends and relations, pleasure trips and picnic parties and company of beautiful women. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesSunPD1)),
		new EventData(EventName.TaurusSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Increase in landed properties, fame among relations and friends, cultivation of love and reverence for holy people and saints. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusSunPD1)),
		new EventData(EventName.GeminiSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Much wealth, education, inclination to interest oneself in music and such other fine arts, and generally happy and cheerful. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiSunPD1)),
		new EventData(EventName.CancerSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Cancer - Political success, always gay and happy, traveling in foreign countries and increase in lands, houses and wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerSunPD1)),
		new EventData(EventName.LeoSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Respect from kings and noble personages, righteous conduct, birth of children and respect among children. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoSunPD1)),
		new EventData(EventName.VirgoSunPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Virgo - Suffering off and on from physical complaints, loss of cattle, wealth and house and misunderstandings with close relatives and friends. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoSunPD1)),
		new EventData(EventName.LibraSunPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Reduced to poverty, troubled by enemies, failure in undertakings, death of brothers and friends and miserable and complicated life. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraSunPD1)),
		new EventData(EventName.ScorpioSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Starting new schemes and enterprises, realization of many ambitious things, travelling in hilly tracts and countries. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioSunPD1)),
		new EventData(EventName.SagittariusSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Happiness, success in undertakings, good health, destruction of enemies, satisfaction in every way. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusSunPD1)),
		new EventData(EventName.CapricornSunPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - A wandering life, loss of patrimony, self-respect and good name, misunderstanding among his own people. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornSunPD1)),
		new EventData(EventName.AquariusSunPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Mental worries, loss or illness to wife, loss of property and wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusSunPD1)),
		new EventData(EventName.PiscesSunPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Gains in wealth, auspicious celebrations, respect among relations, increase in family members and smooth sailing in every way. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesSunPD1)),
		new EventData(EventName.AriesMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon in Aries - Physical and mental happiness, gains in wealth and perfect contentment. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesMoonPD1)),
		new EventData(EventName.TaurusMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Increase in fame and name, collection of enormous wealth, mental and physical happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusMoonPD1)),
		new EventData(EventName.GeminiMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Progress in education and acquiring of much immovable and movable properties. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiMoonPD1)),
		new EventData(EventName.CancerMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Cancer - Addition in wealth, success in litigation, unexpected findings of treasure, travels. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerMoonPD1)),
		new EventData(EventName.LeoMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Progress in education, much gains from unexpected sources. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoMoonPD1)),
		new EventData(EventName.VirgoMoonPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Virgo - Death of serious illness to mother, worries from enemies and swindlers, mental and physical restlessness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoMoonPD1)),
		new EventData(EventName.LibraMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Gains in wealth, increase in friends, visits to holy places and shrines, realisation of schemes and destruction of enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraMoonPD1)),
		new EventData(EventName.ScorpioMoonPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Fear from political heads, destruction of relatives, disappointments in every respect, loss of wealth, liberty and honor at risk and much mental uneasiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioMoonPD1)),
		new EventData(EventName.SagittariusMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Domestic happiness and felicity, celebration of happy functions, accumulation of wealth and undisturbed progress of normal private affairs. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusMoonPD1)),
		new EventData(EventName.CapricornMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Increase in lands and houses and wealth, success in every new enterprise, pilgrimages to holy places and success in litigation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornMoonPD1)),
		new EventData(EventName.AquariusMoonPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Destruction of property, fear from political authorities, mental worries from enemies, misunderstandings among relatives and friends. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusMoonPD1)),
		new EventData(EventName.PiscesMoonPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Taking charges of fresh office, reciting religious texts and moral codes and easy access to anything coveted without effort. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesMoonPD1)),
		new EventData(EventName.AriesMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aries - Acquisition of wealth, increase in reputation and respect, much gain. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesMarsPD1)),
		new EventData(EventName.TaurusMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Destruction of enemies, success in all struggles, respect from elders and rulers and good produce from lands. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusMarsPD1)),
		new EventData(EventName.GeminiMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Access to great wealth, precious· stones and me~ agricultural success, general success in all undertakings. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiMarsPD1)),
		new EventData(EventName.CancerMarsPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Cancer - Danger from enemies, of honour and reputation, domestic disharmony and misunderstandings among brothers or close relatives. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerMarsPD1)),
		new EventData(EventName.LeoMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Happy and successful all through the period of 7 years, taste in fine arts and material gains through them, increase of income from house and lands. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoMarsPD1)),
		new EventData(EventName.VirgoMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Virgo - Beneficial results, successful termination of educational pursuits, ability to address meetings and deliver lectures, and happiness from relatives and friends. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoMarsPD1)),
		new EventData(EventName.LibraMarsPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Most miserable life, misunderstandings with cousins and brothers, death of wife and children, loss of wealth and grains and mortgaging of landed property. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraMarsPD1)),
		new EventData(EventName.ScorpioMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Increase in wealth, good earnings, friendship and intimacy with exalted personages, love for own people, always happy and active. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioMarsPD1)),
		new EventData(EventName.SagittariusMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Earnings from political or royal sources, courting their friendships, destruction of enemies and realisation of all hopes and desires. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusMarsPD1)),
		new EventData(EventName.CapricornMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Success in battles and respect for military skill, gains from quadrupeds and increase in wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornMarsPD1)),
		new EventData(EventName.AquariusMarsPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Great hardships and difficulties, misunderstandings with rulers and the immediate superiors in office, unpleasant relations with mother and servants. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusMarsPD1)),
		new EventData(EventName.PiscesMarsPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Much wealth, general success and happiness. bumper crops in lands, prosperity and acquisition of house and business, respect as a learned man, great reputation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesMarsPD1)),
		new EventData(EventName.AriesRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rahu In Aries - Auspicious celebrations in the house, recitations of sacred texts, acquisition of tracts of land, perfect domestic happiness, respect from rulers and a life of harmony in every respect. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesRahuPD1)),
		new EventData(EventName.TaurusRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Pilgrimages to shrines and holy places, increase in philosophical knowledge, entertainments, gains from cattle and dealings with quadrupeds. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusRahuPD1)),
		new EventData(EventName.GeminiRahuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Multiplication of enemies, always peevish and short tempered, fear from police and magistrates, sickness to wife and family, misunderstandings and disfavour. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiRahuPD1)),
		new EventData(EventName.CancerRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Cancer - Serving the suffering, humanitarian propaganda, zeal and enthusiasm for national service, gains and increase in wealth, riches and honour and great reputation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerRahuPD1)),
		new EventData(EventName.LeoRahuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Fear of imprisonment of fraud and deception or misappropriation or political offenses, destruction of property and mental worries distractions. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoRahuPD1)),
		new EventData(EventName.VirgoRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Virgo - Gain in wealth, general prosperity and success, acquisition of new lands, elevation to exalted positions, respect for learning, sexual happiness and domestic harmony, birth of children and sudden access to much wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoRahuPD1)),
		new EventData(EventName.LibraRahuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Libra - Destruction of property, loss of wealth, waste of agricultural products, loss of position, fear of imprisonment, residence in foreign countries-rather in exile, many miseries, hardships, business failure, litigation troubles and physical and mental sufferings. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraRahuPD1)),
		new EventData(EventName.ScorpioRahuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Rahu is debilitated here and as such, causes great havoc to the native. The results in Rahu's Dasa will be :-abortion, loss of children, inclination to bid farewell to moral aspect of life, failure in business enterprises and mental discontentment. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioRahuPD1)),
		new EventData(EventName.SagittariusRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Acquisition of wealth, sudden and unexpected gain without effort, great success in any undertakings, loss of near and dear relatives and mental unrest. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusRahuPD1)),
		new EventData(EventName.CapricornRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Sudden promotions to higher positions, recognition of one's merits by the State and rulers, marriage festivities at home, increase of wealth and general prosperity. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornRahuPD1)),
		new EventData(EventName.AquariusRahuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Orphanage, disappointments, mental derangement and affection, sorrowful news, loss of wife or children, premature death and mean instincts. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusRahuPD1)),
		new EventData(EventName.PiscesRahuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Great fear in life from thieves, swindlers and such people, inclination to matrimonial alliance, progress of education, some gains, ill health and mental uneasiness. Rahu in Pisces gives mixed results - his position, viz., whether he is in a friendly or unfriendly sign, in the house of loss or gain, wife or children, etc., should be correctly determined. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesRahuPD1)),
		new EventData(EventName.AriesJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter in Aries - Acquisition of landed property, general prosperity and success in all undertakings and litigations, elevation to a responsible office or appointment as a trustee and great respect from his or her own people. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesJupiterPD1)),
		new EventData(EventName.TaurusJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - If a king or a president - access to new territories, fresh treaties and pacts, if an ordinary person - acquisition of wealth, establishment of business on a firm foundation, gains in trade and agriculture, increase in lands and cattle, respect from friends and foes. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusJupiterPD1)),
		new EventData(EventName.GeminiJupiterPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Death of wife if married or sweet heart, loss of children, brothers and cousins, deportation, fear from rulers and mental uneasiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiJupiterPD1)),
		new EventData(EventName.CancerJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Cancer - Jupiter is exalted here and gives all beneficial results such as much political success, promotions, exalted positions, humanitarian work, national service, acquisition of wealth from unexpected sources and without efforts, journalistic success, minister of education or lands and perfect harmony in domestic life. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerJupiterPD1)),
		new EventData(EventName.LeoJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Respect from rulers, gain of lands, much agricultural produce, and realisation of one's own desires and ambitions. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoJupiterPD1)),
		new EventData(EventName.VirgoJupiterPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Virgo - Residence in foreign countries, destruction of wife and property, loss of wealth, misunderstandings among relatives, strife, body ill-health and symptoms of nervous troubles and diseases. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoJupiterPD1)),
		new EventData(EventName.LibraJupiterPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Residence in desolate places, dissolute and shameful life, active part in perverted social reform, selfish interests, great and unbearable difficulties and troubles, tendency to create factions in societies and families. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraJupiterPD1)),
		new EventData(EventName.ScorpioJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Mental calm and happiness, acquisition of new lands and estates, undisturbed progress and religious worship and philosophical discourses and triumph of spiritual influences over sensual passions, reputation at stake if aspected by malefics. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioJupiterPD1)),
		new EventData(EventName.SagittariusJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Many sons, much wealth, success in every undertaking, increase in relations and family members. widespread fame and perfect happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusJupiterPD1)),
		new EventData(EventName.CapricornJupiterPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Capricorn - Death or illness of children, wife always ill, loss of property, reputation and self-respect, irreligious acts, sacrilegious attacks upon sacred institutions, predominance of mean motives, liable to prosecution and the upspringing of numerous enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornJupiterPD1)),
		new EventData(EventName.AquariusJupiterPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Consumption and fear from wild beasts, animals, bad luck, many hardships and loss of wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusJupiterPD1)),
		new EventData(EventName.PiscesJupiterPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Much fame throughout this long period of 16 years, high education and gt1in from exhibition of knowledge, acquisition of property and general success and happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesJupiterPD1)),
		new EventData(EventName.AriesSaturnPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Saturn In Aries - The worst period in a man's career, unexpected losses, disappointments in every undertaking, misunderstandings among relatives and friends and increase in the number of enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesSaturnPD1)),
		new EventData(EventName.TaurusSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Success and gains in agricultural operations, much prosperity to the cattle and other domestic animals, great income, and access to things desired. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusSaturnPD1)),
		new EventData(EventName.GeminiSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Recognition of his services, great humanitarian work, profits in speculations and trade, respect from rulers, political success, reputation, fame and much general happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiSaturnPD1)),
		new EventData(EventName.CancerSaturnPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Cancer - Miseries and calamities, family strife, increase of enemies, trouble from relatives and physical diseases and mental affliction. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerSaturnPD1)),
		new EventData(EventName.LeoSaturnPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - A period of uneasiness, distrust, disappointments and unrest, misappropriation of money and consequent prosecution if Saturn is afflicted powerfully, hatred by all and courting death as a source of relief from mental worries. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoSaturnPD1)),
		new EventData(EventName.VirgoSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Virgo - Elevation to exalted positions, royal favour, business success and establishment of fame and reputation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoSaturnPD1)),
		new EventData(EventName.LibraSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Travelling in countries inhabited by Christians and Moslems, establishment of fresh branches if proprietor of a business concern, acceptance of invitations for public lectures and great honour and respect throughout the long period of 19 years and perfect domestic happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraSaturnPD1)),
		new EventData(EventName.ScorpioSaturnPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Odium of superiors, disliked and hated by all, loss or prestige, self-respect and fame and destruction and damage to property and possessions. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioSaturnPD1)),
		new EventData(EventName.SagittariusSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Inclination to study philosophical and religious treatises and success in such studies, auspicious occasions like marriage ceremonies, etc., at home and happiness and mental peace throughout. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusSaturnPD1)),
		new EventData(EventName.CapricornSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Increase in lands, gains in wealth and business, friendship with great and illustrious personages. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornSaturnPD1)),
		new EventData(EventName.AquariusSaturnPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Great travelling in Western countries, success in litigation, mental happiness and acquisition of wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusSaturnPD1)),
		new EventData(EventName.PiscesSaturnPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Pilgrimage to sacred shrines and holy places, indifference towards sectarian restrictions and observances, sorrows, misery and unrest. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesSaturnPD1)),
		new EventData(EventName.AriesMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury in Aries - Marriage, performance of religious and social work, charity, increase in religiousness and intelligence, favour of rulers, gains from cultivation. cattle, precious stones and conveyances and happiness through these. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesMercuryPD1)),
		new EventData(EventName.TaurusMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Taurus - Great happiness, sexual contact with beautiful young women, getting titles and name, ornaments and authority over men, acquaintance of sweet girls and their company and practice of music and kindred sciences. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusMercuryPD1)),
		new EventData(EventName.GeminiMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Access to great intellectual treasures, increase in knowledge, successful termination of educational career, acquisition of fame and wealth, happiness from wife and children, marriage ceremonies and recitation of sacred scriptures. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiMercuryPD1)),
		new EventData(EventName.CancerMercuryPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Cancer - Degradation, change of residence, fines and imprisonments, penalties. confinement in chains, hatred of relations, loss of lands. failure of crops and comity with all. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerMercuryPD1)),
		new EventData(EventName.LeoMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Good courage and elevation, travelling in hilly and mountainous tracts, acquisition of wealth from various countries, progress in knowledge, expeditions to mountains, caves and similar places, marriage and great reputation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoMercuryPD1)),
		new EventData(EventName.VirgoMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Virgo - The most auspicious and happy period of life, favour of kings, admirers and royal courts and great success in them, undisturbed health, marriage in the house, increase in intelligence, religiousness, charitable foundings, and unexpected gains. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoMercuryPD1)),
		new EventData(EventName.LibraMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Great works published in the native's name, favour of wealthy and educated people without effort, and leadership over men. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraMercuryPD1)),
		new EventData(EventName.ScorpioMercuryPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Loss or wife, children, riches, mental troubles, losses from merchandise, great hatred of people and relations and loss of reputation and power. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioMercuryPD1)),
		new EventData(EventName.SagittariusMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Success in education, meeting with learned and religious people, worship of holy men, virtuous and charitable deeds, travelling in Eastern countries, inclination for marital enterprises and great exhilaration. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusMercuryPD1)),
		new EventData(EventName.CapricornMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Success in trade, inception of new business-like trades in tanneries, leather goods, glassware, etc., recitation of religious scriptures. Godly contemplations, patronage of kings, destruction of foes and enemies and general success in life. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornMercuryPD1)),
		new EventData(EventName.AquariusMercuryPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Acquisition of paraphernalia, access to good and much wealth, indulging in a pleasurely life and good fame and name. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusMercuryPD1)),
		new EventData(EventName.PiscesMercuryPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Trouble from thieves, dysentery, destruction of relations, litigation, quarrels with relatives, mental derangement, nervous breakdown and failure in attempts. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesMercuryPD1)),
		new EventData(EventName.AriesKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Ketu in Aries - Disgrace, troubles from relatives, loss of property, cattle and other domestic animals, constant travels in Eastern countries, great hardship, sudden quarrels, loss of mother and wife or their serious sickness, want of prudence and capacity in private matters. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesKetuPD1)),
		new EventData(EventName.TaurusKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - Many dangers, death of wife, acquisition of wealth through evil ways and means, sexual sorrows, visits to sacred shrines and holy waters, inclination to religious study and success in it, compunction and in the end appeasing sins by resort to foul stratagems. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusKetuPD1)),
		new EventData(EventName.GeminiKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Good health, happiness, elevation to responsible and exalted positions, rounding of sacred institutions, good food, advent of relations and in later years venereal troubles, death of near relation and loss of reputation and self-respect. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiKetuPD1)),
		new EventData(EventName.CancerKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Cancer - Many dangers, disturbances from his place and a period of exile, serious sickness to wife, parents or children, and if badly afflicted, their death, quarrels with friends, initiation into the mysteries of philosophical knowledge. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerKetuPD1)),
		new EventData(EventName.LeoKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Leo - Increase of lands, cultivation. progress in education, heated debates and discussions on philosophical and scientific subjects with great scholars and eminent people, attracted by females and company with them, travels in mountainous tracts and billy countries to spread any righteous cause, and treated to great musical entertainment. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoKetuPD1)),
		new EventData(EventName.VirgoKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Virgo - Fear from fires, weapons and poisonous gases, beasts and reptiles, destruction of dear lives, properties and self-respect, unrighteous acts and nasty venereal complaints. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoKetuPD1)),
		new EventData(EventName.LibraKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Libra - Happiness and prosperity to wife or husband, self and children, enmity of relations, gains from gold and precious stones, headache, heart disease, nervous breakdown, trouble in the anus and much discontent. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraKetuPD1)),
		new EventData(EventName.ScorpioKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Scorpio - Living dependent on relations, sycophant acts, acquisition of much wealth. loss of few children, gains from lands, contraction of new friendship from among the members of the fair sex and liable to suffer from venereal complaints. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioKetuPD1)),
		new EventData(EventName.SagittariusKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Perfect domestic harmony and happiness, favour from aristocrats, progress in education, religious discussions, moral elevation and manifestation of a spirit of tolerance and equality. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusKetuPD1)),
		new EventData(EventName.CapricornKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Capricorn - Misappropriation of private and governmental funds and consequent prosecution, wife or husband catching consumption and such diseases, death of a few children, anxiety about everything, misunderstanding with relations and disgrace and disappointments. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornKetuPD1)),
		new EventData(EventName.AquariusKetuPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Hating all and hated by all, incurring the displeasure of superiors, pessimistic about every hope, abject dependency and servile flattery; in the end, happiness and prosperity to wife and children. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusKetuPD1)),
		new EventData(EventName.PiscesKetuPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - Learned discussions, general success, helping the suffering, mental depression, promotion, acquisition of fertile lands, favour of the superiors and moneyed people, moral and religious devotions, vigorous and clear understanding, travel on water to distant countries and respect there. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesKetuPD1)),
		new EventData(EventName.AriesVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus in Aries - Residence in palatial buildings, acquaintance with noble personages, wearing good clothes, good earnings, spread of fame, much respect, birth of child, happy sexual relations and praised by friends and enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AriesVenusPD1)),
		new EventData(EventName.TaurusVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Taurus - A life of great ease and indulgence throughout the period of 20 years, enjoyment of much happiness, company of beautiful girls and joy through association with them, travels on seas to foreign countries particularly southern, all ambitions of life fairly realised, redemption from debts, symptoms of venereal troubles. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.TaurusVenusPD1)),
		new EventData(EventName.GeminiVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Gemini - Gain of territory, affording protection to brothers, sisters, cousins and paternal uncles and aunts, gain of vehicles, increase of reputation, children. harmony with wife, mental peace and a check over inclination to indulge in loose life. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.GeminiVenusPD1)),
		new EventData(EventName.CancerVenusPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Cancer - Paroxysms of grief and terror, destruction of property, discontent with relations, increase of enemies, loss of wealth, disturbance to good work and some mental ease in the end. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CancerVenusPD1)),
		new EventData(EventName.LeoVenusPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Leo - Mental disease and sorrow, troubles from fires, poisons and hurts, evil women, foul language and mental disorder, exile, and aimless wanderings in deserts and woods to evade detection by law, dangerous sickness to the better half or a child, stigma on self-respect due to mean fellows and inclination to conceal true identity. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LeoVenusPD1)),
		new EventData(EventName.VirgoVenusPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Virgo - Quarrels with wife or husband and separation from him or her, mortgage of all property, trouble in the generative organ often leading to surgical operation, symptoms of arthritis, troubles relating to nervous breakdown, mental unrest, separation from relatives and friends and much grief and sorrow. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.VirgoVenusPD1)),
		new EventData(EventName.LibraVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Libra - Great reputation, gain of wealth from royal patronage, comforts, good enjoyment of life, luxurious invitations and worships of mammon and a period of extreme sensuality. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.LibraVenusPD1)),
		new EventData(EventName.ScorpioVenusPD1, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Scorpio - Hatred for all, many miseries and troubles, serious risks, vengeance against relatives, loss of wealth and property, mental affliction and imbalance. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.ScorpioVenusPD1)),
		new EventData(EventName.SagittariusVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sagittarius - Much fame and name, religious _and philosophical studies, recitation of sacred writings, regard for holy people and ascetics, success in any undertakings and general prosperity. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.SagittariusVenusPD1)),
		new EventData(EventName.CapricornVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Capricorn - Travels in foreign lands, freedom from domestic worries, discussion with learned people, progress in general education, acquaintance with low class people, development of perverted ideas of social or religious reform and success in all endeavors. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.CapricornVenusPD1)),
		new EventData(EventName.AquariusVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Aquarius - Acquisition of fresh property, a good library, lands and houses, honours and unexpected gains, love for Christian or Islamic literature and its studies, stray intercourse with senile women, domestic happiness and harmony. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.AquariusVenusPD1)),
		new EventData(EventName.PiscesVenusPD1, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Pisces - High political power and great success, promotion to responsible office, acts of charity and generosity, exercise of prudence in official matters and perfect happiness in domestic life and smooth-sailing in every respect. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD1
		}, EventManager.GetEventCalculatorMethod(EventName.PiscesVenusPD1)),
		new EventData(EventName.SunSunPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Unpleasantness with relatives and superiors, anxieties, headache, pain in the ear, some tendency to urinary or kidney troubles, sickness, fear from rulers and enemies, fear of death, loss of money, danger to father if the Sun is afflicted, stomachache and travels, gains through religious people, mental sufferings, a wandering life in a foreign country. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD2)),
		new EventData(EventName.SunMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon's sub-period-6 months Winning favour from superiors, increase in business, fresh enterprises, troubles through women, eye troubles, many relatives and friends, indulgence in idle pastimes, jaundice and kindred ailments, new clothes and ornaments, will be happy, healthy, good meals, respect among relatives. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD2)),
		new EventData(EventName.SunMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars' sub-period-4 months, 6 days. Rheumatic and similar troubles, quarrels, danger of enteric fever, dysentery, troubles to relatives, loss of money by thefts or wasteful expenses, failures, acquisition of wealth in the form of gold and gems, royal favour leading to prosperity, contraction and transmission of bilious and other diseases, mental worries, danger from fire, ill-health, loss of reputation, sorrow. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD2)),
		new EventData(EventName.SunRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rahu's sub-period - 10 months, 24 days. Many troubles, changes according to the position of Rahu, family disputes, journeys, fear of death, trouble from relatives and enemies, loss of peace or mental misery, loss of money, sorrows, unsuccessful in all attempts, fear of thieves and reptiles, scandals. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD2)),
		new EventData(EventName.SunJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter's sub-period-9 months, 18 days. Benefits from friends and acquaintances, increase in education, employment in high circles, association with people of high rank, success through obstacles, birth of a child, wealth got through sons (if there is a son), honour to religious people, virtuous acts, good traditional observances, good society and conversations, reputation, gains and court-honours. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD2)),
		new EventData(EventName.SunSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn's sub-period--11 months, 12 days. Constant sickness to family members, new enemies, some loss of property, bodily ailment, much unhappiness, displacement from home accidents, quarrels with relatives, loss of money, disease, lacking in energy, ignoble calls, mental worries, loans, danger from thieve and rulers. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD2)),
		new EventData(EventName.SunMercuryPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period-IO months, 6 days. Gain in money, good reputation, acquisition of new clothes and ornaments, new education, trouble through relatives, mental distress, depression of spirits, waste of money and nervous weakness, no comforts, friends becoming enemies, much anxiety and fears, health bad, children ungrateful, disputes and trouble from ruler or judge, suffer disgrace, many short journeys and wanderings. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD2)),
		new EventData(EventName.SunKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu's sub-period - 4 months, 6 days. Loss of money, affliction of mind with troubles, fainting or nervous exhaustion, mind full of misgivings, a long journey to a distant place, change of house due to disputes, troubles among relatives and associates, throat disease, mental anguish, ophthalmia, serious illness, fear from kings or rulers and enemies, diseases, cheated by others. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD2)),
		new EventData(EventName.SunVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus sub-period - 1 year. Gain of money, respect by rulers and gain of vehicles, likelihood of marriage, increase of property, illness, does many good works, acquisition of pearls or other precious stones, fatigue, addiction to immoral females and profitless discussions. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD2)),
		new EventData(EventName.MoonSunPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun's sub-period - 6 months. Feverish complaints, pains in the eyes, success or failure according to position of the Sun and the Moon, legal power, free from diseases, decadence of enemies, happiness and prosperity, jaundice, dropsy, fever, loss of money, travels, danger to father and mother, piles, weakness, loss of children and friends. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD2)),
		new EventData(EventName.MoonMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon's sub-period- 1O months. Devoted attention to learning, love or music, good clothing, company of refined society, sound health, good reputation, journey to holy places, acquisition of abandoned wealth, power, vehicles and lands; marriage, relatives, fortunate deeds, inclination to public life, change of residence, birth of a child, increase of wealth, prosperity to relatives. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD2)),
		new EventData(EventName.MoonMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars's sub-period - 7 months. Quarrels and litigation among friends and relatives, headlong enterprises, danger of disputes between husband and wife, between lovers or in regard to marital affairs; disease, petulence, loss of money, waste of wealth, trouble from brothers and friends, danger from fever and fire, injury from instruments or stones, loss of blood and disease to household animals. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD2)),
		new EventData(EventName.MoonRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu's sub-period - 1 year, 6 months. Distress of risks from falls and dangerous diseases, waste of wealth and loss of relatives and no ease to body, loss of money, danger of stirring up enemies, sickness, anxiety, enmity of superiors and elders, anxiety and troubles through wife, scandals, change of residence, diseases of skin, danger from thieves and poison, ill-health to father and mother, suffering from hunger. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD2)),
		new EventData(EventName.MoonJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter's sub-period - 1 year, 4 months. Increase of property, plenty of food and comforts, prosperous, benefits from superiors such as masters or governors, birth. of a child, vehicles, abundance of clothes and ornaments and success in undertakings, patronage or rulers, gain or property, respect, learned. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD2)),
		new EventData(EventName.MoonSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn's sub-period - 1 year, 7 months. Wife's death or separation, much mental anguish, loss of property, loss of friends, ill health, mental trouble due to mother, wind and bilious affections, harsh words, and discussion with unfriendly people, disease due to indigestion, no peace of mind, quarrels with relatives. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD2)),
		new EventData(EventName.MoonMercuryPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period - 1 year, 5 months. Acquisition of wealth from maternal relatives, new clothes and ornaments, settlement of disputes, pleasure through children or lover, increase of wealth, accomplishment of desires, intellectual achievements, new education, honour from rulers, general happiness, enjoyment with females, addiction to betting and drinks. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD2)),
		new EventData(EventName.MoonKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu's sub-period - 7 months. Illness to wife, loss of relatives, suffering from stomach ache, loss or property, sickness of a feverish nature, danger from fire, subject to swellings or eruptions, eye troubles, mind filled with cares, public criticism or displeasure, dishonor, danger to father, mother and children, scandals among equals, eating of prohibited food, bad acts, bad company, loss of money and memory. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD2)),
		new EventData(EventName.MoonVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Venus's sub-period - 1 year, 8 months. Sudden gain from wife, enjoys comforts of agriculture, water products and clothing, suffers from diseases inherited by mother, sickness, pain, loss of property, enmity, gain of houses, good works and good meals, birth of children, expenses due to marriage or other auspicious acts. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD2)),
		new EventData(EventName.MarsSunPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun's sub-period - 4 months, 6 days. Gain of money in bad ways, destruction of enemies, good reputation, long journey to foreign lands and peace of mind, blame, odium of ciders, quarrels with them, sufferings by diseases, heartache occasioned by one's own relatives, fever or other inflammatory affection, danger of fire, troubles through persons in position, many enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD2)),
		new EventData(EventName.MarsMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon's sub-period -7 months. Profit, acquisition of wealth, house renovated or some improvements effected in it, comforts of wealth, heavy sleep, ardent passion, enjoyment by the help or women. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD2)),
		new EventData(EventName.MarsMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars's sub-period - 4 months, 27 days. Great heat, dislike of friends, annoyance from brothers and sisters, danger from rulers, failure of all undertakings, danger of hurts according to the sign held by Kuja, trouble with superiors and some anxiety through strangers, foreigners or people abroad and through warlike clan. Danger of open violence, quarrel with relations, loss of money, skin disease, consumption, loss of blood, fistula, and fissures in anus, loss of females and brothers, evil doings and boils. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD2)),
		new EventData(EventName.MarsRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu's sub-period - 1 year, 18 days. Danger from rulers and robbers, loss of wealth, success in evil pursuits, suffering from poisonous complaints, loss of relatives, danger from skin diseases, change of residence, some severe kind of cutaneous disease, journey to a foreign country, scandals, loss of cows and buffaloes, illness to wife, loss of memory, fear from insects and thieves, falls into well, fear from ghosts, affection of gonorrhea, fretting and litigation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD2)),
		new EventData(EventName.MarsJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter's sub-period - 11 months, 6 days. Loss of wealth, enemies, end the unfortunate period, favour from superiors and persons in position, gain of money, birth of children, auspicious celebrations, acquisition or wealth through holy people, freedom from illness, public reputation, ascendancy and happiness. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD2)),
		new EventData(EventName.MarsSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn's sub-period - 1 year, 1 month, 9 days. Loss of money, diseases, loss of relatives and danger from arms or operation, illness leading to misery, evil threatened by enemies and robbers, disputes with rulers, loss of wealth, quarrel, disputes, litigation, loss of property, cutaneous effects. loss of office or position and much anxiety. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD2)),
		new EventData(EventName.MarsMercuryPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period- 11 months, 27 days. Marriage or inclination to marriage, knowledge and fruits of knowledge, wealth, bodily evils disappear, slander, fear of insects, poisoned by animals and insects, gain of wealth by trade, abundance of houses, trouble from enemies and mental worries, service rendered to friends and relatives, new knowledge, success in litigation. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD2)),
		new EventData(EventName.MarsKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Ketu's sub-period - 4 months, 27 days. Enmity and quarrels with low people, loss of money due to evil works, commission of signs, great sufferings due to troubles from relatives and brothers and opposition of bad people, family disputes, troubles with one's own kindred diseases, poisonous complaints, trouble through women, many enemies. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD2)),
		new EventData(EventName.MarsVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Venus's sub-period - 1 year, 2 months. Acquisition of property, gain of money, domestic happiness, successful love affairs, inclination towards religious observances and festivities, favourable associations, influenced by priests, skin eruptions, boils, pleasure from travelling, jewels to wife, clothing, money from relatives and brothers, odium.of females and their society, increase of intelligence, enjoyment of females and gain of money. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD2)),
		new EventData(EventName.RahuSunPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun's sub-period - 1O months, 24 days. Hot fevers, giddiness, fear and enmity of people, quarrels in family, benefits from persons in good position, fear and suspicion in connection with wife, children and relatives, change of position or residence, love of charitable acts, contentment, cessation of all violence and outrage of contagious diseases, success in examinations, private life happy, much reputation and fame, but mental unrest. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD2)),
		new EventData(EventName.RahuMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Moon - 1 year, 6 months. Abundance of enjoyments, good crops, coming in of money and communion with kith and kin, loss of relatives, loss of money through wife, pains in the limbs, change of position or residence, danger of personal hurts, unstability of health, sea voyages, gain of lands and money, loss or danger to wife and children. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD2)),
		new EventData(EventName.RahuMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars - 1 year, 18 days. Danger from rulers, fires or thieves and by arms, defeat in litigation, loss of money due to cousins, difficulties, sorrows, danger to the person due to malice of enemies, tendency to ease or dissolute habits, disputes and mental anxiety, combination of all possible calamities, bewilderment in every work and culpable failure of memory. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD2)),
		new EventData(EventName.RahuRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu - 2 years, 8 months, 12 days. Disturbance in mind, anxieties, quarrels among relatives, death of partner, master or the head of the family, mental anxiety, danger of poisoning, transfer, all sorts of scandals and quarrels, fever, bites of insects or wounds by arms, death of relatives, going to court as witness, quarrels with parents, diseases, illness to wife, failure of intellect, loss of wealth, wandering in far-off countries and distress there. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD2)),
		new EventData(EventName.RahuJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter - 2 years, 4 months, 24 days. Total disappearance of enemies and sickness, royal favour, acquisition of wealth, birth of children, increase of pleasure, gain through nobles or persons in power, benefits and comforts from superiors, success in all efforts, marriage in the house, increase of enemies, litigations and dips in sacred rivers. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD2)),
		new EventData(EventName.RahuSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn - 2 years, 10 months, 6 days. Scandal, danger due to fall of a tree, bad associations, divorce of wife or husband, incessant disputes and contests, rheumatism, biliousness, etc., throughout: disease due to wind and bile, distress of relatives, friends and well-wishers, residence in a remote foreign land. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD2)),
		new EventData(EventName.RahuMercuryPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury - 2 years, 6 months, 18 days. Many friends and relatives, wife and children, accession to wealth or royal favour. In the first 18 months of this period very busy, seriously inclined to marry. In the latter 12 months, enemies increase through his own action, happiness, birth of children, acquisition of vehicles, happiness to relatives and family, enjoyments with prostitutes, showy, gains through trade, fraudulent schemes. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD2)),
		new EventData(EventName.RahuKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu - 1 year, 18 days. Danger, disease in the anus, no good and timely meals, epidemic diseases, danger of physical hurts and poison, ill-health to children, some swellings in the body, troubles through wife, danger from superiors, loss of wealth and honour, loss of children, death of cattle and misfortunes of all kinds. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD2)),
		new EventData(EventName.RahuVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus - 3 years. Accession to vehicles and things of foreign land, troubles from foes, relatives and diseases, acquisition of wealth and other advantages, friendly alliances, wife a source of fortune and happiness, benefits from superiors or beads above in office, liable to deception, false friends, gain in land, birth of a child or marriage. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD2)),
		new EventData(EventName.JupiterSunPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun's sub-period - 9 months, 18 days. Enemies, victory, ease, great diligence, coming in of wealth, royal favour and sound health, gain,good actions or fruits of good action, loss of bodily strength. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD2)),
		new EventData(EventName.JupiterMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Tbe Moon's sub-period - 1 year, 4 months. Increase of prosperity, gain of fame and fortune, acquisition or property, benefits through children, sexual intercourse with beautiful women, good meals and clothing, success and birth or a female child or marriage to some male member in the family, gain of money. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD2)),
		new EventData(EventName.JupiterMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars' sub-period - 11 months, 6 days. Disappointments and troubles of various kinds, loss by thefts, loss of near and dear relatives, inflammatory disease, transfer or leave, failure in hopes and business, wandering, high fever, great risks, loss of wealth and depression of mind, pilgrimage to temples, acquisition of wealth and fame, adventures. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD2)),
		new EventData(EventName.JupiterRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu's sub-period - 2 years, 4 months, 24 days. Income through low-caste people, apprehension of diseases, possibility of every possible calamity, deprivation of wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD2)),
		new EventData(EventName.JupiterJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter's sub-period - 2 years, 1 month, 18 days. Increase of property, domestic happiness, benefit from employment or occupation, birth of children, reputation, good meals, good deeds, health. royal favour, great diligence, success in all attempts, travels, dips in sacred rivers, pilgrimage, honour at stake if afflicted. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD2)),
		new EventData(EventName.JupiterSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn's sub-period - 2 years, 6 months, 12 days. A feeling of aversion, mental anguish, waste of wealth through sons, failure of business, increase of wealth and prosperity, pain in the body, rheumatic pains in limbs, trouble through wife or partners, failure in profit and credit, sorrows, fears, enmity of friends and relatives, adultery, unrighteous, a witness in court, quarrels in family, mental depression, funeral ceremonies for others, ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD2)),
		new EventData(EventName.JupiterMercuryPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period - 2 years, 3 months, 6 days. Increase of wealth, good and auspicious works in the house, communion with relatives, happy, increase of knowledge, acquisition of wealth through trade, favour from rulers, material comforts, perfect practice of hospitality, gain through knowledge in fine arts, birth of a well-favoured child, advantages from superiors. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD2)),
		new EventData(EventName.JupiterKetuPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu's sub-period - 11 months, 6 days. Pilgrimages to holy shrines, increase of wealth, suffering for the sake of several seniors and rulers, death of partner if in business, change of residence, separation from relatives and friends, may forsake business, poisonous effects, loss of wealth, destruction of work, illness, boils. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD2)),
		new EventData(EventName.JupiterVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus's sub-period - 2 years, 8 months. Appointment, wealth, reputation, gain of money, savings, development of sons and grandsons, jewels, good and delicious meals, marital happiness, auspicious works, reunion of the family, good success in profession or business, gain of land in the month of Taurus or Libra, much enjoyment, relatives, friends, peace or mind, acquisition or valuables, troubles from females and odium of public. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD2)),
		new EventData(EventName.SaturnSunPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Sun - 11 months, 12 days. Loss of wife and children, trouble from rulers or robbers. sinking of heart, danger of blood poisoning, haemorrhage of the generative system, chronic poisoning, intestinal swellings, affliction of the eyes, sickness even to healthy children and wife, body full of pain and disorders, danger of death. fear of death to father-in-law. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD2)),
		new EventData(EventName.SaturnMoonPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Moon - 1 year, 7 months. Increase in cattle, enmity of friends and relatives, cold affections, troubles and sickness, family disputes, loss of money and property, reduction to great need, mortgage of property and its recovery after a lapse of time, death of a near relative, sorrow, dislike of relatives, coming in of money, windy diseases. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD2)),
		new EventData(EventName.SaturnMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars - 1 year, 1 month, 9 days. Some disgrace, serious enmity, strife, much blame, wanderings from place to place, unsettled life, many enemies, loss of money by fraud or theft, change of residence, serious illness, distress to brothers and friends, hot diseases. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD2)),
		new EventData(EventName.SaturnRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu's sub-period - 2 years, 10 months, 6 days. Disease in every limb, loss of wealth by rulers, robbers and foes, danger of physical hurts, various physical troubles, fevers, enemies, increase of troubles. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD2)),
		new EventData(EventName.SaturnJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Good)
		}, " Jupiter - 2 years, 6 months, 12 days. Worship of gods and holy people, happiness to family, increase in bodily comforts, accomplishment of intentions by the help of superiors, increase of family circles, attainment of rank. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD2)),
		new EventData(EventName.SaturnSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn's sub-period 3 years, 3 days. Brings on diseases, troubles and torments, much mental anguish, capacity of kings and free-hooters, loss of wealth, fear or poisonous effect to cattle, much sufferings to family, fever, wind or phlegm, bodily ailments and colic, body languishes, loss of money and children, serious enmities, dispute and troubles from relatives, blood and bilious complaints, quarrels in family, loss of money, mental derangement. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD2)),
		new EventData(EventName.SaturnMercuryPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period - 2 years, 8 months, 9 days. Charitable works, gain of wealth, birth of children, increase of knowledge in some branch, prosperity to children, success to relatives, general prosperity, favours and approbation from superiors, increase of happiness, wealth and fame, benefits occurring from acts of piety and customary religious observances, agriculture and commerce. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD2)),
		new EventData(EventName.SaturnKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu's sub-period - 1 year, I month, 9 days. Rheumatism or sickness, danger of poison, danger from sons, loss of money, contentions and quarrels with vile and wicked people, dread of evil dreams, quarrels in family. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD2)),
		new EventData(EventName.SaturnVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus - 3 years, 2 months. Auspicious, general happiness, attentions and favours from others, gifts, profits in business, increase of family members, victory over enemies, success in life, goodwill of relatives, accession to wife's property and wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD2)),
		new EventData(EventName.MercurySunPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Sun - 1O months, 6 days. Pains in bead and stomach, enmity of people, loss of respect, danger of fire, anxieties, sickness to wire, troubles from enemies, many obstacles, troubles through superiors, acquisition of wealth. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD2)),
		new EventData(EventName.MercuryMoonPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Moon - 1 year, 5 months. Loss of health, some swellings or hurts in the limbs, quarrels and troubles through women, many difficulties, gain of money through ladies and agriculture and trade, success, happiness, diseases, ill-will of enemies, miscarriage of every concern, risk from quadrupeds. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD2)),
		new EventData(EventName.MercuryMarsPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars sub-period - 11 months, 27 days. Disappearance of all dangers diseases or enemies, fame derived from acts of charity and beneficence, royal favour, danger from jaundice or bilious fever, affections of the blood, neuralgic pains and headaches, troubles through neighbors, sickness, wounds or hurts, quarrels, addiction to drinks, betting and prostitutes, boils and hurts of arms, travels in forests and villages, sorrows, royal disfavour, imprisonment. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD2)),
		new EventData(EventName.MercuryRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu - 2 years, 6 months, 18 days. Intercourse with servants and prostitutes, skin diseases, sufferings from hot diseases, bad company and dirty meals. change or present position, fear and danger through foreigners, disputes concerning property, failure in litigation, evil dreams. headaches, sickness and loss of appetite. wealth from friends and relatives, happiness, new earnings. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD2)),
		new EventData(EventName.MercuryJupiterPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter - 2 years, 3 months 6 days. Hatred of friends, relatives and elders, wealth, liable to diseases, acquisition of land and wealth, gain by trade, reputation, good happiness, good credit, benefits from superiors, birth of a child or marriage. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD2)),
		new EventData(EventName.MercurySaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Saturn - 2 years, 8 months, 9 days. Bad luck. stranger to success and happiness, severe reversal, enmity, pain in the part governed by Saturn, downfall or disgrace to relatives, mind full of evil forebodings and distress. rear from diseases, loans, loss of children, destruction of family, scandals, troubles from foreigners, earnings through evil ways, acts of charity and beneficence, acquisition of wealth, material comforts through petty chiefs, failure in agricultural operations. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD2)),
		new EventData(EventName.MercuryMercuryPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Good),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury's sub-period - 2 years, 4 months, 27 Acquisition of beautiful house and apparel, money through relatives, success in every undertaking, the birth of a brother or sister, increase in family, gain in business, good mind charitable acts, learning of mathematics and arts. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD2)),
		new EventData(EventName.MercuryKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu - 11 months, 27 days. Sorrow, disease, loss of work and Dharma, bilious sickness, aimless wandering, loss of property, misfortune to relatives, troubles through doctors, mental anxiety, trouble from relatives, mental agony, loss of comfort, dread of enemy, failure in business. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD2)),
		new EventData(EventName.MercuryVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus - 2 years, 10 months. Observance of duty, conformable to religion and morality, acquisition of wealth, clothes and jewels, birth or good children, happiness in married state, relatives prosper, trade increases, knowledge gained, return from a long journey, if not married, betrothal in this period, health, ornaments, vehicles, house, money gained. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD2)),
		new EventData(EventName.KetuSunPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun's sub-period - 4 months, 6 days. Disappointment, physical pain, exile in foreign country, peril and obstruction in every business, increase of knowledge, sickness in family, long journey and return, anxiety about wife's health. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD2)),
		new EventData(EventName.KetuMoonPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Moon's sub-period-7 months. Disputes about fair sex, trouble through children, gains and financial success, diseases of biliousness and cold, loss of relatives and money, destruction of wealth and distress of mind. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD2)),
		new EventData(EventName.KetuMarsPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Mars' sub-period - 4 months, 27 days. Odium of sons, wife and younger brothers, loss of relatives, trouble from diseases, foes and bad rulers, path of progress obstructed, fear and anxiety, disputes and contests of different kinds, enemies arise, danger of disputes and destruction through females, sufferings from fever, fear of robbers, death, imprisonment, urinary diseases, loss and difficulties and surgical operations. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD2)),
		new EventData(EventName.KetuRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Rahu - 1 year, 18 days. Loss of lands, imprisonment, quarrel with friends, danger of blood poisoning, danger of ruin, loss of property, fame and honour, rear of kings and robbers, sorrow, ruin of all business, adultery with mean women. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD2)),
		new EventData(EventName.KetuJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter - 11 months, 6 days. Exemption from ailments, acquisition of lands and birth of children, profitable transactions, association with people of good position, danger of poison, wife an object of pleasure, if unmarried marriage takes place. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD2)),
		new EventData(EventName.KetuSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn - 1 year, 1 month, 9 days. Loss of wife, danger from enemies, imprisonment, loss of wealth, indigestion, property in danger or ruin, heavy loss in different ways, change of residence, some cutaneous diseases. anxiety owing to sickness of partner misgivings in the heart, mental anguish, difference of opinion with relations, exile in foreign countries. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD2)),
		new EventData(EventName.KetuMercuryPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury - 11 months 27 days. Society of relatives, friends and the like, material gains from knowledge, danger from relatives, anxiety on account of children, failure in plans, deception, jealousy, falsehood, and knowledge. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD2)),
		new EventData(EventName.KetuKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Ketu's sub-period - 4 months, 27 days. Fear of death of wife or children, loss of wealth and happiness, mental troubles, separation from relatives, subject to some estrangement, restraint or detention, danger of poison. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD2)),
		new EventData(EventName.KetuVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Venus - 1 year, 2 months. Wealth and happiness, birth of a child, efforts crowned with success, in the end sickness, wife ill, illness to children, quarrels, loss of relatives and friends, fever and dysentery. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD2)),
		new EventData(EventName.VenusSunPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Sun - 1 year. Anxious about everything, prosperity collapses, troubles with wife, children, land, family, disputes and quarrels, diseases affecting head, belly and eyes, damage in respect of agriculture. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD2)),
		new EventData(EventName.VenusMoonPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Moon - 1 year, 8 months. Gains of females, education, knowledge, money, children and vehicles, worship of God, accomplishments of desires, troubles through wife, domestic happiness afterwards, pain and disease due to inflammation of nervous tissue and from lust and other passions of human nature. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD2)),
		new EventData(EventName.VenusMarsPD2, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mars - 1 year, 2 months. Flow of bile, disease of the eyes, great exertion, much income, acquisition or wealth, marriage, acquisition of lands, venereal diseases, danger from arms, exile in foreign places, atheistic tendencies, increase of property through the influence of females, negligence of duty, bent on pleasure and passion, temporary affection of eyes. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD2)),
		new EventData(EventName.VenusRahuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Rahu - 3 years. Meditation, seclusion, quarrels among relatives and his people, entire change of surroundings, schemes of deception. miserliness, acquisition of lost property, dislike of relatives. evil from friends and injury by fire. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD2)),
		new EventData(EventName.VenusJupiterPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Jupiter - 2 years, 8 months. Means of livelihood settled, gains from profession, benefits through superiors or employers or persons ruled by Jupiter fame, anxiety, quarrels with saints and religious men, gain of knowledge, end of dependence, worship of certain inferior natural forces, happiness and health, marriages, sexual intercourse, increase of family reputation and good deeds, wealth. ultimate happiness, wife and children suffer in the end. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD2)),
		new EventData(EventName.VenusSaturnPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Saturn - 3 years, 2 months Sexual intercourse with females advanced in age, accession to lands and wealth, disappearance of enemies, affection of excretory system, piles, etc., rheumatic pains in legs and bands, danger to eye sight, distaste for food, loss of appetite, physical condition poor, loss of money, wanderings, servitude, bolting and gambling, addiction to liquor, bad company, etc., ill-health, loss of memory, impotence. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD2)),
		new EventData(EventName.VenusMercuryPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Good),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Mercury - 2 years, 10 months. Association with prostitutes, enjoyments, knowledge, mathematical learning, success in litigations, inclination to learn music, piles and other hot ailments, pleasure through wife and children, increase of wealth, gain of knowledge in aru and sciences, wealth, royal favour, prosperity on a large scale and sound health. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD2)),
		new EventData(EventName.VenusKetuPD2, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Bad),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Bad),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Ketu - 1 year, 2 months. Discordance, death of relatives, injury inflicted by enemies, misgivings in heart, deprivation of wealth, troubles through wife, danger from quadrupeds, illness to partner or a member of the family, accidental blood poisoning, delirious fits, weakness in body and mind, gradual loss of wealth, loss of relatives, bad company, abode in seclusion, manifold sorrows, but happiness in the end. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD2)),
		new EventData(EventName.VenusVenusPD2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Venus - 3 years, 4 months. Success, good servants and good many pleasures, money plentiful. disappearance of enemies, attainment of fame and birth of children. ", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD2
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD2)),
		new EventData(EventName.SunSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD3)),
		new EventData(EventName.MoonSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD3)),
		new EventData(EventName.MarsSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD3)),
		new EventData(EventName.RahuSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD3)),
		new EventData(EventName.JupiterSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD3)),
		new EventData(EventName.SaturnSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD3)),
		new EventData(EventName.MercurySunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD3)),
		new EventData(EventName.KetuSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD3)),
		new EventData(EventName.VenusSunPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD3)),
		new EventData(EventName.SunMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD3)),
		new EventData(EventName.MoonMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD3)),
		new EventData(EventName.MarsMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD3)),
		new EventData(EventName.RahuMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD3)),
		new EventData(EventName.JupiterMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD3)),
		new EventData(EventName.SaturnMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD3)),
		new EventData(EventName.MercuryMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD3)),
		new EventData(EventName.KetuMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD3)),
		new EventData(EventName.VenusMoonPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD3)),
		new EventData(EventName.SunMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD3)),
		new EventData(EventName.MoonMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD3)),
		new EventData(EventName.MarsMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD3)),
		new EventData(EventName.RahuMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD3)),
		new EventData(EventName.JupiterMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD3)),
		new EventData(EventName.SaturnMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD3)),
		new EventData(EventName.MercuryMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD3)),
		new EventData(EventName.KetuMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD3)),
		new EventData(EventName.VenusMarsPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD3)),
		new EventData(EventName.SunRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD3)),
		new EventData(EventName.MoonRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD3)),
		new EventData(EventName.MarsRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD3)),
		new EventData(EventName.RahuRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD3)),
		new EventData(EventName.JupiterRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD3)),
		new EventData(EventName.SaturnRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD3)),
		new EventData(EventName.MercuryRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD3)),
		new EventData(EventName.KetuRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD3)),
		new EventData(EventName.VenusRahuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD3)),
		new EventData(EventName.SunJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD3)),
		new EventData(EventName.MoonJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD3)),
		new EventData(EventName.MarsJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD3)),
		new EventData(EventName.RahuJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD3)),
		new EventData(EventName.JupiterJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD3)),
		new EventData(EventName.SaturnJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD3)),
		new EventData(EventName.MercuryJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD3)),
		new EventData(EventName.KetuJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD3)),
		new EventData(EventName.VenusJupiterPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD3)),
		new EventData(EventName.SunSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD3)),
		new EventData(EventName.MoonSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD3)),
		new EventData(EventName.MarsSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD3)),
		new EventData(EventName.RahuSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD3)),
		new EventData(EventName.JupiterSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD3)),
		new EventData(EventName.SaturnSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD3)),
		new EventData(EventName.MercurySaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD3)),
		new EventData(EventName.KetuSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD3)),
		new EventData(EventName.VenusSaturnPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD3)),
		new EventData(EventName.SunMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD3)),
		new EventData(EventName.MoonMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD3)),
		new EventData(EventName.MarsMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD3)),
		new EventData(EventName.RahuMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD3)),
		new EventData(EventName.JupiterMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD3)),
		new EventData(EventName.SaturnMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD3)),
		new EventData(EventName.MercuryMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD3)),
		new EventData(EventName.KetuMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD3)),
		new EventData(EventName.VenusMercuryPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD3)),
		new EventData(EventName.SunKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD3)),
		new EventData(EventName.MoonKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD3)),
		new EventData(EventName.MarsKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD3)),
		new EventData(EventName.RahuKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD3)),
		new EventData(EventName.JupiterKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD3)),
		new EventData(EventName.SaturnKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD3)),
		new EventData(EventName.MercuryKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD3)),
		new EventData(EventName.KetuKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD3)),
		new EventData(EventName.VenusKetuPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD3)),
		new EventData(EventName.SunVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD3)),
		new EventData(EventName.MoonVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD3)),
		new EventData(EventName.MarsVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD3)),
		new EventData(EventName.RahuVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD3)),
		new EventData(EventName.JupiterVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD3)),
		new EventData(EventName.SaturnVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD3)),
		new EventData(EventName.MercuryVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD3)),
		new EventData(EventName.KetuVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD3)),
		new EventData(EventName.VenusVenusPD3, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD3
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD3)),
		new EventData(EventName.SunSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD4)),
		new EventData(EventName.MoonSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD4)),
		new EventData(EventName.MarsSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD4)),
		new EventData(EventName.RahuSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD4)),
		new EventData(EventName.JupiterSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD4)),
		new EventData(EventName.SaturnSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD4)),
		new EventData(EventName.MercurySunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD4)),
		new EventData(EventName.KetuSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD4)),
		new EventData(EventName.VenusSunPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD4)),
		new EventData(EventName.SunMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD4)),
		new EventData(EventName.MoonMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD4)),
		new EventData(EventName.MarsMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD4)),
		new EventData(EventName.RahuMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD4)),
		new EventData(EventName.JupiterMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD4)),
		new EventData(EventName.SaturnMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD4)),
		new EventData(EventName.MercuryMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD4)),
		new EventData(EventName.KetuMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD4)),
		new EventData(EventName.VenusMoonPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD4)),
		new EventData(EventName.SunMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD4)),
		new EventData(EventName.MoonMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD4)),
		new EventData(EventName.MarsMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD4)),
		new EventData(EventName.RahuMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD4)),
		new EventData(EventName.JupiterMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD4)),
		new EventData(EventName.SaturnMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD4)),
		new EventData(EventName.MercuryMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD4)),
		new EventData(EventName.KetuMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD4)),
		new EventData(EventName.VenusMarsPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD4)),
		new EventData(EventName.SunRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD4)),
		new EventData(EventName.MoonRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD4)),
		new EventData(EventName.MarsRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD4)),
		new EventData(EventName.RahuRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD4)),
		new EventData(EventName.JupiterRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD4)),
		new EventData(EventName.SaturnRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD4)),
		new EventData(EventName.MercuryRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD4)),
		new EventData(EventName.KetuRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD4)),
		new EventData(EventName.VenusRahuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD4)),
		new EventData(EventName.SunJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD4)),
		new EventData(EventName.MoonJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD4)),
		new EventData(EventName.MarsJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD4)),
		new EventData(EventName.RahuJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD4)),
		new EventData(EventName.JupiterJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD4)),
		new EventData(EventName.SaturnJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD4)),
		new EventData(EventName.MercuryJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD4)),
		new EventData(EventName.KetuJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD4)),
		new EventData(EventName.VenusJupiterPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD4)),
		new EventData(EventName.SunSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD4)),
		new EventData(EventName.MoonSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD4)),
		new EventData(EventName.MarsSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD4)),
		new EventData(EventName.RahuSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD4)),
		new EventData(EventName.JupiterSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD4)),
		new EventData(EventName.SaturnSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD4)),
		new EventData(EventName.MercurySaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD4)),
		new EventData(EventName.KetuSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD4)),
		new EventData(EventName.VenusSaturnPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD4)),
		new EventData(EventName.SunMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD4)),
		new EventData(EventName.MoonMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD4)),
		new EventData(EventName.MarsMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD4)),
		new EventData(EventName.RahuMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD4)),
		new EventData(EventName.JupiterMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD4)),
		new EventData(EventName.SaturnMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD4)),
		new EventData(EventName.MercuryMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD4)),
		new EventData(EventName.KetuMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD4)),
		new EventData(EventName.VenusMercuryPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD4)),
		new EventData(EventName.SunKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD4)),
		new EventData(EventName.MoonKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD4)),
		new EventData(EventName.MarsKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD4)),
		new EventData(EventName.RahuKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD4)),
		new EventData(EventName.JupiterKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD4)),
		new EventData(EventName.SaturnKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD4)),
		new EventData(EventName.MercuryKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD4)),
		new EventData(EventName.KetuKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD4)),
		new EventData(EventName.VenusKetuPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD4)),
		new EventData(EventName.SunVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD4)),
		new EventData(EventName.MoonVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD4)),
		new EventData(EventName.MarsVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD4)),
		new EventData(EventName.RahuVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD4)),
		new EventData(EventName.JupiterVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD4)),
		new EventData(EventName.SaturnVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD4)),
		new EventData(EventName.MercuryVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD4)),
		new EventData(EventName.KetuVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD4)),
		new EventData(EventName.VenusVenusPD4, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD4
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD4)),
		new EventData(EventName.SunSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD5)),
		new EventData(EventName.MoonSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD5)),
		new EventData(EventName.MarsSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD5)),
		new EventData(EventName.RahuSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD5)),
		new EventData(EventName.JupiterSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD5)),
		new EventData(EventName.SaturnSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD5)),
		new EventData(EventName.MercurySunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD5)),
		new EventData(EventName.KetuSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD5)),
		new EventData(EventName.VenusSunPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD5)),
		new EventData(EventName.SunMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD5)),
		new EventData(EventName.MoonMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD5)),
		new EventData(EventName.MarsMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD5)),
		new EventData(EventName.RahuMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD5)),
		new EventData(EventName.JupiterMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD5)),
		new EventData(EventName.SaturnMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD5)),
		new EventData(EventName.MercuryMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD5)),
		new EventData(EventName.KetuMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD5)),
		new EventData(EventName.VenusMoonPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD5)),
		new EventData(EventName.SunMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD5)),
		new EventData(EventName.MoonMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD5)),
		new EventData(EventName.MarsMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD5)),
		new EventData(EventName.RahuMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD5)),
		new EventData(EventName.JupiterMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD5)),
		new EventData(EventName.SaturnMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD5)),
		new EventData(EventName.MercuryMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD5)),
		new EventData(EventName.KetuMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD5)),
		new EventData(EventName.VenusMarsPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD5)),
		new EventData(EventName.SunRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD5)),
		new EventData(EventName.MoonRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD5)),
		new EventData(EventName.MarsRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD5)),
		new EventData(EventName.RahuRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD5)),
		new EventData(EventName.JupiterRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD5)),
		new EventData(EventName.SaturnRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD5)),
		new EventData(EventName.MercuryRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD5)),
		new EventData(EventName.KetuRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD5)),
		new EventData(EventName.VenusRahuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD5)),
		new EventData(EventName.SunJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD5)),
		new EventData(EventName.MoonJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD5)),
		new EventData(EventName.MarsJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD5)),
		new EventData(EventName.RahuJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD5)),
		new EventData(EventName.JupiterJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD5)),
		new EventData(EventName.SaturnJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD5)),
		new EventData(EventName.MercuryJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD5)),
		new EventData(EventName.KetuJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD5)),
		new EventData(EventName.VenusJupiterPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD5)),
		new EventData(EventName.SunSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD5)),
		new EventData(EventName.MoonSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD5)),
		new EventData(EventName.MarsSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD5)),
		new EventData(EventName.RahuSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD5)),
		new EventData(EventName.JupiterSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD5)),
		new EventData(EventName.SaturnSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD5)),
		new EventData(EventName.MercurySaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD5)),
		new EventData(EventName.KetuSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD5)),
		new EventData(EventName.VenusSaturnPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD5)),
		new EventData(EventName.SunMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD5)),
		new EventData(EventName.MoonMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD5)),
		new EventData(EventName.MarsMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD5)),
		new EventData(EventName.RahuMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD5)),
		new EventData(EventName.JupiterMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD5)),
		new EventData(EventName.SaturnMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD5)),
		new EventData(EventName.MercuryMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD5)),
		new EventData(EventName.KetuMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD5)),
		new EventData(EventName.VenusMercuryPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD5)),
		new EventData(EventName.SunKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD5)),
		new EventData(EventName.MoonKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD5)),
		new EventData(EventName.MarsKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD5)),
		new EventData(EventName.RahuKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD5)),
		new EventData(EventName.JupiterKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD5)),
		new EventData(EventName.SaturnKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD5)),
		new EventData(EventName.MercuryKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD5)),
		new EventData(EventName.KetuKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD5)),
		new EventData(EventName.VenusKetuPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD5)),
		new EventData(EventName.SunVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD5)),
		new EventData(EventName.MoonVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD5)),
		new EventData(EventName.MarsVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD5)),
		new EventData(EventName.RahuVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD5)),
		new EventData(EventName.JupiterVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD5)),
		new EventData(EventName.SaturnVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD5)),
		new EventData(EventName.MercuryVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD5)),
		new EventData(EventName.KetuVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD5)),
		new EventData(EventName.VenusVenusPD5, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD5
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD5)),
		new EventData(EventName.SunSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD6)),
		new EventData(EventName.MoonSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD6)),
		new EventData(EventName.MarsSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD6)),
		new EventData(EventName.RahuSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD6)),
		new EventData(EventName.JupiterSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD6)),
		new EventData(EventName.SaturnSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD6)),
		new EventData(EventName.MercurySunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD6)),
		new EventData(EventName.KetuSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD6)),
		new EventData(EventName.VenusSunPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD6)),
		new EventData(EventName.SunMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD6)),
		new EventData(EventName.MoonMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD6)),
		new EventData(EventName.MarsMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD6)),
		new EventData(EventName.RahuMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD6)),
		new EventData(EventName.JupiterMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD6)),
		new EventData(EventName.SaturnMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD6)),
		new EventData(EventName.MercuryMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD6)),
		new EventData(EventName.KetuMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD6)),
		new EventData(EventName.VenusMoonPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD6)),
		new EventData(EventName.SunMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD6)),
		new EventData(EventName.MoonMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD6)),
		new EventData(EventName.MarsMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD6)),
		new EventData(EventName.RahuMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD6)),
		new EventData(EventName.JupiterMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD6)),
		new EventData(EventName.SaturnMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD6)),
		new EventData(EventName.MercuryMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD6)),
		new EventData(EventName.KetuMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD6)),
		new EventData(EventName.VenusMarsPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD6)),
		new EventData(EventName.SunRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD6)),
		new EventData(EventName.MoonRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD6)),
		new EventData(EventName.MarsRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD6)),
		new EventData(EventName.RahuRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD6)),
		new EventData(EventName.JupiterRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD6)),
		new EventData(EventName.SaturnRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD6)),
		new EventData(EventName.MercuryRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD6)),
		new EventData(EventName.KetuRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD6)),
		new EventData(EventName.VenusRahuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD6)),
		new EventData(EventName.SunJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD6)),
		new EventData(EventName.MoonJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD6)),
		new EventData(EventName.MarsJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD6)),
		new EventData(EventName.RahuJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD6)),
		new EventData(EventName.JupiterJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD6)),
		new EventData(EventName.SaturnJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD6)),
		new EventData(EventName.MercuryJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD6)),
		new EventData(EventName.KetuJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD6)),
		new EventData(EventName.VenusJupiterPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD6)),
		new EventData(EventName.SunSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD6)),
		new EventData(EventName.MoonSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD6)),
		new EventData(EventName.MarsSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD6)),
		new EventData(EventName.RahuSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD6)),
		new EventData(EventName.JupiterSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD6)),
		new EventData(EventName.SaturnSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD6)),
		new EventData(EventName.MercurySaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD6)),
		new EventData(EventName.KetuSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD6)),
		new EventData(EventName.VenusSaturnPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD6)),
		new EventData(EventName.SunMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD6)),
		new EventData(EventName.MoonMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD6)),
		new EventData(EventName.MarsMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD6)),
		new EventData(EventName.RahuMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD6)),
		new EventData(EventName.JupiterMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD6)),
		new EventData(EventName.SaturnMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD6)),
		new EventData(EventName.MercuryMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD6)),
		new EventData(EventName.KetuMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD6)),
		new EventData(EventName.VenusMercuryPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD6)),
		new EventData(EventName.SunKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD6)),
		new EventData(EventName.MoonKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD6)),
		new EventData(EventName.MarsKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD6)),
		new EventData(EventName.RahuKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD6)),
		new EventData(EventName.JupiterKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD6)),
		new EventData(EventName.SaturnKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD6)),
		new EventData(EventName.MercuryKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD6)),
		new EventData(EventName.KetuKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD6)),
		new EventData(EventName.VenusKetuPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD6)),
		new EventData(EventName.SunVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD6)),
		new EventData(EventName.MoonVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD6)),
		new EventData(EventName.MarsVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD6)),
		new EventData(EventName.RahuVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD6)),
		new EventData(EventName.JupiterVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD6)),
		new EventData(EventName.SaturnVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD6)),
		new EventData(EventName.MercuryVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD6)),
		new EventData(EventName.KetuVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD6)),
		new EventData(EventName.VenusVenusPD6, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD6
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD6)),
		new EventData(EventName.SunSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD7)),
		new EventData(EventName.MoonSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD7)),
		new EventData(EventName.MarsSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD7)),
		new EventData(EventName.RahuSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD7)),
		new EventData(EventName.JupiterSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD7)),
		new EventData(EventName.SaturnSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD7)),
		new EventData(EventName.MercurySunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD7)),
		new EventData(EventName.KetuSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD7)),
		new EventData(EventName.VenusSunPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD7)),
		new EventData(EventName.SunMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD7)),
		new EventData(EventName.MoonMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD7)),
		new EventData(EventName.MarsMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD7)),
		new EventData(EventName.RahuMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD7)),
		new EventData(EventName.JupiterMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD7)),
		new EventData(EventName.SaturnMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD7)),
		new EventData(EventName.MercuryMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD7)),
		new EventData(EventName.KetuMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD7)),
		new EventData(EventName.VenusMoonPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD7)),
		new EventData(EventName.SunMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD7)),
		new EventData(EventName.MoonMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD7)),
		new EventData(EventName.MarsMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD7)),
		new EventData(EventName.RahuMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD7)),
		new EventData(EventName.JupiterMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD7)),
		new EventData(EventName.SaturnMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD7)),
		new EventData(EventName.MercuryMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD7)),
		new EventData(EventName.KetuMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD7)),
		new EventData(EventName.VenusMarsPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD7)),
		new EventData(EventName.SunRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD7)),
		new EventData(EventName.MoonRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD7)),
		new EventData(EventName.MarsRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD7)),
		new EventData(EventName.RahuRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD7)),
		new EventData(EventName.JupiterRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD7)),
		new EventData(EventName.SaturnRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD7)),
		new EventData(EventName.MercuryRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD7)),
		new EventData(EventName.KetuRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD7)),
		new EventData(EventName.VenusRahuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD7)),
		new EventData(EventName.SunJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD7)),
		new EventData(EventName.MoonJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD7)),
		new EventData(EventName.MarsJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD7)),
		new EventData(EventName.RahuJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD7)),
		new EventData(EventName.JupiterJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD7)),
		new EventData(EventName.SaturnJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD7)),
		new EventData(EventName.MercuryJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD7)),
		new EventData(EventName.KetuJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD7)),
		new EventData(EventName.VenusJupiterPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD7)),
		new EventData(EventName.SunSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD7)),
		new EventData(EventName.MoonSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD7)),
		new EventData(EventName.MarsSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD7)),
		new EventData(EventName.RahuSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD7)),
		new EventData(EventName.JupiterSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD7)),
		new EventData(EventName.SaturnSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD7)),
		new EventData(EventName.MercurySaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD7)),
		new EventData(EventName.KetuSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD7)),
		new EventData(EventName.VenusSaturnPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD7)),
		new EventData(EventName.SunMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD7)),
		new EventData(EventName.MoonMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD7)),
		new EventData(EventName.MarsMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD7)),
		new EventData(EventName.RahuMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD7)),
		new EventData(EventName.JupiterMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD7)),
		new EventData(EventName.SaturnMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD7)),
		new EventData(EventName.MercuryMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD7)),
		new EventData(EventName.KetuMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD7)),
		new EventData(EventName.VenusMercuryPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD7)),
		new EventData(EventName.SunKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD7)),
		new EventData(EventName.MoonKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD7)),
		new EventData(EventName.MarsKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD7)),
		new EventData(EventName.RahuKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD7)),
		new EventData(EventName.JupiterKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD7)),
		new EventData(EventName.SaturnKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD7)),
		new EventData(EventName.MercuryKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD7)),
		new EventData(EventName.KetuKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD7)),
		new EventData(EventName.VenusKetuPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD7)),
		new EventData(EventName.SunVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD7)),
		new EventData(EventName.MoonVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD7)),
		new EventData(EventName.MarsVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD7)),
		new EventData(EventName.RahuVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD7)),
		new EventData(EventName.JupiterVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD7)),
		new EventData(EventName.SaturnVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD7)),
		new EventData(EventName.MercuryVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD7)),
		new EventData(EventName.KetuVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD7)),
		new EventData(EventName.VenusVenusPD7, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD7
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD7)),
		new EventData(EventName.SunSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunSunPD8)),
		new EventData(EventName.MoonSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSunPD8)),
		new EventData(EventName.MarsSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSunPD8)),
		new EventData(EventName.RahuSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSunPD8)),
		new EventData(EventName.JupiterSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSunPD8)),
		new EventData(EventName.SaturnSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSunPD8)),
		new EventData(EventName.MercurySunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySunPD8)),
		new EventData(EventName.KetuSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSunPD8)),
		new EventData(EventName.VenusSunPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSunPD8)),
		new EventData(EventName.SunMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunMoonPD8)),
		new EventData(EventName.MoonMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMoonPD8)),
		new EventData(EventName.MarsMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMoonPD8)),
		new EventData(EventName.RahuMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMoonPD8)),
		new EventData(EventName.JupiterMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMoonPD8)),
		new EventData(EventName.SaturnMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMoonPD8)),
		new EventData(EventName.MercuryMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMoonPD8)),
		new EventData(EventName.KetuMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMoonPD8)),
		new EventData(EventName.VenusMoonPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMoonPD8)),
		new EventData(EventName.SunMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunMarsPD8)),
		new EventData(EventName.MoonMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMarsPD8)),
		new EventData(EventName.MarsMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMarsPD8)),
		new EventData(EventName.RahuMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMarsPD8)),
		new EventData(EventName.JupiterMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMarsPD8)),
		new EventData(EventName.SaturnMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMarsPD8)),
		new EventData(EventName.MercuryMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMarsPD8)),
		new EventData(EventName.KetuMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMarsPD8)),
		new EventData(EventName.VenusMarsPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMarsPD8)),
		new EventData(EventName.SunRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunRahuPD8)),
		new EventData(EventName.MoonRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonRahuPD8)),
		new EventData(EventName.MarsRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsRahuPD8)),
		new EventData(EventName.RahuRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuRahuPD8)),
		new EventData(EventName.JupiterRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterRahuPD8)),
		new EventData(EventName.SaturnRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnRahuPD8)),
		new EventData(EventName.MercuryRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryRahuPD8)),
		new EventData(EventName.KetuRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuRahuPD8)),
		new EventData(EventName.VenusRahuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusRahuPD8)),
		new EventData(EventName.SunJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunJupiterPD8)),
		new EventData(EventName.MoonJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonJupiterPD8)),
		new EventData(EventName.MarsJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsJupiterPD8)),
		new EventData(EventName.RahuJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuJupiterPD8)),
		new EventData(EventName.JupiterJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterJupiterPD8)),
		new EventData(EventName.SaturnJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnJupiterPD8)),
		new EventData(EventName.MercuryJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryJupiterPD8)),
		new EventData(EventName.KetuJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuJupiterPD8)),
		new EventData(EventName.VenusJupiterPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusJupiterPD8)),
		new EventData(EventName.SunSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunSaturnPD8)),
		new EventData(EventName.MoonSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonSaturnPD8)),
		new EventData(EventName.MarsSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsSaturnPD8)),
		new EventData(EventName.RahuSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuSaturnPD8)),
		new EventData(EventName.JupiterSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterSaturnPD8)),
		new EventData(EventName.SaturnSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnSaturnPD8)),
		new EventData(EventName.MercurySaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercurySaturnPD8)),
		new EventData(EventName.KetuSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuSaturnPD8)),
		new EventData(EventName.VenusSaturnPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusSaturnPD8)),
		new EventData(EventName.SunMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunMercuryPD8)),
		new EventData(EventName.MoonMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonMercuryPD8)),
		new EventData(EventName.MarsMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsMercuryPD8)),
		new EventData(EventName.RahuMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuMercuryPD8)),
		new EventData(EventName.JupiterMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterMercuryPD8)),
		new EventData(EventName.SaturnMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnMercuryPD8)),
		new EventData(EventName.MercuryMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryMercuryPD8)),
		new EventData(EventName.KetuMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuMercuryPD8)),
		new EventData(EventName.VenusMercuryPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusMercuryPD8)),
		new EventData(EventName.SunKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunKetuPD8)),
		new EventData(EventName.MoonKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonKetuPD8)),
		new EventData(EventName.MarsKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsKetuPD8)),
		new EventData(EventName.RahuKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuKetuPD8)),
		new EventData(EventName.JupiterKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterKetuPD8)),
		new EventData(EventName.SaturnKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnKetuPD8)),
		new EventData(EventName.MercuryKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryKetuPD8)),
		new EventData(EventName.KetuKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuKetuPD8)),
		new EventData(EventName.VenusKetuPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusKetuPD8)),
		new EventData(EventName.SunVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SunVenusPD8)),
		new EventData(EventName.MoonVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MoonVenusPD8)),
		new EventData(EventName.MarsVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MarsVenusPD8)),
		new EventData(EventName.RahuVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.RahuVenusPD8)),
		new EventData(EventName.JupiterVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.JupiterVenusPD8)),
		new EventData(EventName.SaturnVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.SaturnVenusPD8)),
		new EventData(EventName.MercuryVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.MercuryVenusPD8)),
		new EventData(EventName.KetuVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.KetuVenusPD8)),
		new EventData(EventName.VenusVenusPD8, EventNature.Empty, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, "", new List<EventTag>(2)
		{
			EventTag.Dasa,
			EventTag.PD8
		}, EventManager.GetEventCalculatorMethod(EventName.VenusVenusPD8)),
		new EventData(EventName.Lord6And8Dasa, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Dasa period of the lords of the 6th and the 8th produce harmful results unless they acquire beneficence otherwise. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Lord6And8Dasa)),
		new EventData(EventName.Lord5And9Dasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The periods of lords of the 5th and the 9th are said to be good, so much so that the periods of planets, which are joined or otherwise related with them, are also supposed to give rise to good. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Lord5And9Dasa)),
		new EventData(EventName.Lord5And9DasaBhukti, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The sub-period of the lord of the 5th in the major period of the lord of the 9th or vice versa is supposed to produce good effects. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Lord5And9DasaBhukti)),
		new EventData(EventName.BhuktiDasaLordInBadHouses, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Unfavourable results will be realised when the sub-lord and the major lord are situated in the 6th and the 8th or the 12th and the 2nd from each other respectively. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.BhuktiDasaLordInBadHouses)),
		new EventData(EventName.Lord2Dasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Lord of the 2nd in his Dasa gives wealth ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Lord2Dasa)),
		new EventData(EventName.Lord3Dasa, EventNature.Neutral, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " Lord of the 3rd during his Dasa gives new friends, help to brothers, leadership, and physical pain (if afflicted). ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Lord3Dasa)),
		new EventData(EventName.LagnaLordDasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " When Lagna (Ascendant) is powerful, during the Dasa of lord of Lagna, favourable results can be expected to occur - such as rise in profession, good health and general prosperity. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.LagnaLordDasa)),
		new EventData(EventName.Saturn4thDasa, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Dasa period of Saturn, if it happens to be the 4th Dasa, will be unfavourable. If Saturn is strong and favorably disposed, the evil effects get considerably modified. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Saturn4thDasa)),
		new EventData(EventName.Jupiter6thDasa, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Dasa period of Jupiter will be unfavourable if it happens to be the 6th Dasa. If Saturn is strong and favorably disposed, the evil effects get considerably modified. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.Jupiter6thDasa)),
		new EventData(EventName.ElevatedSunDasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " If the Sun is elevated, he displays wisdom, gets money, attains fame and happiness ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.ElevatedSunDasa)),
		new EventData(EventName.SunWithLord9Or10Dasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun in good position, in own house or joined with lord of 9 or 10 - happiness, gains, riches, honours ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.SunWithLord9Or10Dasa)),
		new EventData(EventName.SunWithLord5Dasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Good),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun with lord of 5 - birth of children. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.SunWithLord5Dasa)),
		new EventData(EventName.SunWithLord2Dasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Sun when related to lord of 2 - becomes rich, earns money, secures property, gains, favours from influential persons. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.SunWithLord2Dasa)),
		new EventData(EventName.SunBadPositionDasa, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Bad),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Bad)
		}, " The Sun when debilitated or occupies the 6th or the 8th house or in cojunction with evil planets contracts evil diseases, loss of wealth, suffers from reverses in employment, penalty and becomes ill. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.SunBadPositionDasa)),
		new EventData(EventName.ExaltedSunDasa, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Bad),
			Money = new SummaryMetadata(EventNature.Good),
			Love = new SummaryMetadata(EventNature.Good),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Dasa of the Sun in deep exaltation : Sudden gains in cattle and wealth, much travelling in eastern countries, residence in foreign countries, quarrels among friends and relations, pleasure trios and picnic parties and lovely women. ", new List<EventTag>(1) { EventTag.DasaSpecialRules }, EventManager.GetEventCalculatorMethod(EventName.ExaltedSunDasa)),
		new EventData(EventName.BadLunarMonthForBuilding, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " No house-building should be commenced in the lunar months of Jyeshta, Ashadha, Bhadrapada, Aswayuja, Margasira, Pushya and Phalguna as they connote respectively death, destruction, disease, quarrels and misunderstandings, loss of wealth, incendiarism and physical danger ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.BadLunarMonthForBuilding)),
		new EventData(EventName.GoodSunSignForBuilding, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " For building work, the Sun should occupy fixed signs or at least movable signs. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.GoodSunSignForBuilding)),
		new EventData(EventName.BadSunSignForBuilding, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " No building work should be undertaken when the Sun is in common signs. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.BadSunSignForBuilding)),
		new EventData(EventName.GoodLunarDayForBuilding, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for building: - All odd tithis (lunar days) except the 9th are good. - Of the even tithis the 2nd, 6th and 10th are auspicious. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.GoodLunarDayForBuilding)),
		new EventData(EventName.GoodWeekDayForBuilding, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Good for building: Monday, Wednesday, Thursday and Friday are the best. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.GoodWeekDayForBuilding)),
		new EventData(EventName.BadLunarPhaseForBuilding, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Moon is waning. Even Monday should be rejected when the Moon is waning. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.BadLunarPhaseForBuilding)),
		new EventData(EventName.BadWeekDayForBuilding, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Saturday should be rejected as it connots frequent thefts. Sunday should also be avoided unless the day is otherwise very auspicious. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.BadWeekDayForBuilding)),
		new EventData(EventName.BadWeekDayForRepairs, EventNature.Bad, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Do not commence repairs on Tuesdays. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.BadWeekDayForRepairs)),
		new EventData(EventName.GoodYogaForRepairs, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " Friday at a moment when Lagna is Taurus or Libra and Monday when Cancer is rising are very suitable for beginning repairs ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.GoodYogaForRepairs)),
		new EventData(EventName.GoodYogaForRepairs2, EventNature.Good, new SpecializedSummary
		{
			Mind = new SummaryMetadata(EventNature.Neutral),
			Studies = new SummaryMetadata(EventNature.Neutral),
			Family = new SummaryMetadata(EventNature.Neutral),
			Money = new SummaryMetadata(EventNature.Neutral),
			Love = new SummaryMetadata(EventNature.Neutral),
			Body = new SummaryMetadata(EventNature.Neutral)
		}, " The Lagna must be occupied by a benefic and the Moon should be in an aquatic sign. ", new List<EventTag>(1) { EventTag.Building }, EventManager.GetEventCalculatorMethod(EventName.GoodYogaForRepairs2))
	};
}
