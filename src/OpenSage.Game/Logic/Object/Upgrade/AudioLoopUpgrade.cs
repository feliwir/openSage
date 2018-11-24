﻿using OpenSage.Data.Ini.Parser;

namespace OpenSage.Logic.Object
{
    [AddedIn(SageGame.Bfme)]
    public sealed class AudioLoopUpgradeModuleData : UpgradeModuleData
    {
        internal static AudioLoopUpgradeModuleData Parse(IniParser parser) => parser.ParseBlock(FieldParseTable);

        private static new readonly IniParseTable<AudioLoopUpgradeModuleData> FieldParseTable = UpgradeModuleData.FieldParseTable
            .Concat(new IniParseTable<AudioLoopUpgradeModuleData>()
            {
                { "SoundToPlay", (parser, x) => x.SoundToPlay = parser.ParseAssetReference() },
                { "KillOnDeath", (parser, x) => x.KillOnDeath = parser.ParseBoolean() },
                { "KillAfterMS", (parser, x) => x.KillAfterMS = parser.ParseInteger() }
            });

        public string SoundToPlay { get; internal set; }
        public bool KillOnDeath { get; internal set; }
        public int KillAfterMS { get; internal set; }
    }
}
