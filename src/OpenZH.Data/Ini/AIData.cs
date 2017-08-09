﻿using System.Collections.Generic;
using OpenZH.Data.Ini.Parser;

namespace OpenZH.Data.Ini
{
    public sealed class AIData
    {
        internal static AIData Parse(IniParser parser)
        {
            return parser.ParseTopLevelBlock(FieldParseTable);
        }

        private static readonly IniParseTable<AIData> FieldParseTable = new IniParseTable<AIData>
        {
            { "StructureSeconds", (parser, x) => x.StructureSeconds = parser.ParseFloat() },
            { "TeamSeconds", (parser, x) => x.TeamSeconds = parser.ParseInteger() },
            { "Wealthy", (parser, x) => x.Wealthy = parser.ParseInteger() },
            { "Poor", (parser, x) => x.Poor = parser.ParseInteger() },
            { "StructuresWealthyRate", (parser, x) => x.StructuresWealthyRate = parser.ParseFloat() },
            { "StructuresPoorRate", (parser, x) => x.StructuresPoorRate = parser.ParseFloat() },
            { "TeamsWealthyRate", (parser, x) => x.TeamsWealthyRate = parser.ParseFloat() },
            { "TeamsPoorRate", (parser, x) => x.TeamsPoorRate = parser.ParseFloat() },
            { "TeamResourcesToStart", (parser, x) => x.TeamResourcesToStart = parser.ParseFloat() },
            { "GuardInnerModifierAI", (parser, x) => x.GuardInnerModifierAI = parser.ParseFloat() },
            { "GuardOuterModifierAI", (parser, x) => x.GuardOuterModifierAI = parser.ParseFloat() },
            { "GuardInnerModifierHuman", (parser, x) => x.GuardInnerModifierHuman = parser.ParseFloat() },
            { "GuardOuterModifierHuman", (parser, x) => x.GuardOuterModifierHuman = parser.ParseFloat() },
            { "GuardChaseUnitsDuration", (parser, x) => x.GuardChaseUnitsDuration = parser.ParseInteger() },
            { "GuardEnemyScanRate", (parser, x) => x.GuardEnemyScanRate = parser.ParseInteger() },
            { "GuardEnemyReturnScanRate", (parser, x) => x.GuardEnemyReturnScanRate = parser.ParseInteger() },
            { "AlertRateModifier", (parser, x) => x.AlertRateModifier = parser.ParseFloat() },
            { "AggressiveRangeModifier", (parser, x) => x.AggressiveRangeModifier = parser.ParseFloat() },
            { "AttackPriorityDistanceModifier", (parser, x) => x.AttackPriorityDistanceModifier = parser.ParseFloat() },
            { "MaxRecruitRadius", (parser, x) => x.MaxRecruitRadius = parser.ParseFloat() },
            { "ForceIdleMSEC", (parser, x) => x.ForceIdleMsec = parser.ParseInteger() },
            { "ForceSkirmishAI", (parser, x) => x.ForceSkirmishAI = parser.ParseBoolean() },
            { "RotateSkirmishBases", (parser, x) => x.RotateSkirmishBases = parser.ParseBoolean() },
            { "AttackUsesLineOfSight", (parser, x) => x.AttackUsesLineOfSight = parser.ParseBoolean() },

            { "EnableRepulsors", (parser, x) => x.EnableRepulsors = parser.ParseBoolean() },
            { "RepulsedDistance", (parser, x) => x.RepulsedDistance = parser.ParseFloat() },

            { "WallHeight", (parser, x) => x.WallHeight = parser.ParseInteger() },

            { "AttackIgnoreInsignificantBuildings", (parser, x) => x.AttackIgnoreInsignificantBuildings = parser.ParseBoolean() },

            { "SkirmishGroupFudgeDistance", (parser, x) => x.SkirmishGroupFudgeDistance = parser.ParseFloat() },

            { "MinInfantryForGroup", (parser, x) => x.MinInfantryForGroup = parser.ParseInteger() },
            { "MinVehiclesForGroup", (parser, x) => x.MinVehiclesForGroup = parser.ParseInteger() },
            { "MinDistanceForGroup", (parser, x) => x.MinDistanceForGroup = parser.ParseFloat() },
            { "DistanceRequiresGroup", (parser, x) => x.DistanceRequiresGroup = parser.ParseFloat() },

            { "InfantryPathfindDiameter", (parser, x) => x.InfantryPathfindDiameter = parser.ParseInteger() },
            { "VehiclePathfindDiameter", (parser, x) => x.VehiclePathfindDiameter = parser.ParseInteger() },

            { "SupplyCenterSafeRadius", (parser, x) => x.SupplyCenterSafeRadius = parser.ParseFloat() },
            { "RebuildDelayTimeSeconds", (parser, x) => x.RebuildDelayTimeSeconds = parser.ParseInteger() },

            { "AIDozerBoredRadiusModifier", (parser, x) => x.AIDozerBoredRadiusModifier = parser.ParseFloat() },
            { "AICrushesInfantry", (parser, x) => x.AICrushesInfantry = parser.ParseBoolean() },
        };

        public float StructureSeconds { get; private set; }
        public int TeamSeconds { get; private set; }
        public int Wealthy { get; private set; }
        public int Poor { get; private set; }
        public float StructuresWealthyRate { get; private set; }
        public float StructuresPoorRate { get; private set; }
        public float TeamsWealthyRate { get; private set; }
        public float TeamsPoorRate { get; private set; }
        public float TeamResourcesToStart { get; private set; }
        public float GuardInnerModifierAI { get; private set; }
        public float GuardOuterModifierAI { get; private set; }
        public float GuardInnerModifierHuman { get; private set; }
        public float GuardOuterModifierHuman { get; private set; }
        public int GuardChaseUnitsDuration { get; private set; }
        public int GuardEnemyScanRate { get; private set; }
        public int GuardEnemyReturnScanRate { get; private set; }
        public float AlertRateModifier { get; private set; }
        public float AggressiveRangeModifier { get; private set; }
        public float AttackPriorityDistanceModifier { get; private set; }
        public float MaxRecruitRadius { get; private set; }
        public int ForceIdleMsec { get; private set; }
        public bool ForceSkirmishAI { get; private set; }
        public bool RotateSkirmishBases { get; private set; }
        public bool AttackUsesLineOfSight { get; private set; }

        public bool EnableRepulsors { get; private set; }
        public float RepulsedDistance { get; private set; }

        public int WallHeight { get; private set; }

        public bool AttackIgnoreInsignificantBuildings { get; private set; }

        public float SkirmishGroupFudgeDistance { get; private set; }

        public int MinInfantryForGroup { get; private set; }
        public int MinVehiclesForGroup { get; private set; }
        public float MinDistanceForGroup { get; private set; }
        public float DistanceRequiresGroup { get; private set; }

        public int InfantryPathfindDiameter { get; private set; }
        public int VehiclePathfindDiameter { get; private set; }

        public float SupplyCenterSafeRadius { get; private set; }
        public int RebuildDelayTimeSeconds { get; private set; }

        public float AIDozerBoredRadiusModifier { get; private set; }
        public bool AICrushesInfantry { get; private set; }

        public List<AISideInfo> SideInfos { get; } = new List<AISideInfo>();

        public List<AISkirmishBuildList> SkirmishBuildLists { get; } = new List<AISkirmishBuildList>();
    }

    public sealed class AISideInfo
    {
        public string Name { get; private set; }

        public int ResourceGatherersEasy { get; private set; }
        public int ResourceGatherersNormal { get; private set; }
        public int ResourceGatherersHard { get; private set; }
        public string BaseDefenseStructure1 { get; private set; }

        public AISkillSet SkillSet1 { get; private set; }
        public AISkillSet SkillSet2 { get; private set; }
    }

    public sealed class AISkillSet
    {
        public List<string> Sciences { get; } = new List<string>();
    }

    public sealed class AISkirmishBuildList
    {
        public string Name { get; private set; }

        public List<AIStructure> Structures { get; } = new List<AIStructure>();
    }

    public sealed class AIStructure
    {
        public string Key { get; private set; }

        public string Name { get; private set; }
        public IniPoint Location { get; private set; }
        public int Rebuilds { get; private set; }
        public float Angle { get; private set; }
        public bool InitiallyBuilt { get; private set; }
        public bool AutomaticallyBuild { get; private set; }
    }
}
