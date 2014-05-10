﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Machine.Specifications.Runner.Utility
{
    [Serializable]
    public class RunOptions
    {
        public IEnumerable<string> IncludeTags { get; protected set; }
        public IEnumerable<string> ExcludeTags { get; protected set; }
        public IEnumerable<string> Filters { get; protected set; }
        public IEnumerable<string> Contexts { get; protected set; }
        public string ShadowCopyCachePath { get; protected set; }
        public bool SeperateAppDomain { get; protected set; }

        private RunOptions()
        {
            this.IncludeTags = Enumerable.Empty<string>();
            this.ExcludeTags = Enumerable.Empty<string>();
            this.Filters = Enumerable.Empty<string>();
            this.Contexts = Enumerable.Empty<string>();
            this.SeperateAppDomain = false;
        }

        public static RunOptions Default { get { return new RunOptions(); } }
        public static RunOptionsBuilder Custom { get { return new RunOptionsBuilder(); } }

        public class RunOptionsBuilder : RunOptions 
        {
            internal RunOptionsBuilder()
            {
            }

            public RunOptionsBuilder Include(IEnumerable<string> tags)
            {
                this.IncludeTags = tags;

                return this;
            }

            public RunOptionsBuilder Exclude(IEnumerable<string> tags)
            {
                this.ExcludeTags = tags;

                return this;
            }

            public RunOptionsBuilder RunOnly(IEnumerable<string> contexts)
            {
                this.Contexts = contexts;

                return this;
            }

            public RunOptionsBuilder FilterBy(IEnumerable<string> filters)
            {
                this.Filters = filters;

                return this;
            }

            public RunOptionsBuilder ShadowCopyTo(string cachePath)
            {
                this.ShadowCopyCachePath = cachePath;
                return this;
            }

            public RunOptionsBuilder SeperateAppDomainPerAssembly()
            {
                this.SeperateAppDomain = true;
                return this;
            }
        }
    }
}