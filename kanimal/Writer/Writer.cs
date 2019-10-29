﻿using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using NLog;

namespace kanimal
{
    // TODO: Move code that can be reused in all writers from SCMLWriter to Writer
    public abstract class Writer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected List<KBuild.Row> BuildTable;
        protected KBuild.Build BuildData;
        protected Dictionary<int, string> BuildHashes;
        protected KAnim.Anim AnimData;
        protected Dictionary<int, string> AnimHashes;
        protected Dictionary<string, string> FilenameIndex;
        protected List<Sprite> Sprites;

        public abstract void Save(string path);
        
        // Outputs sprites to the output directory rather than doing anything else with them. 
        public void SaveSprites(string outputdir)
        {
            Directory.CreateDirectory(outputdir);
            foreach (var sprite in Sprites)
            {
                sprite.Bitmap.Save(Path.Join(outputdir, sprite.Name + ".png"), ImageFormat.Png);
            }
            Logger.Info($"Saved sprites to {outputdir}.");
        }
    }
}