using System;
using UnityEngine;
using Verse;
using RimWorld;

namespace VanillaPlantsExpandedMorePlants
{
    public class Plant_TransformOnMaturity : Plant
    {

        public int tickCounter = 0;      
        public const int tickInterval = 4;
        public bool checkOnlyOnce = false;


        public override void TickLong()
        {
            base.TickLong();

            if (!checkOnlyOnce) {
                tickCounter++;

                if (tickCounter >= tickInterval)
                {
                    if (HarvestableNow)
                    {
                        System.Random rand = new System.Random();

                        if (rand.NextDouble() < 0.25)
                        {

                        }

                        checkOnlyOnce = true;
                    }


                    tickCounter = 0;
                }

            }

           



        }

        public override void ExposeData()
        {
            base.ExposeData();
            
            Scribe_Values.Look(ref checkOnlyOnce, "checkOnlyOnce", false);
            Scribe_Values.Look(ref tickCounter, "tickCounter", 0);

        }

       

    }
}
