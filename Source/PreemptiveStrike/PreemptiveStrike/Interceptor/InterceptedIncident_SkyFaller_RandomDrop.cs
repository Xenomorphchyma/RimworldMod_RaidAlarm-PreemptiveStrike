﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PreemptiveStrike.Dialogue;
using PreemptiveStrike.Mod;
using RimWorld;
using Verse;

namespace PreemptiveStrike.Interceptor
{
    class InterceptedIncident_SkyFaller_RandomDrop : InterceptedIncident_SkyFaller
    {

        public override string IncidentTitle_Confirmed => "PES_Skyfaller_raid".Translate();

        public override bool IsHostileToPlayer => true;

        public override SkyFallerType FallerType => SkyFallerType.Small;

        public override void ExecuteNow()
        {
            IncidentInterceptorUtility.isIntercepting_RandomDrop = false;
            if (this.incidentDef != null && this.parms != null)
                this.incidentDef.Worker.TryExecute(this.parms);
            else
                Log.Error("No IncidentDef or parms in InterceptedIncident!");
            IncidentInterceptorUtility.isIntercepting_RandomDrop = true;
        }

        public override bool PreCalculateDroppingSpot()
        {
            lookTargets = null;
            return true;
        }

        public override void confirmMessage()
        {
            SparkUILetter.Make("PES_Warning_DropPodAssault".Translate(), "PES_Warning_DropPodAssault_Text".Translate(), LetterDefOf.ThreatBig, parentCaravan);
            Find.TickManager.slower.SignalForceNormalSpeedShort();
        }

    }
}
