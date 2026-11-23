using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace VedAstro.Library;

public static class VimshottariDasa
{
	public static JObject GetDasaJson(List<DasaEvent> allDasaEvents, int level, DasaEvent parentDasa = null)
	{
		JObject jObject = new JObject();
		List<DasaEvent> list = ((parentDasa != null) ? allDasaEvents.FindAll(delegate(DasaEvent dasaEvt)
		{
			bool num = dasaEvt.DasaLevel == level;
			bool flag = dasaEvt.ParentLord == parentDasa.Lord;
			bool flag2 = dasaEvt.EndTime.GetStdDateTimeOffset() <= parentDasa.EndTime.GetStdDateTimeOffset();
			return num & flag & flag2;
		}) : allDasaEvents.FindAll((DasaEvent dasaEvt) => dasaEvt.DasaLevel == level));
		if (!list.Any())
		{
			return null;
		}
		foreach (DasaEvent item in list)
		{
			JObject jObject2 = new JObject
			{
				{ "Type", item.DasaName },
				{
					"Start",
					item.StartTime.GetStdDateTimeOffsetText()
				},
				{
					"End",
					item.EndTime.GetStdDateTimeOffsetText()
				},
				{ "DurationHours", item.Duration },
				{
					"DurationText",
					Tools.TimeDurationToHumanText(item.Duration)
				},
				{
					"TechnicalName",
					item.SourceEvent.Name.ToString()
				},
				{
					"Lord",
					item.Lord.ToString()
				},
				{
					"ParentLord",
					item.ParentLord.ToString()
				},
				{ "Description", item.Description },
				{
					"Nature",
					item.Nature.ToString()
				}
			};
			JObject dasaJson = GetDasaJson(allDasaEvents, level + 1, item);
			if (dasaJson != null)
			{
				jObject2.Add("SubDasas", dasaJson);
			}
			jObject[item.Lord.ToString()] = jObject2;
		}
		return jObject;
	}

	public static List<DasaEvent> DasaPeriodsOld(Time birthTime, int levels = 4, int scanYears = 120)
	{
		Time startTime = birthTime;
		Time endTime = birthTime.AddYears(scanYears);
		List<EventTag> inputedEventTags = new List<EventTag>
		{
			EventTag.PD1,
			EventTag.PD2,
			EventTag.PD3,
			EventTag.PD4
		};
		Person inputPerson = new Person("", birthTime, Gender.Empty);
		List<Event> list = EventManager.CalculateEvents(504.0, startTime, endTime, inputPerson, inputedEventTags);
		List<DasaEvent> list2 = new List<DasaEvent>();
		foreach (Event item2 in list)
		{
			DasaEvent item = new DasaEvent(item2);
			list2.Add(item);
		}
		return list2;
	}

	public static (EventNature eventNature, string desciption) PlanetDasaMajorPlanetAndMinorRelationship(PlanetName majorPlanet, PlanetName minorPlanet)
	{
		(EventNature, string) result = (EventNature.Empty, "");
		switch (majorPlanet.Name)
		{
		case PlanetName.PlanetNameEnum.Sun:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Unpleasantness with relatives and superiors, anxieties, headache, pain in the ear, some tendency to urinary or kidney troubles, sickness, fear from rulers and enemies, fear of death, loss of money, danger to father if the Sun is afflicted, stomachache and travels, gains through religious people, mental sufferings, a wandering life in a foreign country.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Winning favour from superiors, increase in business, fresh enterprises, troubles through women, eye troubles, many relatives and friends, indulgence in idle pastimes, jaundice and kindred ailments, new clothes and ornaments, will be happy, healthy, good meals, respect among relatives.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Rheumatic and similar troubles, quarrels, danger of enteric fever, dysentery, troubles to relatives, loss of money by thefts or wasteful expenses, failures, acquisition of wealth in the form of gold and gems, royal favour leading to prosperity, contraction and transmission of bilious and other diseases, mental worries, danger from fire, ill-health, loss of reputation, sorrow.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Gain in money, good reputation, acquisition of new clothes and ornaments, new education, trouble through relatives, mental distress, depression of spirits, waste of money and nervous weakness, no comforts, friends becoming enemies, much anxiety and fears, health bad, children ungrateful, disputes and trouble from ruler or judge, suffer disgrace, many short journeys and wanderings.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Benefits from friends and acquaintances, increase in education, employment in high circles, association with people of high rank, success through obstacles, birth of a child, wealth got through sons (if there is a son), honour to religious people, virtuous acts, good traditional observances, good society and conversations, reputation, gains and court-honours.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Gain of money, respect by rulers and gain of vehicles, likelihood of marriage, increase of property, illness, does many good works, acquisition of pearls or other precious stones, fatigue, addiction to immoral females and profitless discussions.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Constant sickness to family members, new enemies, some loss of property, bodily ailment, much unhappiness, displacement from home accidents, quarrels with relatives, loss of money, disease, lacking in energy, ignoble calls, mental worries, loans, danger from thieve and rulers.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Many troubles, changes according to the position of Rahu, family disputes, journeys, fear of death, trouble from relatives and enemies, loss of peace or mental misery, loss of money, sorrows, unsuccessful in all attempts, fear of thieves and reptiles, scandals.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Loss of money, affliction of mind with troubles, fainting or nervous exhaustion, mind full of misgivings, a long journey to a distant place, change of house due to disputes, troubles among relatives and associates, throat disease, mental anguish, ophthalmia, serious illness, fear from kings or rulers and enemies, diseases, cheated by others.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Moon:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Feverish complaints, pains in the eyes, success or failure according to position of the Sun and the Moon, legal power, free from diseases, decadence of enemies, happiness and prosperity, jaundice, dropsy, fever, loss of money, travels, danger to father and mother, piles, weakness, loss of children and friends.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Devoted attention to learning, love or music, good clothing, company of refined society, sound health, good reputation, journey to holy places, acquisition of abandoned wealth, power, vehicles and lands; marriage, relatives, fortunate deeds, inclination to public life, change of residence, birth of a child, increase of wealth, prosperity to relatives.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Quarrels and litigation among friends and relatives, headlong enterprises, danger of disputes between husband and wife, between lovers or in regard to marital affairs; disease, petulence, loss of money, waste of wealth, trouble from brothers and friends, danger from fever and fire, injury from instruments or stones, loss of blood and disease to household animals.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Good;
				result.Item2 = "Acquisition of wealth from maternal relatives, new clothes and ornaments, settlement of disputes, pleasure through children or lover, increase of wealth, accomplishment of desires, intellectual achievements, new education, honour from rulers, general happiness, enjoyment with females, addiction to betting and drinks.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Increase of property, plenty of food and comforts, prosperous, benefits from superiors such as masters or governors, birth. of a child, vehicles, abundance of clothes and ornaments and success in undertakings, patronage or rulers, gain or property, respect, learned.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Sudden gain from wife, enjoys comforts of agriculture, water products and clothing, suffers from diseases inherited by mother, sickness, pain, loss of property, enmity, gain of houses, good works and good meals, birth of children, expenses due to marriage or other auspicious acts.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Wife's death or separation, much mental anguish, loss of property, loss of friends, ill health, mental trouble due to mother, wind and bilious affections, harsh words, and discussion with unfriendly people, disease due to indigestion, no peace of mind, quarrels with relatives.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Distress of risks from falls and dangerous diseases, waste of wealth and loss of relatives and no ease to body, loss of money, danger of stirring up enemies, sickness, anxiety, enmity of superiors and elders, anxiety and troubles through wife, scandals, change of residence, diseases of skin, danger from thieves and poison, ill-health to father and mother, suffering from hunger.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Illness to wife, loss of relatives, suffering from stomach ache, loss or property, sickness of a feverish nature, danger from fire, subject to swellings or eruptions, eye troubles, mind filled with cares, public criticism or displeasure, dishonor, danger to father, mother and children, scandals among equals, eating of prohibited food, bad acts, bad company, loss of money and memory.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Mars:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Gain of money in bad ways, destruction of enemies, good reputation, long journey to foreign lands and peace of mind, blame, odium of ciders, quarrels with them, sufferings by diseases, heartache occasioned by one's own relatives, fever or other inflammatory affection, danger of fire, troubles through persons in position, many enemies.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Profit, acquisition of wealth, house renovated or some improvements effected in it, comforts of wealth, heavy sleep, ardent passion, enjoyment by the help or women.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Great heat, dislike of friends, annoyance from brothers and sisters, danger from rulers, failure of all undertakings, danger of hurts according to the sign held by Kuja, trouble with superiors and some anxiety through strangers, foreigners or people abroad and through warlike clan. Danger of open violence, quarrel with relations, loss of money, skin disease, consumption, loss of blood, fistula, and fissures in anus, loss of females and brothers, evil doings and boils.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Marriage or inclination to marriage, knowledge and fruits of knowledge, wealth, bodily evils disappear, slander, fear of insects, poisoned by animals and insects, gain of wealth by trade, abundance of houses, trouble from enemies and mental worries, service rendered to friends and relatives, new knowledge, success in litigation.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Loss of wealth, enemies, end the unfortunate period, favour from superiors and persons in position, gain of money, birth of children, auspicious celebrations, acquisition or wealth through holy people, freedom from illness, public reputation, ascendancy and happiness.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Acquisition of property, gain of money, domestic happiness, successful love affairs, inclination towards religious observances and festivities, favourable associations, influenced by priests, skin eruptions, boils, pleasure from travelling, jewels to wife, clothing, money from relatives and brothers, odium.of females and their society, increase of intelligence, enjoyment of females and gain of money.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Loss of money, diseases, loss of relatives and danger from arms or operation, illness leading to misery, evil threatened by enemies and robbers, disputes with rulers, loss of wealth, quarrel, disputes, litigation, loss of property, cutaneous effects. loss of office or position and much anxiety.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Danger from rulers and robbers, loss of wealth, success in evil pursuits, suffering from poisonous complaints, loss of relatives, danger from skin diseases, change of residence, some severe kind of cutaneous disease, journey to a foreign country, scandals, loss of cows and buffaloes, illness to wife, loss of memory, fear from insects and thieves, falls into well, fear from ghosts, affection of gonorrhea, fretting and";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Enmity and quarrels with low people, loss of money due to evil works, commission of signs, great sufferings due to troubles from relatives and brothers and opposition of bad people, family disputes, troubles with one's own kindred diseases, poisonous complaints, trouble through women, many enemies.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Mercury:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Pains in bead and stomach, enmity of people, loss of respect, danger of fire, anxieties, sickness to wire, troubles from enemies, many obstacles, troubles through superiors, acquisition of wealth.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Loss of health, some swellings or hurts in the limbs, quarrels and troubles through women, many difficulties, gain of money through ladies and agriculture and trade, success, happiness, diseases, ill-will of enemies, miscarriage of every concern, risk from quadrupeds.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Disappearance of all dangers diseases or enemies, fame derived from acts of charity and beneficence, royal favour, danger from jaundice or bilious fever, affections of the blood, neuralgic pains and headaches, troubles through neighbors, sickness, wounds or hurts, quarrels, addiction to drinks, betting and prostitutes, boils and hurts of arms, travels in forests and villages, sorrows, royal disfavour, imprisonment.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Good;
				result.Item2 = "Acquisition of beautiful house and apparel, money through relatives, success in every undertaking, the birth of a brother or sister, increase in family, gain in business, good mind charitable acts, learning of mathematics and arts.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Hatred of friends, relatives and elders, wealth, liable to diseases, acquisition of land and wealth, gain by trade, reputation, good happiness, good credit, benefits from superiors, birth of a child or marriage.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Observance of duty, conformable to religion and morality, acquisition of wealth, clothes and jewels, birth or good children, happiness in married state, relatives prosper, trade increases, knowledge gained, return from a long journey, if not married, betrothal in this period, health, ornaments, vehicles, house, money gained.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Bad luck. stranger to success and happiness, severe reversal, enmity, pain in the part governed by Saturn, downfall or disgrace to relatives, mind full of evil forebodings and distress. rear from diseases, loans, loss of children, destruction of family, scandals, troubles from foreigners, earnings through evil ways, acts of charity and beneficence, acquisition of wealth, material comforts through petty chiefs, failure in agricultural operations.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Intercourse with servants and prostitutes, skin diseases, sufferings from hot diseases, bad company and dirty meals. change or present position, fear and danger through foreigners, disputes concerning property, failure in litigation, evil dreams. headaches, sickness and loss of appetite. wealth from friends and relatives, happiness, new earnings.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Sorrow, disease, loss of work and Dharma, bilious sickness, aimless wandering, loss of property, misfortune to relatives, troubles through doctors, mental anxiety, trouble from relatives, mental agony, loss of comfort, dread of enemy, failure in business.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Jupiter:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Enemies, victory, ease, great diligence, coming in of wealth, royal favour and sound health, gain,good actions or fruits of good action, loss of bodily strength.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Increase of prosperity, gain of fame and fortune, acquisition or property, benefits through children, sexual intercourse with beautiful women, good meals and clothing, success and birth or a female child or marriage to some male member in the family, gain of money.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Disappointments and troubles of various kinds, loss by thefts, loss of near and dear relatives, inflammatory disease, transfer or leave, failure in hopes and business, wandering, high fever, great risks, loss of wealth and depression of mind, pilgrimage to temples, acquisition of wealth and fame, adventures.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Good;
				result.Item2 = "Increase of wealth, good and auspicious works in the house, communion with relatives, happy, increase of knowledge, acquisition of wealth through trade, favour from rulers, material comforts, perfect practice of hospitality, gain through knowledge in fine arts, birth of a well-favoured child, advantages from superiors.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Increase of property, domestic happiness, benefit from employment or occupation, birth of children, reputation, good meals, good deeds, health. royal favour, great diligence, success in all attempts, travels, dips in sacred rivers, pilgrimage, honour at stake if afflicted.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Appointment, wealth, reputation, gain of money, savings, development of sons and grandsons, jewels, good and delicious meals, marital happiness, auspicious works, reunion of the family, good success in profession or business, gain of land in the month of Taurus or Libra, much enjoyment, relatives, friends, peace or mind, acquisition or valuables, troubles from females and odium of public.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "A feeling of aversion, mental anguish, waste of wealth through sons, failure of business, increase of wealth and prosperity, pain in the body, rheumatic pains in limbs, trouble through wife or partners, failure in profit and credit, sorrows, fears, enmity of friends and relatives, adultery, unrighteous, a witness in court, quarrels in family, mental depression, funeral ceremonies for others,";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Income through low-caste people, apprehension of diseases, possibility of every possible calamity, deprivation of wealth.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Pilgrimages to holy shrines, increase of wealth, suffering for the sake of several seniors and rulers, death of partner if in business, change of residence, separation from relatives and friends, may forsake business, poisonous effects, loss of wealth, destruction of work, illness, boils.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Venus:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Anxious about everything, prosperity collapses, troubles with wife, children, land, family, disputes and quarrels, diseases affecting head, belly and eyes, damage in respect of agriculture.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Gains of females, education, knowledge, money, children and vehicles, worship of God, accomplishments of desires, troubles through wife, domestic happiness afterwards, pain and disease due to inflammation of nervous tissue and from lust and other passions of human nature.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Flow of bile, disease of the eyes, great exertion, much income, acquisition or wealth, marriage, acquisition of lands, venereal diseases, danger from arms, exile in foreign places, atheistic tendencies, increase of property through the influence of females, negligence of duty, bent on pleasure and passion, temporary affection of eyes.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Good;
				result.Item2 = "Association with prostitutes, enjoyments, knowledge, mathematical learning, success in litigations, inclination to learn music, piles and other hot ailments, pleasure through wife and children, increase of wealth, gain of knowledge in aru and sciences, wealth, royal favour, prosperity on a large scale and sound health.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Means of livelihood settled, gains from profession, benefits through superiors or employers or persons ruled by Jupiter fame, anxiety, quarrels with saints and religious men, gain of knowledge, end of dependence, worship of certain inferior natural forces, happiness and health, marriages, sexual intercourse, increase of family reputation and good deeds, wealth. ultimate happiness, wife and children suffer in the end.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Success, good servants and good many pleasures, money plentiful. disappearance of enemies, attainment of fame and birth of children.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Sexual intercourse with females advanced in age, accession to lands and wealth, disappearance of enemies, affection of excretory system, piles, etc., rheumatic pains in legs and bands, danger to eye sight, distaste for food, loss of appetite, physical condition poor, loss of money, wanderings, servitude, bolting and gambling, addiction to liquor, bad company, etc., ill-health, loss of memory, impotence.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Meditation, seclusion, quarrels among relatives and his people, entire change of surroundings, schemes of deception. miserliness, acquisition of lost property, dislike of relatives. evil from friends and injury by fire.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Discordance, death of relatives, injury inflicted by enemies, misgivings in heart, deprivation of wealth, troubles through wife, danger from quadrupeds, illness to partner or a member of the family, accidental blood poisoning, delirious fits, weakness in body and mind, gradual loss of wealth, loss of relatives, bad company, abode in seclusion, manifold sorrows, but happiness in the end.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Saturn:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Loss of wife and children, trouble from rulers or robbers. sinking of heart, danger of blood poisoning, haemorrhage of the generative system, chronic poisoning, intestinal swellings, affliction of the eyes, sickness even to healthy children and wife, body full of pain and disorders, danger of death. fear of death to father-in-law.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Increase in cattle, enmity of friends and relatives, cold affections, troubles and sickness, family disputes, loss of money and property, reduction to great need, mortgage of property and its recovery after a lapse of time, death of a near relative, sorrow, dislike of relatives, coming in of money, windy diseases.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Some disgrace, serious enmity, strife, much blame, wanderings from place to place, unsettled life, many enemies, loss of money by fraud or theft, change of residence, serious illness, distress to brothers and friends, hot diseases.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Good;
				result.Item2 = "Charitable works, gain of wealth, birth of children, increase of knowledge in some branch, prosperity to children, success to relatives, general prosperity, favours and approbation from superiors, increase of happiness, wealth and fame, benefits occurring from acts of piety and customary religious observances, agriculture and commerce.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Worship of gods and holy people, happiness to family, increase in bodily comforts, accomplishment of intentions by the help of superiors, increase of family circles, attainment of rank.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Auspicious, general happiness, attentions and favours from others, gifts, profits in business, increase of family members, victory over enemies, success in life, goodwill of relatives, accession to wife's property and wealth.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Brings on diseases, troubles and torments, much mental anguish, capacity of kings and free-hooters, loss of wealth, fear or poisonous effect to cattle, much sufferings to family, fever, wind or phlegm, bodily ailments and colic, body languishes, loss of money and children, serious enmities, dispute and troubles from relatives, blood and bilious complaints, quarrels in family, loss of money, mental derangement.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Disease in every limb, loss of wealth by rulers, robbers and foes, danger of physical hurts, various physical troubles, fevers, enemies, increase of troubles.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Rheumatism or sickness, danger of poison, danger from sons, loss of money, contentions and quarrels with vile and wicked people, dread of evil dreams, quarrels in family.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Rahu:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Hot fevers, giddiness, fear and enmity of people, quarrels in family, benefits from persons in good position, fear and suspicion in connection with wife, children and relatives, change of position or residence, love of charitable acts, contentment, cessation of all violence and outrage of contagious diseases, success in examinations, private life happy, much reputation and fame, but mental unrest.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Good;
				result.Item2 = "Abundance of enjoyments, good crops, coming in of money and communion with kith and kin, loss of relatives, loss of money through wife, pains in the limbs, change of position or residence, danger of personal hurts, unstability of health, sea voyages, gain of lands and money, loss or danger to wife and children.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Danger from rulers, fires or thieves and by arms, defeat in litigation, loss of money due to cousins, difficulties, sorrows, danger to the person due to malice of enemies, tendency to ease or dissolute habits, disputes and mental anxiety, combination of all possible calamities, bewilderment in every work and culpable failure of memory.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Many friends and relatives, wife and children, accession to wealth or royal favour. In the first 18 months of this period very busy, seriously inclined to marry. In the latter 12 months, enemies increase through his own action, happiness, birth of children, acquisition of vehicles, happiness to relatives and family, enjoyments with prostitutes, showy, gains through trade, fraudulent schemes.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Total disappearance of enemies and sickness, royal favour, acquisition of wealth, birth of children, increase of pleasure, gain through nobles or persons in power, benefits and comforts from superiors, success in all efforts, marriage in the house, increase of enemies, litigations and dips in sacred rivers.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Accession to vehicles and things of foreign land, troubles from foes, relatives and diseases, acquisition of wealth and other advantages, friendly alliances, wife a source of fortune and happiness, benefits from superiors or beads above in office, liable to deception, false friends, gain in land, birth of a child or marriage.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Scandal, danger due to fall of a tree, bad associations, divorce of wife or husband, incessant disputes and contests, rheumatism, biliousness, etc., throughout: disease due to wind and bile, distress of relatives, friends and well-wishers, residence in a remote foreign land.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Disturbance in mind, anxieties, quarrels among relatives, death of partner, master or the head of the family, mental anxiety, danger of poisoning, transfer, all sorts of scandals and quarrels, fever, bites of insects or wounds by arms, death of relatives, going to court as witness, quarrels with parents, diseases, illness to wife, failure of intellect, loss of wealth, wandering in far-off countries and distress there.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Danger, disease in the anus, no good and timely meals, epidemic diseases, danger of physical hurts and poison, ill-health to children, some swellings in the body, troubles through wife, danger from superiors, loss of wealth and honour, loss of children, death of cattle and misfortunes of all kinds.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		case PlanetName.PlanetNameEnum.Ketu:
			switch (minorPlanet.Name)
			{
			case PlanetName.PlanetNameEnum.Sun:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Disappointment, physical pain, exile in foreign country, peril and obstruction in every business, increase of knowledge, sickness in family, long journey and return, anxiety about wife's health.";
				return result;
			case PlanetName.PlanetNameEnum.Moon:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Disputes about fair sex, trouble through children, gains and financial success, diseases of biliousness and cold, loss of relatives and money, destruction of wealth and distress of mind.";
				return result;
			case PlanetName.PlanetNameEnum.Mars:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Odium of sons, wife and younger brothers, loss of relatives, trouble from diseases, foes and bad rulers, path of progress obstructed, fear and anxiety, disputes and contests of different kinds, enemies arise, danger of disputes and destruction through females, sufferings from fever, fear of robbers, death, imprisonment, urinary diseases, loss and difficulties and surgical operations.";
				return result;
			case PlanetName.PlanetNameEnum.Mercury:
				result.Item1 = EventNature.Neutral;
				result.Item2 = "Society of relatives, friends and the like, material gains from knowledge, danger from relatives, anxiety on account of children, failure in plans, deception, jealousy, falsehood, and knowledge.";
				return result;
			case PlanetName.PlanetNameEnum.Jupiter:
				result.Item1 = EventNature.Good;
				result.Item2 = "Exemption from ailments, acquisition of lands and birth of children, profitable transactions, association with people of good position, danger of poison, wife an object of pleasure, if unmarried marriage takes place.";
				return result;
			case PlanetName.PlanetNameEnum.Venus:
				result.Item1 = EventNature.Good;
				result.Item2 = "Wealth and happiness, birth of a child, efforts crowned with success, in the end sickness, wife ill, illness to children, quarrels, loss of relatives and friends, fever and dysentery.";
				return result;
			case PlanetName.PlanetNameEnum.Saturn:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Loss of wife, danger from enemies, imprisonment, loss of wealth, indigestion, property in danger or ruin, heavy loss in different ways, change of residence, some cutaneous diseases. anxiety owing to sickness of partner misgivings in the heart, mental anguish, difference of opinion with relations, exile in foreign countries.";
				return result;
			case PlanetName.PlanetNameEnum.Rahu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Loss of lands, imprisonment, quarrel with friends, danger of blood poisoning, danger of ruin, loss of property, fame and honour, rear of kings and robbers, sorrow, ruin of all business, adultery with mean women.";
				return result;
			case PlanetName.PlanetNameEnum.Ketu:
				result.Item1 = EventNature.Bad;
				result.Item2 = "Fear of death of wife or children, loss of wealth and happiness, mental troubles, separation from relatives, subject to some estrangement, restraint or detention, danger of poison.";
				return result;
			default:
				throw new Exception($"Planet not accounted for! : {minorPlanet}");
			}
		default:
			throw new Exception($"Planet not accounted for! : {majorPlanet}");
		}
	}

	public static int CurrentDasaCountFromBirth(Time birthTime, Time currentTime)
	{
		PlanetName pD = CurrentDasa8Levels(birthTime, birthTime).PD1;
		PlanetName pD2 = CurrentDasa8Levels(birthTime, currentTime).PD1;
		int num = 1;
		PlanetName planetName = pD;
		while (!(planetName == pD2))
		{
			planetName = NextDasaPlanet(planetName);
			num++;
		}
		return num;
	}

	public static Dasas CurrentDasa8Levels(Time birthTime, Time currentTime)
	{
		Constellation startConstellation = Calculate.PlanetConstellation(PlanetName.Moon, birthTime);
		PlanetName startDasaPlanet = ConstellationDasaPlanet(startConstellation.GetConstellationName());
		double num = YearsTraversedInBirthDasa(startConstellation, birthTime);
		if (Calculate.Ayanamsa == 3)
		{
			Calculate.SolarYearTimeSpan = 360.0;
		}
		double num2 = currentTime.Subtract(birthTime).TotalDays / Calculate.SolarYearTimeSpan;
		double years = num + num2;
		return DasaCountedFromInputDasa(startDasaPlanet, years);
	}

	public static Dasas DasaCountedFromInputDasa(PlanetName startDasaPlanet, double years)
	{
		double pd2Years = default(double);
		PlanetName pd1Planet = GetPD();
		double pd3Years = default(double);
		PlanetName pd2Planet = GetPD2();
		double pd4Years = default(double);
		PlanetName pd3Planet = GetPD3();
		double pd5Years = default(double);
		PlanetName pd4Planet = GetPD4();
		double pd6Years = default(double);
		PlanetName pd5Planet = GetPD5();
		double pd7Years = default(double);
		PlanetName pd6Planet = GetPD6();
		double pd8Years = default(double);
		PlanetName pd7Planet = GetPD7();
		PlanetName pD = GetPD8();
		return new Dasas
		{
			PD1 = pd1Planet,
			PD2 = pd2Planet,
			PD3 = pd3Planet,
			PD4 = pd4Planet,
			PD5 = pd5Planet,
			PD6 = pd6Planet,
			PD7 = pd7Planet,
			PD8 = pD
		};
		PlanetName GetPD()
		{
			PlanetName planetName = startDasaPlanet;
			double num;
			while (true)
			{
				num = PD1PlanetFullYears(planetName);
				years -= num;
				if (years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd2Years = years + num;
			return planetName;
		}
		PlanetName GetPD2()
		{
			PlanetName planetName = pd1Planet;
			double num;
			while (true)
			{
				num = PD2PlanetFullYears(pd1Planet, planetName);
				pd2Years -= num;
				if (pd2Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd3Years = pd2Years + num;
			return planetName;
		}
		PlanetName GetPD3()
		{
			PlanetName planetName = pd2Planet;
			double num;
			while (true)
			{
				num = PD3PlanetFullYears(pd1Planet, pd2Planet, planetName);
				pd3Years -= num;
				if (pd3Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd4Years = pd3Years + num;
			return planetName;
		}
		PlanetName GetPD4()
		{
			PlanetName planetName = pd3Planet;
			double num;
			while (true)
			{
				num = PD4PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, planetName);
				pd4Years -= num;
				if (pd4Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd5Years = pd4Years + num;
			return planetName;
		}
		PlanetName GetPD5()
		{
			PlanetName planetName = pd4Planet;
			double num;
			while (true)
			{
				num = PD5PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, planetName);
				pd5Years -= num;
				if (pd5Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd6Years = pd5Years + num;
			return planetName;
		}
		PlanetName GetPD6()
		{
			PlanetName planetName = pd5Planet;
			double num;
			while (true)
			{
				num = PD6PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet, planetName);
				pd6Years -= num;
				if (pd6Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd7Years = pd6Years + num;
			return planetName;
		}
		PlanetName GetPD7()
		{
			PlanetName planetName = pd6Planet;
			double num;
			while (true)
			{
				num = PD7PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet, pd6Planet, planetName);
				pd7Years -= num;
				if (pd7Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			pd8Years = pd7Years + num;
			return planetName;
		}
		PlanetName GetPD8()
		{
			PlanetName planetName = pd7Planet;
			while (true)
			{
				double num = PD8PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet, pd6Planet, pd7Planet, planetName);
				pd8Years -= num;
				if (pd8Years <= 0.0)
				{
					break;
				}
				planetName = NextDasaPlanet(planetName);
			}
			return planetName;
		}
	}

	public static PlanetName NextDasaPlanet(PlanetName planet)
	{
		if (planet == PlanetName.Sun)
		{
			return PlanetName.Moon;
		}
		if (planet == PlanetName.Moon)
		{
			return PlanetName.Mars;
		}
		if (planet == PlanetName.Mars)
		{
			return PlanetName.Rahu;
		}
		if (planet == PlanetName.Rahu)
		{
			return PlanetName.Jupiter;
		}
		if (planet == PlanetName.Jupiter)
		{
			return PlanetName.Saturn;
		}
		if (planet == PlanetName.Saturn)
		{
			return PlanetName.Mercury;
		}
		if (planet == PlanetName.Mercury)
		{
			return PlanetName.Ketu;
		}
		if (planet == PlanetName.Ketu)
		{
			return PlanetName.Venus;
		}
		if (planet == PlanetName.Venus)
		{
			return PlanetName.Sun;
		}
		throw new Exception("Planet not found!");
	}

	public static double TimeLeftInBirthDasa(Constellation startConstellation, Time birthTime)
	{
		double num = YearsTraversedInBirthDasa(startConstellation, birthTime);
		double num2 = PD1PlanetFullYears(ConstellationDasaPlanet(startConstellation.GetConstellationName())) - num;
		if (num2 < 0.0)
		{
			throw new Exception("Dasa years traversed is more than full years!");
		}
		return num2;
	}

	public static double YearsTraversedInBirthDasa(Constellation startConstellation, Time birthTime)
	{
		double totalMinutes = startConstellation.GetDegreesInConstellation().TotalMinutes;
		double num = DasaTimePerMinute(startConstellation.GetConstellationName());
		return totalMinutes * num;
	}

	public static double DasaTimePerMinute(ConstellationName constellationName)
	{
		return PD1PlanetFullYears(ConstellationDasaPlanet(constellationName)) / 800.0;
	}

	public static PlanetName ConstellationDasaPlanet(ConstellationName constellationName)
	{
		switch (constellationName)
		{
		case ConstellationName.Krithika:
		case ConstellationName.Uttara:
		case ConstellationName.Uttarashada:
			return PlanetName.Sun;
		case ConstellationName.Rohini:
		case ConstellationName.Hasta:
		case ConstellationName.Sravana:
			return PlanetName.Moon;
		case ConstellationName.Mrigasira:
		case ConstellationName.Chitta:
		case ConstellationName.Dhanishta:
			return PlanetName.Mars;
		case ConstellationName.Aridra:
		case ConstellationName.Swathi:
		case ConstellationName.Satabhisha:
			return PlanetName.Rahu;
		case ConstellationName.Punarvasu:
		case ConstellationName.Vishhaka:
		case ConstellationName.Poorvabhadra:
			return PlanetName.Jupiter;
		case ConstellationName.Pushyami:
		case ConstellationName.Anuradha:
		case ConstellationName.Uttarabhadra:
			return PlanetName.Saturn;
		case ConstellationName.Aslesha:
		case ConstellationName.Jyesta:
		case ConstellationName.Revathi:
			return PlanetName.Mercury;
		case ConstellationName.Aswini:
		case ConstellationName.Makha:
		case ConstellationName.Moola:
			return PlanetName.Ketu;
		case ConstellationName.Bharani:
		case ConstellationName.Pubba:
		case ConstellationName.Poorvashada:
			return PlanetName.Venus;
		default:
			throw new Exception("Dasa planet for constellation not found!");
		}
	}

	public static double PD1PlanetFullYears(PlanetName planet)
	{
		if (planet == PlanetName.Sun)
		{
			return 6.0;
		}
		if (planet == PlanetName.Moon)
		{
			return 10.0;
		}
		if (planet == PlanetName.Mars)
		{
			return 7.0;
		}
		if (planet == PlanetName.Rahu)
		{
			return 18.0;
		}
		if (planet == PlanetName.Jupiter)
		{
			return 16.0;
		}
		if (planet == PlanetName.Saturn)
		{
			return 19.0;
		}
		if (planet == PlanetName.Mercury)
		{
			return 17.0;
		}
		if (planet == PlanetName.Ketu)
		{
			return 7.0;
		}
		if (planet == PlanetName.Venus)
		{
			return 20.0;
		}
		throw new Exception("Planet not found!");
	}

	public static double PD2PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet)
	{
		return PD1PlanetFullYears(pd2Planet) / 120.0 * PD1PlanetFullYears(pd1Planet);
	}

	public static double PD3PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet)
	{
		return PD1PlanetFullYears(pd3Planet) / 120.0 * PD2PlanetFullYears(pd1Planet, pd2Planet);
	}

	public static double PD4PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet, PlanetName pd4Planet)
	{
		return PD1PlanetFullYears(pd4Planet) / 120.0 * PD3PlanetFullYears(pd1Planet, pd2Planet, pd3Planet);
	}

	public static double PD5PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet, PlanetName pd4Planet, PlanetName pd5Planet)
	{
		return PD1PlanetFullYears(pd5Planet) / 120.0 * PD4PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet);
	}

	public static double PD6PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet, PlanetName pd4Planet, PlanetName pd5Planet, PlanetName pd6Planet)
	{
		return PD1PlanetFullYears(pd6Planet) / 120.0 * PD5PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet);
	}

	public static double PD7PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet, PlanetName pd4Planet, PlanetName pd5Planet, PlanetName pd6Planet, PlanetName pd7Planet)
	{
		return PD1PlanetFullYears(pd7Planet) / 120.0 * PD6PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet, pd6Planet);
	}

	public static double PD8PlanetFullYears(PlanetName pd1Planet, PlanetName pd2Planet, PlanetName pd3Planet, PlanetName pd4Planet, PlanetName pd5Planet, PlanetName pd6Planet, PlanetName pd7Planet, PlanetName pd8Planet)
	{
		return PD1PlanetFullYears(pd8Planet) / 120.0 * PD7PlanetFullYears(pd1Planet, pd2Planet, pd3Planet, pd4Planet, pd5Planet, pd6Planet, pd7Planet);
	}
}
