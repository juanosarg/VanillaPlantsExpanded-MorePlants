using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

using System;


namespace VanillaPlantsExpandedMorePlants
{



    [HarmonyPatch(typeof(Plant))]
    [HarmonyPatch("PlantCollected")]
    public static class VanillaPlantsExpandedMorePlants_Plant_PlantCollected_Patch
    {
        [HarmonyPostfix]
        public static void AddHayToBarley(Plant __instance, Pawn by)
        {
            if(__instance.def == InternalDefOf.VCE_Barley)
            {
                
                float statValue = by.GetStatValue(StatDefOf.PlantHarvestYield);
                if (!(by.RaceProps.Humanlike && !__instance.Blighted && Rand.Value > statValue))
                {

                    int num = 15;
                    if (statValue > 1f)
                    {
                        num = GenMath.RoundRandom((float)num * statValue);
                    }
                    if (num > 0)
                    {
                        Thing thing = ThingMaker.MakeThing(ThingDefOf.Hay);

                        if (by.Faction != Faction.OfPlayer)
                        {
                            thing.SetForbidden(value: true);
                        }
                        GenPlace.TryPlaceThing(thing, by.Position, by.Map, ThingPlaceMode.Near);
                    }


                   
                }


               
            }

        }


    }


}











